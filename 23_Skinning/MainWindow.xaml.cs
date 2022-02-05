using System.Windows;

namespace _23_Skinning
{

	// my source:
	// https://michaelscodingspot.com/wpf-complete-guide-themes-skins/


	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Light_Checked(object sender, RoutedEventArgs e)
		{
			(App.Current as App).ChangeSkin(Skin.Light);
		}

		private void Dark_Checked(object sender, RoutedEventArgs e)
		{
			(App.Current as App).ChangeSkin(Skin.Dark);
		}
	}
}
