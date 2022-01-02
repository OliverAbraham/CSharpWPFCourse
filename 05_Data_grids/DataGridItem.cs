namespace _05_Data_grids
{
	internal class DataGridItem
	{
		public string ImageName { get; set; }
		public string TextLine1 { get; set; }
		public string TextLine2 { get; set; }

		public DataGridItem(string imageName, string textLine1, string textLine2)
		{
			ImageName = imageName;	
			TextLine1 = textLine1;
			TextLine2 = textLine2;
		}
	}
}