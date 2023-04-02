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
            SetupTimer();
            Seconds = TimeSpan.FromSeconds(5);
        }
        #endregion



        #region ------------- Implementation ------------------------------------------------------
        private void Button_Preselect_Click(object sender, RoutedEventArgs e)
        { 
            var buttonText = (sender as System.Windows.Controls.Button).Tag;
            var newValue = Convert.ToInt32(buttonText) * 60;
            Seconds = TimeSpan.FromSeconds(newValue);
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

        private void SetupTimer()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Tick += Count;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _timer.Stop();
        }
        #endregion
    }
}
