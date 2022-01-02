using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Windows;

namespace _07_Data_grids_for_editing
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			Thread.CurrentThread.CurrentCulture   = new CultureInfo("de-DE");
			Thread.CurrentThread.CurrentUICulture = new CultureInfo("de-DE");
			Thread.CurrentThread.CurrentCulture  .NumberFormat.CurrencyDecimalSeparator = ",";
			Thread.CurrentThread.CurrentCulture  .NumberFormat.CurrencyGroupSeparator   = ".";
			Thread.CurrentThread.CurrentUICulture.NumberFormat.CurrencyDecimalSeparator = ",";
			Thread.CurrentThread.CurrentUICulture.NumberFormat.CurrencyGroupSeparator   = ".";
			Thread.CurrentThread.CurrentCulture  .NumberFormat.NumberDecimalSeparator   = ",";
			Thread.CurrentThread.CurrentCulture  .NumberFormat.NumberGroupSeparator     = ".";
			Thread.CurrentThread.CurrentUICulture.NumberFormat.NumberDecimalSeparator   = ",";
			Thread.CurrentThread.CurrentUICulture.NumberFormat.NumberGroupSeparator     = ".";
			
			var items = new List<DataGridItem>();
			items.Add(new DataGridItem(true  , "Milk"  ,  "1 Liter"              , 1234441.50m ));
			items.Add(new DataGridItem(false , "Bread" , "My favourite white one", 3444332.10m ));
			items.Add(new DataGridItem(true  , "Cheese", "10 slices"             , 1000000.66m ));
			EditorDataGrid.Items.Clear();
			EditorDataGrid.ItemsSource = items;
		}
	}
}
