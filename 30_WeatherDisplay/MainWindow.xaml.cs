using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Threading;
using static _30_WeatherDisplay.WeatherGatewayLogic;

namespace _30_WeatherDisplay
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        #region ------------- Properties ----------------------------------------------------------
        public string CurrentTemperature { get; set; }
        #endregion



        #region ------------- Fields --------------------------------------------------------------
        private WeatherGatewayLogic _logic;
        private string _configurationFile = @"C:\Credentials\WpfCourseWeatherDisplay.json";
        #endregion



        #region ------------- Init ----------------------------------------------------------------
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // read credentials necessary to download the weather forecast from a file.
            _logic = new WeatherGatewayLogic();
            var configurationData = File.ReadAllText(_configurationFile);
            _logic.ServerConfiguration = (Configuration)JsonConvert.DeserializeObject<Configuration>(configurationData);

            // read the first time
            PeriodicUpdate(null,null);

            // then set up a timer to update the display every 1 minute
            _updateTimer = new DispatcherTimer();
            _updateTimer.Tick += PeriodicUpdate;
            _updateTimer.Interval = new TimeSpan(hours: 0, minutes: 1, seconds: 0);
            _updateTimer.Start();
        }
        #endregion



        #region ------------- Methods -------------------------------------------------------------
        #endregion



        #region ------------- Implementation ------------------------------------------------------
        private void PeriodicUpdate(object sender, EventArgs e)
        {
            try
            {
                var (temperature, forecast) = _logic.ReadCurrentTemperatureAndForecast();
                // we have also got a 24 hour forecast, which we dont use here!
                CurrentTemperature = temperature;
            }
            catch (Exception ex)
            {
                CurrentTemperature = "---";
            }
            NotifyPropertyChanged(nameof(CurrentTemperature));
        }


        #region ------------- INotifyPropertyChanged ---------------------------

        // add "INotifyPropertyChanged" to your class
        // add "using System.ComponentModel";
        // add "using System";

        [NonSerialized]
        private PropertyChangedEventHandler? _propertyChanged;
        private DispatcherTimer _updateTimer;

        public event PropertyChangedEventHandler? PropertyChanged
        {
            add
            {
                _propertyChanged += value;
            }
            remove
            {
                _propertyChanged -= value;
            }
        }

        public void NotifyPropertyChanged(string propertyName)
        {
            var handler = _propertyChanged; // avoid race condition
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
        #endregion
    }
}
