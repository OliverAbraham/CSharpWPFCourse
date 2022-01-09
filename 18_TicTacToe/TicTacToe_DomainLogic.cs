namespace TicTacToeEngine
{
	public class TicTacToe_DomainLogic
	{
		#region ------------- Properties ----------------------------------------------------------
		public string[,] Playground = new string[4, 4];
		#endregion



		#region ------------- Methods -------------------------------------------------------------
        public void ResetPlayground()
        {
            for (int row = 1; row <= 3; row++)
                for (int column = 1; column <= 3; column++)
                    Playground[row, column] = " ";
        }
        
		public string PlayerXSetsStoneOnField(int button)
		{
			SetStone(button);
			MakeReturn();
			
            if (PlayerHasWon("X"))
				return "X has won !";
			else if (PlayerHasWon("O"))
				return "O has won !";
            else
                return null;
		}
		#endregion



		#region ------------- Implementation ------------------------------------------------------
		private void SetStone(int button)
        {
            switch (button)
			{
                case 1: Playground[1, 1] = "X"; break;
                case 2: Playground[1, 2] = "X"; break;
                case 3: Playground[1, 3] = "X"; break;
                case 4: Playground[2, 1] = "X"; break;
                case 5: Playground[2, 2] = "X"; break;
                case 6: Playground[2, 3] = "X"; break;
                case 7: Playground[3, 1] = "X"; break;
                case 8: Playground[3, 2] = "X"; break;
                case 9: Playground[3, 3] = "X"; break;
			}
        }

        private void MakeReturn()
        {
            for (int row = 1; row <= 3; row++)
            {
                for (int column = 1; column <= 3; column++)
                {
                    if (Playground[row, column] == " ")
                    {
                        Playground[row, column] = "O";
                        return;
                    }
                }
            }
        }

        private bool PlayerHasWon(string player)
        {
            return (Won_horizontal(1, player) ||
                    Won_horizontal(2, player) ||
                    Won_horizontal(3, player) ||
                    Won_vertical  (1, player) ||
                    Won_vertical  (2, player) ||
                    Won_vertical  (3, player) ||
                    Won_diagonal1 (   player) ||
                    Won_diagonal2 (   player));
        }

        private bool Won_horizontal(int row, string player)
        {
            for (int column = 1; column <= 3; column++)
                if (Playground[row, column] != player)
                    return false;
            return true;
        }

        private bool Won_vertical(int column, string player)
        {
            for (int row = 1; row <= 3; row++)
                if (Playground[row, column] != player)
                    return false;
            return true;
        }

        private bool Won_diagonal1(string player)
        {
            for (int index = 1; index <= 3; index++)
                if (Playground[index, index] != player)
                    return false;
            return true;
        }

        private bool Won_diagonal2(string player)
        {
            for (int index = 1; index <= 3; index++)
                if (Playground[index, 4-index] != player)
                    return false;
            return true;
        }
		#endregion
    }
}
