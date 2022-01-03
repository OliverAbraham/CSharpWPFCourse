using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace _15_Timers
{
    public partial class MainWindow : Window
	{
        private Random _randomNumberGenerator;
        private DispatcherTimer _timer1;
        private DispatcherTimer _timer2;
        private DispatcherTimer _timer3;

        public MainWindow()
        {
            InitializeComponent();
            _randomNumberGenerator = new Random(0);

            _timer1 = new DispatcherTimer();
            _timer1.Tick += Timer1_Tick;
            _timer1.Interval = new TimeSpan(hours: 0, minutes: 0, seconds: 1);
            _timer1.Start();

            _timer2 = new DispatcherTimer();
            _timer2.Tick += Timer2_Tick;
            _timer2.Interval = new TimeSpan(hours: 0, minutes: 0, seconds: 2);
            _timer2.Start();

            _timer3 = new DispatcherTimer();
            _timer3.Tick += Timer3_Tick;
            _timer3.Interval = new TimeSpan(hours: 0, minutes: 0, seconds: 3);
            _timer3.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Elli1.Fill = new SolidColorBrush(GetMeAColor());
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            Elli2.Fill = new SolidColorBrush(GetMeAColor());
        }

        private void Timer3_Tick(object sender, EventArgs e)
        {
            Elli3.Fill = new SolidColorBrush(GetMeAColor());
        }

        private Color GetMeAColor()
        {
            return Color.FromRgb(
                (byte)_randomNumberGenerator.Next(0, 255),
                (byte)_randomNumberGenerator.Next(0, 255),
                (byte)_randomNumberGenerator.Next(0, 255)
                );
        }
	}
}
