using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace EggTimer
{
    public partial class MainWindow : Window
    {
        #region ------------- Properties ----------------------------------------------------------
        public TimeSpan Seconds 
        {
            get { return _seconds; }
            set 
            { 
                _seconds = value; 
                CurrentTime.Content = _seconds.ToString(@"mm\:ss"); 
            }
        }
        #endregion

        #region ------------- Fields --------------------------------------------------------------
        private TimeSpan _seconds = TimeSpan.FromSeconds(5);
        private DispatcherTimer _timer;
        private bool _running;
        #endregion

        #region ------------- Init ----------------------------------------------------------------
        public MainWindow()
        {
            InitializeComponent();
            _timer = SetupTimer();
            Seconds = TimeSpan.FromSeconds(5);
        }
        #endregion

        #region ------------- Implementation ------------------------------------------------------
        private void Button_Preselect_Click(object sender, RoutedEventArgs e)
        { 
            if (sender is System.Windows.Controls.Button myButton)
            {
                var buttonText = myButton.Tag;
                var newValue = Convert.ToInt32(buttonText) * 60;
                Seconds = TimeSpan.FromSeconds(newValue);
            }
        }

        private void Button_Start_Click(object sender, RoutedEventArgs e)
        {
            if (!_running)
                Start();
            else
                Stop();
        }

        private void Start()
        {
            _running = true;
            _timer.Start();
            StartButton.Content = "Stop";
            StartButton.Background = Brushes.LightSalmon;
        }

        private void Stop()
        {
            _running = false;
            _timer.Stop();
            StartButton.Content = "Start";
            StartButton.Background = Brushes.LightGreen;
        }

        private void Count(object? sender, EventArgs e)
        {
            Seconds = Seconds.Add(TimeSpan.FromSeconds(-1));
            if (Seconds.TotalSeconds == 0)
            {
                Stop();
                PlaySound();
            }
        }

        private void PlaySound()
        {
             Uri uri = new Uri(System.Environment.CurrentDirectory + @"\dampflok.mp3");
             var player = new MediaPlayer();
             player.Open(uri);
             player.Play();
        }

        private DispatcherTimer SetupTimer()
        {
            var timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Count;
            return timer;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _timer.Stop();
        }
        #endregion
    }
}
