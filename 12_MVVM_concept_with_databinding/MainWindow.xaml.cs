using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace _12_MVVM_concept_with_databinding
{
	public partial class MainWindow : Window
	{
        private ViewModel _VM;
        private Model _M;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        /// <summary>
        /// Constructs the connections between View and ViewModel (explicitly for demonstration)
        /// </summary>
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _M = new Model();
            _VM = new ViewModel(_M);

            button1.Click += delegate(object s1, RoutedEventArgs e1) { _VM.InitDialog(); };
            button2.Click += delegate(object s1, RoutedEventArgs e1) { _VM.Save(); };

            textBox1.DataContext = _VM;
            textBox1.SetBinding(TextBox.TextProperty, new Binding( nameof(_VM.TextBox1) ));

            textBox2.DataContext = _VM;
            textBox2.SetBinding(TextBox.TextProperty, new Binding( nameof(_VM.TextBox2) ));

            textBox3.DataContext = _VM;
            textBox3.SetBinding(TextBox.TextProperty     , new Binding( nameof(_VM.TextBox3) ));
            textBox3.SetBinding(TextBox.IsEnabledProperty, new Binding( nameof(_VM.TextBox3_IsEnabled) ));

            checkBox1.DataContext = _VM;
            checkBox1.SetBinding(CheckBox.IsCheckedProperty, new Binding( nameof(_VM.CheckBox1_IsChecked) ));
            checkBox1.Checked   += delegate(object sender, RoutedEventArgs e) { _VM.CheckBox_Checked(); };
            checkBox1.Unchecked += delegate(object sender, RoutedEventArgs e) { _VM.CheckBox_Checked(); };
        }
	}
}
