using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using Models;
using System.Linq;
using System.IO;

namespace _30_WeatherDisplay
{
    class WeatherGatewayLogic
    {
        #region ------------- Properties ----------------------------------------------------------
        public Configuration ServerConfiguration { get { return _config; } set { _config = value; } }
        #endregion



        #region ------------- Fields --------------------------------------------------------------
        public class Configuration
        {
            public string WeatherServiceUrl { get; set; }
        }

        private Configuration _config;
        #endregion



        #region ------------- Methods -------------------------------------------------------------
        public (string, List<Forecast>) ReadCurrentTemperatureAndForecast()
        {
            var weather = GetCurrentWeather();

            AddTimesForUnixTimestampsInList(weather);

            // to have the whole day at hand, we save the current forecast every morning
            // later on that day we take the saved state to build the forecast object
            if (DateTime.Now.TimeOfDay >= new TimeSpan(5, 0, 0) &&
                DateTime.Now.TimeOfDay < new TimeSpan(7, 0, 0))
                Save(weather);
            var savedWeather = LoadSavedWeather();


            var forecast = new List<Forecast>();
            var today = DateTime.Now.Date;
            forecast.Add(FindEntry(weather, savedWeather, today.AddHours(7)));  // today at 7:00
            forecast.Add(FindEntry(weather, savedWeather, today.AddHours(13))); // today at 13:00
            forecast.Add(FindEntry(weather, savedWeather, today.AddHours(19))); // today at 19:00
            forecast.Add(FindEntry(weather, savedWeather, today.AddHours(23))); // today at 23:00

            var temperature = FindCurrentTemperature(weather);
            temperature = Math.Round(temperature, 1);
            return ($"{temperature}°", forecast);
        }
        #endregion



        #region ------------- Implementation ------------------------------------------------------
        private void AddTimesForUnixTimestampsInList(WeatherModel weather)
        {
            foreach (var hour in weather.hourly)
                hour.Time = ConvertUnixTimeToDateTime(hour.dt);
        }

        private double FindCurrentTemperature(WeatherModel weather)
        {
            return weather.current.temp;
        }

        private Forecast FindEntry(WeatherModel currentWeather, WeatherModel historicWeather, DateTime dateTime)
        {
            Console.Write($"{dateTime}: ");
            var result = new Forecast();
            result.Temp = 0.0;

            var entry = FindEntryForNow(currentWeather, dateTime);

            // If it is later than 7:00 am, we won't find earlier entries in "currentWeather".
            // in this cast we look into te saved state from 5:00 am
            if (entry is null && historicWeather is not null)
            {
                entry = FindEntryForNow(historicWeather, dateTime);
                if (entry is null)
                    Console.Write($"    historic data not found!");
                else
                    Console.Write($"    taking historic data    ");
            }

            // If we also didn't find it there, we give up
            if (entry is null)
            {
                Console.WriteLine($"    no data!");
                return result;
            }

            // remove the timeszine
            result.Hour = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second);
            result.Temp = Math.Round(entry.temp, 0);

            var icon = entry.weather.First();
            if (icon is null)
            {
                Console.Write($"no icon!    ");
            }
            else
            {
                result.Icon = ConvertWeatherIcon(icon.id.ToString());
                result.IconDescription = icon.description;
                result.WeatherDescription = icon.main;
            }

            Console.WriteLine($"Hour: {result.Hour}, Temp: {result.Temp}  Icon: {icon.id} {result.Icon.ToString("G")} IconDesc: {result.IconDescription} Desc: {result.WeatherDescription}");
            return result;
        }

        private static Hourly FindEntryForNow(WeatherModel currentWeather, DateTime dateTime)
        {
            return currentWeather.hourly
                .Where(x => TimeIsToday(x.Time, dateTime) && TimeIsInThatHour(x.Time, dateTime))
                .FirstOrDefault();
        }

        private static bool TimeIsInThatHour(DateTimeOffset x, DateTime timeNow)
        {
            var now = timeNow.TimeOfDay;
            var nowPlusOneHour = timeNow.AddHours(1).AddSeconds(-1).TimeOfDay;
            return x.TimeOfDay >= now && x.TimeOfDay < nowPlusOneHour;
        }

        private static bool TimeIsToday(DateTimeOffset x, DateTime timeNow)
        {
            return x.Date == timeNow.Date;
        }

        private DateTimeOffset ConvertUnixTimeToDateTime(int epoch)
        {
            var timeZone = TimeZone.CurrentTimeZone; 
            var timezoneOffset = timeZone.GetUtcOffset(DateTime.Now);
            return new DateTimeOffset(1970, 1, 1, 0, 0, 0, timezoneOffset).AddSeconds(epoch);
        }

        private Forecast.WeatherIcon ConvertWeatherIcon(string icon)
        {
            if (icon is null)           return Forecast.WeatherIcon.Unknown;
            if (icon.StartsWith("2"))   return Forecast.WeatherIcon.ThunderCloudAndRain;
            if (icon.StartsWith("3"))   return Forecast.WeatherIcon.SunCloudRain;
            if (icon.StartsWith("50"))  return Forecast.WeatherIcon.SunCloudRain;
            if (icon.StartsWith("51"))  return Forecast.WeatherIcon.CloudWithSnow;
            if (icon.StartsWith("52"))  return Forecast.WeatherIcon.CloudWithRain;
            if (icon.StartsWith("5"))   return Forecast.WeatherIcon.CloudWithRain;
            if (icon.StartsWith("6"))   return Forecast.WeatherIcon.Snow;
            if (icon.StartsWith("7"))   return Forecast.WeatherIcon.Fog;
            if (icon == "800")          return Forecast.WeatherIcon.Sun;
            if (icon.StartsWith("8"))   return Forecast.WeatherIcon.Cloud;
            return Forecast.WeatherIcon.Unknown;
        }

        private WeatherModel GetCurrentWeather()
        {
            var httpClient = new RestClient();
            var request = new RestRequest(_config.WeatherServiceUrl, Method.Get);
            var response = httpClient.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine($"Request wasn't successful.\nMore info:{response.StatusDescription}");
                return new WeatherModel();
            }

            var myWeatherData = JsonConvert.DeserializeObject<WeatherModel>(response.Content);
            return myWeatherData;
        }

        private WeatherModel LoadSavedWeather()
        {
            if (!File.Exists("saved_weather_forecast.json"))
                return null;
            var serializedWeatherModel = File.ReadAllText("saved_weather_forecast.json");
            return JsonConvert.DeserializeObject<WeatherModel>(serializedWeatherModel);
        }

        private void Save(WeatherModel weather)
        {
            var serializedWeatherModel = JsonConvert.SerializeObject(weather);
            File.WriteAllText("saved_weather_forecast.json", serializedWeatherModel);
        }
        #endregion
    }
}
