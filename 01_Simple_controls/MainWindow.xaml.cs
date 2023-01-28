using SampleData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace _01_Simple_controls
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public List<string> Countries { get; set; }
        public ObservableCollection<Person> Persons { get; set; }

        public Person CurrentPerson 
        { 
            get { return currentPerson; } set { currentPerson = value; NotifyPropertyChanged(nameof(CurrentPerson)); }
        }
        private int _currentPersonIndex = 0;

        public MainWindow()
        {
            InitializeComponent();
            Countries = SampleDataGenerator.GenerateCountries();
            Persons = SampleDataGenerator.GeneratePersons();
            DataContext = this;
            CurrentPerson = Persons[_currentPersonIndex];
        }

        private void Button_Previous_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPersonIndex > 0)
            {
                _currentPersonIndex--;
                CurrentPerson = Persons[_currentPersonIndex];
            }
        }

        private void Button_Next_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPersonIndex < Persons.Count - 1)
            {
                _currentPersonIndex++;
                CurrentPerson = Persons[_currentPersonIndex];
            }
        }

        #region ------------- INotifyPropertyChanged ---------------------------

        // add "INotifyPropertyChanged" to your class
        // add "using System.ComponentModel";
        // add "using System";

        [NonSerialized]
        private PropertyChangedEventHandler? _propertyChanged;
        private Person currentPerson;

        public event PropertyChangedEventHandler? PropertyChanged
        {
            add
            {
                _propertyChanged += value;
            }
            remove
            {
                _propertyChanged -= value;
            }
        }

        public void NotifyPropertyChanged(string propertyName)
        {
            var handler = _propertyChanged; // avoid race condition
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion       
    }
}
