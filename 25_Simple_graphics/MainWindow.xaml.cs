using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace _25_Simple_graphics
{
    public partial class MainWindow : Window
    {
        private List<Shape> _shapes = new List<Shape>();
        private DispatcherTimer _timer;
        private Random _randomNumberGenerator = new Random();

        public MainWindow()
        {
            InitializeComponent();
            AddLine();
            AddTriangle();
            AddRectangle();
            AddPolygon();
            AddCircle();
			StartTimer();
		}

        private void AddLine()
        {
            var line = new Line() { X1 = 0, Y1 = 0, X2 = 100, Y2 = 150, StrokeThickness = 5, Stroke = Brushes.Black };
            AddToCanvasAt(line, 50, 50);
        }

        private void AddTriangle()
        {
            var polygon = new Polygon() { StrokeThickness = 1,  Stroke = Brushes.Black, Fill = Brushes.DarkBlue };
            polygon.Points.Add(new Point(0  ,100));
            polygon.Points.Add(new Point(100,100));
            polygon.Points.Add(new Point(50 ,0  ));
            polygon.Points.Add(new Point(0  ,100));
            AddToCanvasAt(polygon, 200, 50);
        }

        private void AddRectangle()
        {
            var polygon = new Polygon() { StrokeThickness = 1,  Stroke = Brushes.Black, Fill = Brushes.DarkRed };
            polygon.Points.Add(new Point(0  ,100));
            polygon.Points.Add(new Point(100,100));
            polygon.Points.Add(new Point(100,  0));
            polygon.Points.Add(new Point(0  ,  0));
            AddToCanvasAt(polygon, 350, 50);
        }

        private void AddPolygon()
        {
            var polygon = new Polygon() { StrokeThickness = 1,  Stroke = Brushes.Black, Fill = Brushes.DarkGreen };
            polygon.Points.Add(new Point(  0,  0));
            polygon.Points.Add(new Point( 20, 50));
            polygon.Points.Add(new Point(  0,100));
            polygon.Points.Add(new Point( 50, 80));
            polygon.Points.Add(new Point(100,100));
            polygon.Points.Add(new Point( 80, 50));
            polygon.Points.Add(new Point(100,  0));
            polygon.Points.Add(new Point( 50, 20));
            polygon.Points.Add(new Point(  0,  0));
            AddToCanvasAt(polygon, 500, 50);
        }

        private void AddCircle()
        {
            var circle = new Ellipse() { Width = 100, Height = 100, StrokeThickness = 1,  Stroke = Brushes.Black, Fill = Brushes.DarkCyan };
            AddToCanvasAt(circle, 300, 200);
        }

        private void AddToCanvasAt(Shape shape, double x, double y)
        {
            _shapes.Add(shape);
            myCanvas.Children.Add(shape);
            Canvas.SetLeft(shape, x);
            Canvas.SetTop (shape, y);
        }

		private void StartTimer()
		{
			_timer = new DispatcherTimer();
			_timer.Interval = new TimeSpan(0,0,0,1,0); // every second
			_timer.Tick += Timer_Tick;
			_timer.Start();
		}

		private void Timer_Tick(object? sender, EventArgs e)
		{
			MoveShapesRandomly();
		}

        private void MoveShapesRandomly()
        {
            foreach(var shape in _shapes)
                MoveShapeToRandomPosition(shape);
        }

        private void MoveShapeToRandomPosition(Shape shape)
        {
            var x = _randomNumberGenerator.NextDouble() * (myCanvas.ActualWidth -  100);
            var y = _randomNumberGenerator.NextDouble() * (myCanvas.ActualHeight - 100);
            Canvas.SetLeft(shape, x);
            Canvas.SetTop (shape, y);
        }
    }
}
