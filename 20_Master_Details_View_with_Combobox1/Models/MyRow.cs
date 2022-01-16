using Newtonsoft.Json;

namespace _20_Master_Details_View_with_Combobox1
{
	public class MyRow
	{
		public string Name { get; set; }
		
		// we don't want to save this, because it's a display only copy!
		[JsonIgnore]
		public string DisplayName { get { return $"----> {Name} <----"; } set {} }

		public override string ToString()
		{
			return Name;
		}
	}
}