﻿using SampleData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace _10_Data_grid_with_observable_collection
{
	public partial class MainWindow : Window
	{
        public List<string> Countries { get; set; }
        public ObservableCollection<Person> Persons { get; set; }

        public MainWindow()
		{
			InitializeComponent();
            Countries = SampleDataGenerator.GenerateCountries();
            Persons = SampleDataGenerator.GeneratePersons();
			DataContext = this;
		}

		private void Button_ChangeLastNameOfAllItems_Click(object sender, RoutedEventArgs e)
        {
			// The "trick" here is that you only add items to the collection. The data grid updates automatically.
			foreach(var person in Persons) 
			{
				person.LastName += "X";
				person.NotifyPropertyChanged(nameof(Person.LastName));
			}
        }

		// Generate a "primary key", a unique number for new rows
		private void DataGrid_InitializingNewItem(object sender, System.Windows.Controls.InitializingNewItemEventArgs e)
		{
			Person newItem = (Person)e.NewItem;
			newItem.ID = Persons.Select(x => x.ID).Max()+1;
			newItem.Birthday = DateTime.Parse("01.01.2000");
			newItem.Gender = "Neutral";
        }
	}
}
