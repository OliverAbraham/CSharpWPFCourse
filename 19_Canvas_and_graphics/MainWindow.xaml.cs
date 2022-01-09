using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace _19_Canvas_and_graphics
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private double _x;
		private double _y;
		private double _ballSize = 30;
		private DispatcherTimer _timer;
		private Ellipse _ball;
		private bool _moveRight = true;
		private bool _moveDown = true;

		public MainWindow()
		{
			InitializeComponent();

			AddBallToCanvas();
			StartTimer();
		}

		private void StartTimer()
		{
			_timer = new DispatcherTimer();
			_timer.Interval = new TimeSpan(0,0,0,0,20); // 20 milliseconds = 50 per second
			_timer.Tick += Timer_Tick;
			_timer.Start();
		}

		private void Timer_Tick(object? sender, EventArgs e)
		{
			MoveBall();
			SetBallPosition();
			ReflectBallAtTheSides();
		}

		private void MoveBall()
		{
			if (_moveDown) _y++; else _y--;
			if (_moveRight) _x++; else _x--;
		}

		private void ReflectBallAtTheSides()
		{
			if (_x >= myCanvas.ActualWidth) // here we need to apply a small correction, what is it ?
				_moveRight = false;
			if (_x <= 0)
				_moveRight = true;
			if (_y >= myCanvas.ActualHeight) // here we need to apply a small correction, what is it ?
				_moveDown = false;
			if (_y <= 0)
				_moveDown = true;
		}

		private void AddBallToCanvas()
		{
			_ball = new Ellipse { Height = _ballSize, Width = _ballSize, Fill = Brushes.Blue };
			myCanvas.Children.Add(_ball);
			SetBallPosition();
		}

		private void SetBallPosition()
		{
			Canvas.SetLeft(_ball, _x);
			Canvas.SetTop(_ball, _y);
		}
	}
}
