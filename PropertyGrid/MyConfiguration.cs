using System.ComponentModel;

namespace PropertyGrid
{
    public class MyConfiguration
    {
		public string             Option1 { get; set; }
        public int                Option2 { get; set; }
		public bool               Option3 { get; set; }
        
        // This demostrates how to store values that are not editable by the user.
		[Browsable(false)]
		public bool               ThisIsNotVisible { get; set; }


        // when adding new properties, remember to update Clone() and CopyPropertiesFrom() !!!
        public MyConfiguration Clone()
        {
            return new MyConfiguration()
            {
                Option1 = this.Option1,
                Option2 = this.Option2,
                Option3 = this.Option3
            };
        }


        // when adding new properties, remember to update Clone() and CopyPropertiesFrom() !!!
        internal void CopyPropertiesFrom(MyConfiguration workingCopy)
        {
            this.Option1 = workingCopy.Option1;
            this.Option2 = workingCopy.Option2;
            this.Option3 = workingCopy.Option3;
        }
    }
}
