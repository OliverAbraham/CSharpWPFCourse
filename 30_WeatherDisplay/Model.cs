﻿using System;
using System.Collections.Generic;

namespace Models;

public class WeatherModel
{
    public double lat { get; set; }
    public double lon { get; set; }
    public string timezone { get; set; }
    public int timezone_offset { get; set; }
    public Current current { get; set; }
    public List<Minutely> minutely { get; set; }
    public List<Hourly> hourly { get; set; }
    public List<Daily> daily { get; set; }
}

public class Current
{
    public int dt { get; set; }
    public int sunrise { get; set; }
    public int sunset { get; set; }
    public double temp { get; set; }
    public double feels_like { get; set; }
    public int pressure { get; set; }
    public int humidity { get; set; }
    public double dew_point { get; set; }
    public double uvi { get; set; }
    public int clouds { get; set; }
    public int visibility { get; set; }
    public double wind_speed { get; set; }
    public int wind_deg { get; set; }
    public double wind_gust { get; set; }
    public List<Weather> weather { get; set; }
}

public class Daily
{
    public int dt { get; set; }
    public int sunrise { get; set; }
    public int sunset { get; set; }
    public int moonrise { get; set; }
    public int moonset { get; set; }
    public double moon_phase { get; set; }
    public Temp temp { get; set; }
    public FeelsLike feels_like { get; set; }
    public int pressure { get; set; }
    public int humidity { get; set; }
    public double dew_point { get; set; }
    public double wind_speed { get; set; }
    public int wind_deg { get; set; }
    public double wind_gust { get; set; }
    public List<Weather> weather { get; set; }
    public int clouds { get; set; }
    public double pop { get; set; }
    public double uvi { get; set; }
    public double? rain { get; set; }
}

public class FeelsLike
{
    public double day { get; set; }
    public double night { get; set; }
    public double eve { get; set; }
    public double morn { get; set; }
}

public class Hourly
{
    public int dt { get; set; }
    public DateTimeOffset Time { get; set; }
    public double temp { get; set; }
    public double feels_like { get; set; }
    public int pressure { get; set; }
    public int humidity { get; set; }
    public double dew_point { get; set; }
    public double uvi { get; set; }
    public int clouds { get; set; }
    public int visibility { get; set; }
    public double wind_speed { get; set; }
    public int wind_deg { get; set; }
    public double wind_gust { get; set; }
    public List<Weather> weather { get; set; }
    public double pop { get; set; }
    public Rain rain { get; set; }

    public override string ToString()   
    {
        return Time.ToString();
    }
}

public class Minutely
{
    public int dt { get; set; }
    public double precipitation { get; set; }
}

public class Rain
{
    public double _1h { get; set; }
}

public class Temp
{
    public double day { get; set; }
    public double min { get; set; }
    public double max { get; set; }
    public double night { get; set; }
    public double eve { get; set; }
    public double morn { get; set; }
}

public class Weather
{
    public int id { get; set; }
    public string main { get; set; }
    public string description { get; set; }
    public string icon { get; set; }
}

