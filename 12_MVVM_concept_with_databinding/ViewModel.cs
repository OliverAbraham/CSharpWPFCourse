using System.Windows;
using System.ComponentModel;
using _12_MVVM_concept_with_databinding.Commands;
using System;

namespace _12_MVVM_businesslogic
{
	/// <summary>
	/// ViewModel of the dialog
	/// </summary>
	public class ViewModel : INotifyPropertyChanged
	{
		#region ------------- Properties ----------------------------------------------------------
		public Model CurrentPerson => _m;

		public bool IsMusician_ViewModel
		{
			get { return _m.IsMusician; }
			set
			{
				_m.IsMusician = value;
				TextBox_Instrument_IsEnabled = _m.IsMusician;
			}
		}

		public bool TextBox_Instrument_IsEnabled 
		{
			get { return textBox_Instrument_IsEnabled; }
			set
			{
				textBox_Instrument_IsEnabled = value; 
				NotifyPropertyChanged(nameof(TextBox_Instrument_IsEnabled));
			}
		}

		public MessageCommand Save_Command { get; set; }

		public bool DataWasSaved { get; set; }

		public delegate MessageBoxResult ShowMessageboxDelegate(string text);
		public ShowMessageboxDelegate ShowMessageBox { get; set; }
		#endregion



		#region ------------- Fields --------------------------------------------------------------
		private Model _m;
		#endregion



		#region ------------- Init ----------------------------------------------------------------
		public ViewModel(Model m)
		{
			_m = m;
			IsMusician_ViewModel = _m.IsMusician;
			Save_Command = new MessageCommand(OnSave);
			ShowMessageBox = delegate (string text) { return MessageBoxResult.None; };  // this is called a "null object"
		}
		#endregion



		#region ------------- Methods -------------------------------------------------------------
		#endregion



		#region ------------- Implementation ------------------------------------------------------
		private void OnSave()
		{
			ShowMessageBox($"Data was saved with {_m} !");
			DataWasSaved = true;
		}

		#region ------------- INotifyPropertyChanged ---------------------------

		[NonSerialized]
		private PropertyChangedEventHandler _PropertyChanged;
		private bool textBox_Instrument_IsEnabled;

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
