using System;
using System.Globalization;
using System.Windows.Data;

namespace _07_Data_grids_for_editing
{
	[ValueConversion(typeof(System.Drawing.Image), typeof(System.Windows.Media.ImageSource))]
    public sealed class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            var done = (bool)value;
            var bitmapPath = done ? "Resources/OverlayOk.png" : "";
            var bitmap = new System.Windows.Media.Imaging.BitmapImage(new Uri(bitmapPath, UriKind.Relative));
            return bitmap;
        }
 
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
