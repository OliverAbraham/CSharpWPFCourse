namespace _07_Data_grids_for_editing
{
	internal class DataGridItem
	{
		public bool   Done { get; set; }
		public string DoneDescription { get { return Done ? "yeah" : "nope";  } set { } }
		public string Item { get; set; }
		public string Comment { get; set; }
		public decimal Price { get; set; }

		public DataGridItem(bool done, string item, string comment, decimal price)
		{
			Done = done;	
			Item = item;
			Comment = comment;
			Price = price;
		}
	}
}