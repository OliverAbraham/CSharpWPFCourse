using Abraham.WPFWindowLayoutManager;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Threading;

namespace _35_NotepadWithAutosave
{
    public partial class MainWindow : Window
    {
        #region ------------- Fields --------------------------------------------------------------
        private string _filename = @"Notepad_with_autosave.zip";
		private WindowLayoutManager _layoutManager;
        private DispatcherTimer _timer;
        private string _title;
        private bool _autosaveActive = false;
        #endregion



        #region ------------- Init ----------------------------------------------------------------
        public MainWindow()
        {
			_layoutManager = new WindowLayoutManager(window:this, key:"MainWindow");
            InitializeComponent();
            DataContext = this;
            _timer = new DispatcherTimer();
            _timer.Tick += SaveContent;
            _timer.Interval = new TimeSpan(hours: 0, minutes: 0, seconds: 5);
        }
        #endregion



        #region ------------- Implementation ------------------------------------------------------
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _title = Title;
            LoadContent();
            _autosaveActive = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _timer?.Stop();
			_layoutManager.Save();
            SaveContent(null, null);
        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!_autosaveActive)
                return;
            
            // ifthis is the first keystroke, start the timer
            if (!_timer.IsEnabled)
            {
                _timer.Start();
            }
            // otherwise restart the wait time. That means, while typing it will never save, but 5 seconds after the last keystroke
            else
            {
                _timer.Stop();
                _timer.Start();
            }
            Title = _title + " *";
        }

        private void SaveContent(object? sender, EventArgs e)
        {
            var range = new TextRange(RichTextBoxControl.Document.ContentStart, RichTextBoxControl.Document.ContentEnd);
            var fStream = new FileStream(_filename, FileMode.Create);
            range.Save(fStream, DataFormats.XamlPackage);
            fStream.Close();
            Title = _title;
        }

        private void LoadContent()
        {
            if (File.Exists(_filename))
            {
                var range = new TextRange(RichTextBoxControl.Document.ContentStart, RichTextBoxControl.Document.ContentEnd);
                var fStream = new FileStream(_filename, FileMode.OpenOrCreate);
                range.Load(fStream, DataFormats.XamlPackage);
                fStream.Close();
            }
        }
        #endregion
    }
}
