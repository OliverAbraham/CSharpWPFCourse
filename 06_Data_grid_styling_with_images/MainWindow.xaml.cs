using System.Collections.Generic;
using System.Windows;

namespace _06_Data_grid_styling_with_images
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			var items = new List<DataGridItem>();
			items.Add(new DataGridItem("Resources/DocumentGroup.png"                  , "LONGER TEXT 1234", "shorter Text"));
			items.Add(new DataGridItem("Resources/FolderOpened.png"                   , "LONGER TEXT 1234", "shorter Text"));
			items.Add(new DataGridItem("Resources/StatusInformationOutlineNoColor.png", "LONGER TEXT 1234", "shorter Text"));
			GridMiddleDataGrid.ItemsSource = items;
		}
	}
}
