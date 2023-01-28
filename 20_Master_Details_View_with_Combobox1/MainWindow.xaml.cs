using _20_Master_Details_View_with_Combobox1.DialogWindows;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;

namespace _20_Master_Details_View_with_Combobox1
{
	public partial class MainWindow : Window, INotifyPropertyChanged
	{
        #region ------------- Properties for data binding -----------------------------------------
        public ObservableCollection<MyRow> Rows
		{
            get {  return _myData?.Rows; }
            set { }
		}
		
        public MyRow CurrentRow
		{
            get {  return _myData?.CurrentRow; }
            set 
            { 
                _myData.CurrentRow = value; 
                NotifyPropertyChanged(nameof(CurrentRow));
            }
		}
		#endregion



		#region ------------- Fields --------------------------------------------------------------
        private MyComboboxData _myData;
        private const string FILENAME = "combobox.json";
        #endregion



		#region ------------- Ctor ----------------------------------------------------------------
		public MainWindow()
		{
			InitializeComponent();
			DataContext = this;
			LoadData();
			DisplayData();
		}

		private void Window_Closing(object sender, CancelEventArgs e)
		{
			SaveData();
		}
        #endregion



        #region ------------- Implementation  -----------------------------------------------------
		#region ------------- Combobox storage -------------------------------
		private void LoadData()
		{
			try
			{
				var fileContents = File.ReadAllText(FILENAME);
				_myData = JsonConvert.DeserializeObject<MyComboboxData>(fileContents);
			}
			catch (Exception)
			{
				// this is the initilisation for the first time, when the file doesn't exist
				_myData = new MyComboboxData("Default");
				SaveData();
			}
		}

		private void SaveData()
		{
            try
			{
                var fileContents = JsonConvert.SerializeObject(_myData, Formatting.Indented);
                File.WriteAllText(FILENAME, fileContents);
			}
            catch (Exception ex)
			{
                MessageBox.Show($"Error writing to file {FILENAME}:\n{ex.Message}");
			}
		}
        #endregion
		#region ------------- Combobox UI -------------------------------------
        private void DisplayData()
		{
			NotifyPropertyChanged(nameof(Rows));
			_myData.CurrentRow = _myData.Rows.FirstOrDefault(x => x.Name == _myData.CurrentRow.Name);
			CurrentRow = _myData.CurrentRow;
		}

		private void Button_AddRow_Click(object sender, RoutedEventArgs e)
		{
			// Create a new data row and open the dialog, that the user can enter a name
            var dlg = new ComboboxDetailsDialog();
			dlg.NewRow = new MyRow();
            var dialogResult = dlg.ShowDialog();
            if (dialogResult != true)
                return; // user closed the dialog with cancel
            
			// let the model validate the new row
            if (!_myData.Validate(dlg.NewRow, out string errorMessages))
			{
                MessageBox.Show(errorMessages);
                return;
			}

			// It's ok, so we can add the new row
			_myData.AddNewRow(dlg.NewRow);
			
			// and we select the new row automatically because we assume the user wants that
            CurrentRow = dlg.NewRow;
            SaveData();
		}

		private void Button_RemoveRow_Click(object sender, RoutedEventArgs e)
		{
            if (!_myData.CurrentRowCanBeDeleted(out string errorMessages))
			{
                MessageBox.Show(errorMessages);
                return;
			}

            var result = MessageBox.Show($"Do you really want to delete the row '{_myData.CurrentRow?.Name}' ?", 
                "Delete ?", 
                MessageBoxButton.YesNo, 
                MessageBoxImage.Question,
                defaultResult: MessageBoxResult.No);
            if (result != MessageBoxResult.Yes)
                return;

			_myData.RemoveRow(_myData.CurrentRow);

			// after deletion, select any other row
            CurrentRow = _myData.Rows[0];
            SaveData();
		}
		#endregion
		#region ------------- INotifyPropertyChanged ---------------------------
		// add "INotifyPropertyChanged" to your class
		// add "using System.ComponentModel";
		// add "using System";

		[NonSerialized]
		private PropertyChangedEventHandler _PropertyChanged;
		public event PropertyChangedEventHandler PropertyChanged
		{
			add
			{
				_PropertyChanged += value;
			}
			remove
			{
				_PropertyChanged -= value;
			}
		}

		public void NotifyPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler Handler = _PropertyChanged; // avoid race condition
			if (Handler != null)
				Handler(this, new PropertyChangedEventArgs(propertyName));
		}
		#endregion
		#endregion
	}
}
