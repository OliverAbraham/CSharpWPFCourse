using System;
using System.Windows;
using System.Windows.Controls;
using TicTacToeEngine;

namespace _18_TicTacToe
{
	/// <summary>
	/// Demo-Programm TIC TAC TOE
	/// Oliver Abraham
	/// mail@oliver-abraham.de
	/// www.oliver-abraham.de
	/// </summary>
	public partial class MainWindow : Window
	{
		#region ------------- Fields --------------------------------------------------------------
		private TicTacToe_DomainLogic _logic;
		#endregion



		#region ------------- Init ----------------------------------------------------------------
        public MainWindow()
        {
            _logic = new TicTacToe_DomainLogic();
            InitializeComponent();
            NewGame();
        }
		#endregion



		#region ------------- Implementation ------------------------------------------------------
        private void NewGame()
        {
            _logic.ResetPlayground();
            DisplayPlayground();
        }

        private void DisplayPlayground()
        {
            Btn1.Content = _logic.Playground[1, 1];
            Btn2.Content = _logic.Playground[1, 2];
            Btn3.Content = _logic.Playground[1, 3];
            Btn4.Content = _logic.Playground[2, 1];
            Btn5.Content = _logic.Playground[2, 2];
            Btn6.Content = _logic.Playground[2, 3];
            Btn7.Content = _logic.Playground[3, 1];
            Btn8.Content = _logic.Playground[3, 2];
            Btn9.Content = _logic.Playground[3, 3];
        }

        private void ButtonX_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            int feld = Convert.ToInt32(b.Tag);
            
            bool fieldIsOccupied = (string)b.Content != " ";
            if (fieldIsOccupied)
                return;

            var result = _logic.PlayerXSetsStoneOnField(feld);
			DisplayPlayground();
            if (result != null)
				GameResult.Content = result;
		}
		#endregion
    }
}
