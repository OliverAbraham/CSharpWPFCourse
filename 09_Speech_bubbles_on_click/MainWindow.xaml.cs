using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace _09_Speech_bubbles_on_click
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void SpeechBubbleClick(object sender, MouseButtonEventArgs e)
		{
			var grid = (sender as Grid);
			grid.Visibility = Visibility.Collapsed;
		}

		private void SpeechBubbleTextboxClick(object sender, MouseButtonEventArgs e)
		{
			var textBlock = sender as TextBlock;
			var stackPanel = textBlock.Parent as StackPanel;
			var grid = stackPanel.Parent as Grid;
			grid.Visibility = Visibility.Collapsed;
		}

		private void Button4_i_Click(object sender, RoutedEventArgs e)
		{
			if (InfoButton1.Visibility == Visibility.Visible)
				InfoButton1.Visibility = Visibility.Collapsed;
			else
				InfoButton1.Visibility = Visibility.Visible;
		}

		private void CloseInfoBubble1(object sender, MouseButtonEventArgs e)
		{
			InfoButton1.Visibility = Visibility.Collapsed;
		}
	}
}
