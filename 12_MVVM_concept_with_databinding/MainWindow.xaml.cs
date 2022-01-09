using System.Windows;

namespace _12_MVVM_businesslogic
{
	public partial class MainWindow : Window
	{
        private ViewModel _VM;
        private Model _M;

        public MainWindow()
        {
            InitializeComponent();
            _M = LoadData();
            _VM = new ViewModel(_M);
            DataContext = _VM;

            // for special purposes we're giving the viewmodel some delegates
            _VM.ShowMessageBox = MessageBox.Show;
        }

		private Model? LoadData()
		{
            return new Model()
            {
                FirstName = "Ludwig",
                LastName = "van Beethoven",
                IsMusician = true,
                Instrument = "Piano"
            };
		}
	}
}
