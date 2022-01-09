using _12_MVVM_businesslogic;
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
        [TestMethod]
        public void Should_init_all_controls_correctly()
        {
            // ARRANGE
            var m = CreateModelMock();


            // ACT
            var sut = new ViewModel(m);


            // ASSERT
            sut.CurrentPerson.FirstName.Should().Be("Ludwig");
            sut.CurrentPerson.LastName.Should().Be("van Beethoven");
            sut.CurrentPerson.IsMusician.Should().BeTrue();
            sut.CurrentPerson.Instrument.Should().Be("Piano");
        }

        [TestMethod]
        public void Should_enable_entryfield_when_user_checks_the_checkbox()
        {
            // ARRANGE
            var m = CreateModelMock();
            var sut = new ViewModel(m);


            // ACT
            sut.IsMusician_ViewModel = true;


            // ASSERT
            sut.TextBox_Instrument_IsEnabled.Should().BeTrue();
        }

        [TestMethod]
        public void Should_disable_entryfield_when_user_unchecks_the_checkbox()
        {
            // ARRANGE
            var m = CreateModelMock();
            var sut = new ViewModel(m);


            // ACT
            sut.IsMusician_ViewModel = false;


            // ASSERT
            sut.TextBox_Instrument_IsEnabled.Should().BeFalse();
        }

        [TestMethod]
        public void Should_save_when_user_presses_the_savebutton()
        {
            // ARRANGE
            var m = CreateModelMock();
            var sut = new ViewModel(m);


            // ACT
            sut.Save_Command.Execute(null);


            // ASSERT
            sut.DataWasSaved.Should().BeTrue();
        }


        private Model CreateModelMock()
		{
            return new Model()
            {
                FirstName = "Ludwig",
                LastName = "van Beethoven",
                IsMusician = true,
                Instrument = "Piano"
            };
		}
	}
}