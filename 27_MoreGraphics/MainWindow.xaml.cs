using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace _27_MoreGraphics
{
    public partial class MainWindow : Window
    {
        private List<MyShapeData> _shapes = new List<MyShapeData>();
        private MyShapeData? _currentMovedShape;

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
            var data = new MyShapeData(shape, x, y);
            _shapes.Add(data);
            myCanvas.Children.Add(data.Shape);
            Canvas.SetLeft(shape, data.X);
            Canvas.SetTop (shape, data.Y);
        }

        private void MoveShapeTo(MyShapeData shape, double x, double y)
        {
            shape.X = x; 
            shape.Y = y;
            Canvas.SetLeft(shape.Shape, shape.X);
            Canvas.SetTop (shape.Shape, shape.Y);
        }

        private void myCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var pos = e.GetPosition(myCanvas);
            _currentMovedShape = FindShapeUnderMouseCursor(pos.X, pos.Y);
            CalculateMouseOffsetRelativeToCanvas(_currentMovedShape, pos);
        }

        private void CalculateMouseOffsetRelativeToCanvas(MyShapeData shape, Point pos)
        {
            // this calculate where the shape was "picked" by the mouse pointer
            shape.OffsetX = pos.X - shape.X;
            shape.OffsetY = pos.Y - shape.Y;
        }

        private void myCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _currentMovedShape = null;
        }

        private void myCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (_currentMovedShape == null)
                return;
            var pos = e.GetPosition(myCanvas);
            MoveShapeToPostionWithOffset(_currentMovedShape, pos);
        }

        private void MoveShapeToPostionWithOffset(MyShapeData shape, Point pos)
        {
            MoveShapeTo(shape, pos.X - shape.OffsetX, pos.Y - shape.OffsetY);
        }

        private void myCanvas_MouseLeave(object sender, MouseEventArgs e)
        {
            myCanvas_MouseLeftButtonUp(null,null);
        }

        private MyShapeData FindShapeUnderMouseCursor(double x, double y)
        {
            foreach(var shape in _shapes)
            {
                var element = myCanvas.InputHitTest(new Point(x,y));
                if (element == shape.Shape)
                    return shape;
            }
            return null;
        }
    }
}
