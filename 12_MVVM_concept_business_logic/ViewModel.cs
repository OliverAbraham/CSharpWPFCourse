using System.Windows;
using System.ComponentModel;

namespace _12_MVVM_businesslogic
{
	/// <summary>
	/// ViewModel of the dialog
	/// </summary>
	public class ViewModel : INotifyPropertyChanged
    {
        public Model CurrentPerson => _m;
        public MessageCommand CheckBox1_IsChecked_Command { get; private set; }
        public bool   TextBox3_IsEnabled    { get; set; }


        private Model _m;


        public ViewModel(Model m)
        {
            _m = m;
            CheckBox1_IsChecked_Command = new MessageCommand(CheckBox1_IsChecked);
        }

        private void CheckBox1_IsChecked()
        {
            MessageBox.Show(MyMessageText);
        }

        public void InitDialog()
        {
        }

        public void CheckBox_Checked()
        {
            //TextBox3_IsEnabled = !CheckBox1_IsChecked;
            //NotifyPropertyChanged( nameof(TextBox3_IsEnabled) );

            //TextBox3 = CheckBox1_IsChecked.ToString();
            //NotifyPropertyChanged( nameof(TextBox3) );
        }

        public void Save()
        {
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
