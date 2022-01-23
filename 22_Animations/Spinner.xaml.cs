using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace UIPack
{
    public partial class BusyIndicatorControl : UserControl
    {
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text",
                    typeof(string), typeof(BusyIndicatorControl),new FrameworkPropertyMetadata(new PropertyChangedCallback(TextChangedCallback)));


        public string Text
        {
            get { return (string)this.GetValue(TextProperty); }
            set { this.SetValue(TextProperty, value); }
        }

        private static void TextChangedCallback(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var busyIndicator = o as BusyIndicatorControl;
            busyIndicator.textBlock.Text = (string)e.NewValue;
        }

        public BusyIndicatorControl()
        {
            this.InitializeComponent();
        }
    }

    public class TextToVisibilityConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || ((string)value).Trim().Length == 0)
                return Visibility.Collapsed;
            else
                return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException("NotImplemented!");
        }

        #endregion
    }
}