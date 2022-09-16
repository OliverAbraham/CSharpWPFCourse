using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace _10_Data_grid_with_observable_collection
{
	public partial class MainWindow : Window
	{
        public ObservableCollection<Person> Persons { get; set; }

        public MainWindow()
		{
			InitializeComponent();
			DataContext = this;
			LoadData();
		}

		private void LoadData()
		{
			Persons = new ObservableCollection<Person>();
			Persons.Add(new Person() { ID = 1, Name = "James Bond", Birthday = new DateTime(1960, 2, 3) });
			Persons.Add(new Person() { ID = 2, Name = "Luke Skywalker", Birthday = new DateTime(2960, 2, 3) });
		}

		private void Button_Click(object sender, RoutedEventArgs e)
        {
			// The "trick" here is that you only add items to the collection.
			// The data grid updates automatically.
            Persons.Add(new Person() { ID = 3, Name = "Batman", Birthday = new DateTime(2960, 2, 3) });
        }
	}
}
