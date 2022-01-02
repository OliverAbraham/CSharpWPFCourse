using _12_MVVM_concept_with_databinding;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _12_MVVM_concept_unit_tests
{




    // IMPORTANT:
    // To compile this, add the nuget package "FluentAssertions" !





	/// <summary>
	/// The goal is to test the ViewModel standalone, with no View and no real Model
	/// </summary>
	[TestClass]
	public class ViewModel_Tests
	{
        private DummyModel _M;
        private ViewModel _Sut;

        private void Setup()
        {
            _M = new DummyModel();
            _Sut = new ViewModel(_M);
        }

        /// <summary>
        /// Prüft, ob die Controls richtig mit den Werten aus der Datenbank initialisiert werden
        /// </summary>
        [TestMethod]
        public void Init_Test()
        {
            Setup();

            _Sut.InitDialog();

            _Sut.TextBox1.Should().Be("a");
            _Sut.TextBox2.Should().Be("b");
            _Sut.CheckBox1_IsChecked.Should().BeFalse();
            _Sut.TextBox3.Should().Be("c");
        }

        /// <summary>
        /// Wenn der Anwender die Checkbox anhakt, soll das Eingabefeld disabled werden.
        /// </summary>
        [TestMethod]
        public void Checkbox_Test1()
        {
            Setup();

            _Sut.InitDialog();

            _Sut.CheckBox1_IsChecked = true;
            _Sut.CheckBox_Checked();
            _Sut.TextBox3_IsEnabled.Should().BeFalse();
        }

        /// <summary>
        /// Wenn der Anwender die Checkbox abhakt, soll das Eingabefeld wieder enabled werden.
        /// </summary>
        [TestMethod]
        public void Checkbox_Test2()
        {
            Setup();

            _Sut.InitDialog();

            _Sut.CheckBox1_IsChecked = false;
            _Sut.CheckBox_Checked();
            _Sut.TextBox3_IsEnabled.Should().BeTrue();
        }

        /// <summary>
        /// Wenn der Anwender den Save-Button drückt, sollen die Daten abgespeichert werden.
        /// </summary>
        [TestMethod]
        public void Save_Button_Test()
        {
            Setup();

            _Sut.Save();

            _M.Save_Method_Called.Should().BeTrue();
        }

        private class DummyModel : IModel
        {
            public bool Save_Method_Called = false;
            public DatabaseTableRow Load()
            {
                // Testdaten bereitstellen
                var Row = new DatabaseTableRow();
                Row.DatabaseField1 = "a";
                Row.DatabaseField2 = "b";
                Row.DatabaseField3 = "c";
                return Row;
            }

            public void Save()
            {
                Save_Method_Called = true;
            }
		}
	}
}