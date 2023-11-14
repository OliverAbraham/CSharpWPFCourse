using Abraham.ProgramSettingsManager;
using System.Configuration;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PropertyGrid
{
    public partial class MainWindow : Window
    {
        private MyConfiguration _config;
        private ProgramSettingsManager<MyConfiguration> _configurationManager;

        public MainWindow()
        {
            InitializeComponent();
			LoadConfiguration();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveConfiguration();
        }

		public void LoadConfiguration()
        {
			try
			{
				_configurationManager = new ProgramSettingsManager<MyConfiguration>()
					.UseFilename("appsettings.json");
				_configurationManager.Load();
				_config = _configurationManager.Data;
			}
			catch (Exception)
			{
				_config = CreateSeedData();
			}
        }

        private MyConfiguration CreateSeedData()
        {
            return new MyConfiguration()
            {
                Option1 = "Option 1 initial value",
                Option2 = 2,
                Option3 = true
            };
        }

        public void SaveConfiguration()
		{
			_configurationManager.Save(_config);
		}

        private void Button_OpenSettingsDialog_Click(object sender, RoutedEventArgs e)
        {
            var wnd = new MySettingsWindow(_config);
            wnd.ShowDialog();
        }
    }
}