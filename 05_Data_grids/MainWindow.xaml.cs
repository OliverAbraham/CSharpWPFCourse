using System.Collections.Generic;
using System.Windows;

namespace _05_Data_grids
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			var items = new List<DataGridItem>();
			items.Add(new DataGridItem("Resources/DocumentGroup.png"    , "LONGER TEXT 1234", "shorter Text"));
			items.Add(new DataGridItem("Resources/FolderOpened.png"     , "LONGER TEXT 1234", "shorter Text"));
			items.Add(new DataGridItem("Resources/StatusInformation.png", "LONGER TEXT 1234", "shorter Text"));
			GridMiddleDataGrid.ItemsSource = items;
		}
	}
}
