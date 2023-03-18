using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace Eieruhr
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private int Sekunden;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Sekunden = 5;
            Uhrzeit.Content = Sekunden;

            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0,0,1);
            timer.Tick += UhrzeitAnzeigen;
            timer.Start();
        }

        private void UhrzeitAnzeigen(object? sender, EventArgs e)
        {
            Sekunden--;
            Uhrzeit.Content = Sekunden;
            if (Sekunden == 0)
            {
                timer.Stop();
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
    }
}
