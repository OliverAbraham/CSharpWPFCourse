using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace _11_Image_fill_from_URL
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
            string Url = "https://www.serrala.com/sites/default/files/202106/website-hero-homepage-image.jpeg";
			LabelUrl.Content = Url;
            MyImage.Source = new BitmapImage(new Uri(Url, UriKind.Absolute));
		}
	}
}
