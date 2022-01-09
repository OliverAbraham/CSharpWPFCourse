namespace _12_MVVM_businesslogic
{
	/// <summary>
	/// Represents the DTO (data transfer object) for the domain
	/// </summary>
	public class Model
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsMusician { get; set; }
        public string Instrument { get; set; }

		public override string ToString()
		{
			return $"{FirstName} {LastName}";
		}
	}
}
