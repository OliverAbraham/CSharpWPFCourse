namespace _12_MVVM_concept_with_databinding
{
	public interface IModel
    {
        DatabaseTableRow Load();
        void Save();
    }
}
