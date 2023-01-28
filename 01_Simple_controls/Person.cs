using System;
using System.ComponentModel;

namespace SampleData
{
    public class Person : INotifyPropertyChanged
    {
        public int      ID            { get; set; }
        public string   FirstName     { get; set; }
        public string   LastName      { get; set; }
        public DateTime Birthday      { get; set; }
        public string   Country       { get; set; }
        public bool     Musician      { get; set; }
        public string   Gender        { get; set; }

        public bool IsMale    { get { return Gender == "Male";    } set { Gender = "Male";    GenderChanged(); } }
        public bool IsFemale  { get { return Gender == "Female";  } set { Gender = "Female";  GenderChanged(); } }
        public bool IsNeutral { get { return Gender == "Neutral"; } set { Gender = "Neutral"; GenderChanged(); } }

        private void GenderChanged()
        {
            NotifyPropertyChanged(nameof(IsMale));
            NotifyPropertyChanged(nameof(IsFemale));
            NotifyPropertyChanged(nameof(IsNeutral));
        }


        #region ------------- INotifyPropertyChanged ---------------------------

        // add "INotifyPropertyChanged" to your class
        // add "using System.ComponentModel";
        // add "using System";

        [NonSerialized]
        private PropertyChangedEventHandler? _propertyChanged;
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
