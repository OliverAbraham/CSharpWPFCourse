using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace _26_Graphics_moving_with_mouse
{
    public partial class MainWindow : Window
    {
        private List<Shape> _shapes = new List<Shape>();
        private Shape? _currentMovedShape;

        public MainWindow()
        {
            InitializeComponent();
            AddLine();
            AddTriangle();
            AddRectangle();
            AddPolygon();
            AddCircle();
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

        private void MoveShapeToRandomPosition(Shape shape, double x, double y)
        {
            Canvas.SetLeft(shape, x);
            Canvas.SetTop (shape, y);
        }

        private void myCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var x = e.GetPosition(myCanvas).X;
            var y = e.GetPosition(myCanvas).Y;
            _currentMovedShape = FindShapeUnderMouseCursor(x,y);
            //System.Diagnostics.Debug.WriteLine("button down");
        }

        private void myCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _currentMovedShape = null;
            //System.Diagnostics.Debug.WriteLine("button up");
        }

        private void myCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (_currentMovedShape == null)
                return;
            var x = e.GetPosition(myCanvas).X;
            var y = e.GetPosition(myCanvas).Y;
            MoveShapeToRandomPosition(_currentMovedShape, x,y);
            //System.Diagnostics.Debug.WriteLine($"moving to {x} {y}");
        }

        private void myCanvas_MouseLeave(object sender, MouseEventArgs e)
        {
            myCanvas_MouseLeftButtonUp(null,null);
        }

        private Shape FindShapeUnderMouseCursor(double x, double y)
        {
            foreach(var shape in _shapes)
            {
                var element = myCanvas.InputHitTest(new Point(x,y));
                if (element == shape)
                    return shape;
            }
            return null;
        }
    }
}
