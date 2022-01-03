using System.Windows;

namespace _14_Animations
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Button_FadeOut_Click(object sender, RoutedEventArgs e)
		{
			WpfAnimations.FadeOut(MyControl, OpacityProperty);
		}

		private void Button_FadeIn_Click(object sender, RoutedEventArgs e)
		{
			WpfAnimations.FadeIn(MyControl, OpacityProperty);
		}

	}
}
