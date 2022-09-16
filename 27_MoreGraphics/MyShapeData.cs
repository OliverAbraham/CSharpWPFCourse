using System.Windows.Shapes;

namespace _27_MoreGraphics
{
    internal class MyShapeData
    {
        public MyShapeData(Shape shape, double x, double y)
        {
            Shape = shape;
            X = x;
            Y = y;
        }

        public Shape Shape { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double OffsetX { get; internal set; }
        public double OffsetY { get; internal set; }
    }
}
