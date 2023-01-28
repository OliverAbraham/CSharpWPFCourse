using SampleData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace _03_Data_grid_error_handling
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

		// Generate a "primary key", a unique number for new rows
		private void DataGrid_InitializingNewItem(object sender, System.Windows.Controls.InitializingNewItemEventArgs e)
		{
			Person newItem = (Person)e.NewItem;
			newItem.ID = Persons.Select(x => x.ID).Max()+1;
			newItem.Birthday = DateTime.Parse("01.01.2000");
			newItem.Gender = "Neutral";
        }
    }

    // IMPORTANT: This is the validator that is called by DataGrid after every row edit
    public class PersonValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            Person? person = (Person)((value as BindingGroup).Items[0]);
            if (person is null)
                return ValidationResult.ValidResult;
            if (person.Birthday > DateTime.Now)
                return new ValidationResult(false,"Birthday cannot be in future!");
            return ValidationResult.ValidResult;
        }
    }
}
