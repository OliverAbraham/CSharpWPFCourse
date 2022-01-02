namespace _12_MVVM_concept_with_databinding
{
	/// <summary>
	/// Model of the dialog. Loads and saves the data.n
	/// </summary>
	public class Model : IModel
    {
        private DatabaseTableRow Row;
        
        public DatabaseTableRow Load()
        {
            // Read Row from database
            Row = new DatabaseTableRow();
            Row.DatabaseField1 = "aaa";
            Row.DatabaseField2 = "bbb";
            Row.DatabaseField3 = "ccc";
            return Row;
        }

        public void Save()
        {
            // Store Row into database
        }
    }
}
