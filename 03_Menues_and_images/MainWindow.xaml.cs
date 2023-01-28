using System.Windows;

namespace _03_Menues_and_images
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

        private void Image_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
			MessageBox.Show("First Icon was selected!");
        }
    }
}
