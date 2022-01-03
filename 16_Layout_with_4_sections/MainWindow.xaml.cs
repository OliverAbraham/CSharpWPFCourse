using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace _16_Layout_with_4_sections
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
        private PopupManager _PopupManager;

        public MainWindow()
        {
            InitializeComponent();
            _PopupManager = new PopupManager();
            _PopupManager.OnOpen += _PopupManager_OnOpen;
            _PopupManager.OnClose += _PopupManager_OnClose;
        }

        private List<object> _PopupManager_OnOpen(string tag)
        {
            var Items = new List<object>();
            Items.Add("Item 1");
            Items.Add("Item 2");
            Items.Add("Item 3");
            return Items;
        }

        private void _PopupManager_OnClose(object selectedItem)
        {
            MessageBox.Show(selectedItem as string);
        }

        private void OnPopupMenu(object sender, MouseButtonEventArgs e)
        {
            _PopupManager.ShowPopup(sender, e);
        }
	}
}
