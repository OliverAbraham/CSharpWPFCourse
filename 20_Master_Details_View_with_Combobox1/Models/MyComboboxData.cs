using System.Collections.ObjectModel;
using System.Linq;

namespace _20_Master_Details_View_with_Combobox1
{
	/// <summary>
	/// Of course you will rename this class to the domain name!
	/// </summary>
	public class MyComboboxData
	{
		#region ------------- Properties ----------------------------------------------------------
		public ObservableCollection<MyRow> Rows { get; set; }
		public MyRow CurrentRow { get; set; }
		#endregion



		#region ------------- Fields --------------------------------------------------------------
		#endregion



		#region ------------- Init ----------------------------------------------------------------
		public MyComboboxData()
		{
			Rows = new ObservableCollection<MyRow>();
		}

		public MyComboboxData(string defaultName)
		{
			Rows = new ObservableCollection<MyRow>();
			Rows.Add(new MyRow() { Name = defaultName });
			CurrentRow = Rows[0];
		}
		#endregion



		#region ------------- Methods -------------------------------------------------------------
		public bool Validate(MyRow newRow, out string errorMessages)
		{
            var nameOfNewRowDoesntExistSoFar = !Rows.Any(x => x.Name == newRow.Name);

			if (nameOfNewRowDoesntExistSoFar)
				errorMessages = $"OK";
			else
				errorMessages = $"This name already exists. Please choose a different one.";

			return nameOfNewRowDoesntExistSoFar;
		}

		public bool CurrentRowCanBeDeleted(out string errorMessages)
		{
			var thereIsMoreThanOneRowLeft = Rows.Count > 1;

			if (thereIsMoreThanOneRowLeft)
				errorMessages = "OK";
			else
				errorMessages = "The last row cannot be deleted";

			return thereIsMoreThanOneRowLeft;
		}

		internal void AddNewRow(MyRow newRow)
		{
            Rows.Add(newRow);
		}

		internal void RemoveRow(MyRow currentSet)
		{
            Rows.Remove(currentSet);
		}
		#endregion
	}
}
