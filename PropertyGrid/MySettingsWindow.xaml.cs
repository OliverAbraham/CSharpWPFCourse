using System.Configuration;
using System.Windows;
using Xceed.Wpf.Toolkit.PropertyGrid;

namespace PropertyGrid
{
    public partial class MySettingsWindow : Window
    {
        private MyConfiguration _myConfiguration;
        private MyConfiguration _workingCopy;

        public MySettingsWindow(MyConfiguration myConfiguration)
        {
            InitializeComponent();

            _myConfiguration = myConfiguration;
            _workingCopy = myConfiguration.Clone();
            _propertyGrid.SelectedObject = _workingCopy;
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            _myConfiguration.CopyPropertiesFrom(_workingCopy);
            DialogResult = true;
            Close();
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
