using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SampleData
{
    class SampleDataGenerator
    {
        public static ObservableCollection<Person> GeneratePersons()
        {
            var persons = new ObservableCollection<Person>();
            persons.Add(new Person() { ID = 1, FirstName = "James"   , LastName = "Bond"     , Birthday = new DateTime(1960, 2, 3), Country = "England", Gender = "Male" });
            persons.Add(new Person() { ID = 2, FirstName = "Luke"    , LastName = "Skywalker", Birthday = new DateTime(2960, 2, 3), Country = "England", Gender = "Male" });
            persons.Add(new Person() { ID = 3, FirstName = "Sherlock", LastName = "Holmes"   , Birthday = new DateTime(1920, 3, 4), Country = "England", Gender = "Male" });
            return persons;
        }

        public static List<string> GenerateCountries()
        {
            return new List<string>() { "England", "France", "Germany", "Other" };
        }
    }
}
