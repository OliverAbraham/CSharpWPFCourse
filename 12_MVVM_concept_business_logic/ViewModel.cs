using System;
using System.ComponentModel;
using System.Windows;

namespace _12_MVVM_concept_with_databinding
{
	/// <summary>
	/// ViewModel of the dialog
	/// </summary>
	public class ViewModel : INotifyPropertyChanged
    {
        public string TextBox1              { get; set; }
        public string TextBox2              { get; set; }
        public bool   CheckBox1_IsChecked   { get; set; }
        public string TextBox3              { get; set; }
        public bool   TextBox3_IsEnabled    { get; set; }

        private IModel _M;
        public DatabaseTableRow _Row;

        public ViewModel(IModel m)
        {
            _M = m;
        }

        public void InitDialog()
        {
            _Row = _M.Load();
            TextBox1 = _Row.DatabaseField1;
            TextBox2 = _Row.DatabaseField2;
            TextBox3 = _Row.DatabaseField3;
            NotifyPropertyChanged( nameof(TextBox1) );
            NotifyPropertyChanged( nameof(TextBox2) );
            NotifyPropertyChanged( nameof(TextBox3) );
        }

        public void CheckBox_Checked()
        {
            TextBox3_IsEnabled = !CheckBox1_IsChecked;
            NotifyPropertyChanged( nameof(TextBox3_IsEnabled) );

            TextBox3 = CheckBox1_IsChecked.ToString();
            NotifyPropertyChanged( nameof(TextBox3) );
        }

        public void Save()
        {
            _M.Save();
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
