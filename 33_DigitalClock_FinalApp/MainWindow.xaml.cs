using System;
using System.Windows;
using System.Windows.Threading;

namespace _33_DigitalClock_FinalApp
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer _timer;

        public MainWindow()
        {
            InitializeComponent();
            _timer = new DispatcherTimer();
            _timer.Tick += UpdateUI;
            _timer.Interval = new TimeSpan(hours:0, minutes:0, seconds:1);
            _timer.Start();
        }

        private void UpdateUI(object sender, EventArgs e)
        {
            var Now = DateTime.Now;
            Hour10  .Value = Now.Hour   / 10;
            Hour1   .Value = Now.Hour   % 10;
            Minute10.Value = Now.Minute / 10;
            Minute1 .Value = Now.Minute % 10;
            Second10.Value = Now.Second / 10;
            Second1 .Value = Now.Second % 10;
        }
    }
}
