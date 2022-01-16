using System;
using System.ComponentModel;
using System.Windows;

namespace _20_Master_Details_View_with_Combobox1.DialogWindows
{
	public partial class ComboboxDetailsDialog : Window, INotifyPropertyChanged
	{
		public MyRow NewRow { get; set; }

		public ComboboxDetailsDialog()
		{
			InitializeComponent();
			DataContext = this;
			NotifyPropertyChanged(nameof(NewRow.DisplayName));
			textBoxDisplayName.Focus();
		}

		private void Button_Save_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = true;
			Close();
		}

		private void Button_Cancel_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = false;
			Close();
		}

		#region ------------- INotifyPropertyChanged ---------------------------
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
	}
}
