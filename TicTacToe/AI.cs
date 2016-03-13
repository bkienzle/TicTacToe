using System;

namespace TicTacToe
{
    static class AI
    {
        #region Private Variables
        static int[,] GameState;
        #endregion

        #region Public Methods
        public static int FindBestMove(int[,] TempGameState, int EnemyTeamMarker)
        {
            GameState = TempGameState;
            int HumanTeamMarker = Game.GetEnemyTeam(EnemyTeamMarker);
            int TakenCells = 0;
            int CurrentBestMove = 0;
            /* 123
             * 456
             * 789
             */

            foreach (int i in GameState)
            {
                if (i != (int)Game.Mark.Empty) TakenCells++;
            }
            if (TakenCells == 0) return 1; // 1 is always the best first move.
            if (TakenCells == 1)
            {
                if (DoesStateExist("50")) return 5; // 5 is always the best second move if it's available
                return 1; // we have to take the corner otherwise
            }

            // From here on out I'm using the strategy used in Newell and Simon's 1972 Tic Tac Toe program.

            CurrentBestMove = ObviousMove(EnemyTeamMarker.ToString()); // Play obvious winning moves
            if (CurrentBestMove != 0) return CurrentBestMove;

            CurrentBestMove = ObviousMove(HumanTeamMarker.ToString()); // Block obvious winning opponent moves
            if (CurrentBestMove != 0) return CurrentBestMove;

            CurrentBestMove = Forks(EnemyTeamMarker.ToString()); // Looks for ways to create forks
            if (CurrentBestMove != 0) return CurrentBestMove;

            CurrentBestMove = Forks(HumanTeamMarker.ToString()); // Looks for fork opportunities to block
            if (CurrentBestMove != 0) return CurrentBestMove;

            if (DoesStateExist("50")) return 5; // play in the center if it's available

            CurrentBestMove = OppositeCorner(HumanTeamMarker.ToString()); // play in an opposite corner
            if (CurrentBestMove != 0) return CurrentBestMove;

            CurrentBestMove = EmptyCorner(); // play in an empty corner
            if (CurrentBestMove != 0) return CurrentBestMove;

            CurrentBestMove = EmptySide(); // play in the middle of an empty side
            if (CurrentBestMove != 0) return CurrentBestMove;

            return 1; // this shouldn't ever be reached.
        }
        #endregion

        #region Private Methods
        static string TranslatePosition(string Position)
        {
            switch (Position)
            {
                case "1":
                    return "00";
                case "2":
                    return "01";
                case "3":
                    return "02";
                case "4":
                    return "10";
                case "5":
                    return "11";
                case "6":
                    return "12";
                case "7":
                    return "20";
                case "8":
                    return "21";
                default:
                    return "22";
            }
        }
        static bool DoesStateExist(string Evaluate)
        {
            //this is going to take in a string of comma seperated numbers and break them up and test them against the game state to see if all of the statements are true
            //this is most likely more expensive, but it makes the code a lot more readable, imo.

            //instead of something like this:
            //if (GameState[0, 0] == (int)Game.Mark.Empty && GameState[0, 2] == (int)Game.Mark.Empty && GameState[2, 0] == (int)Game.Mark.Empty && GameState[0, 1] == Team && GameState[1, 0] == Team) return 1; // 1 3 5 empty, 2 4 our markers
            //
            //we can just do if (DoesStateExist("10,2t,3t".Replace("t", TeamString))) return 1;

            foreach (string ThisEvaluate in Evaluate.Split(','))
            {
                string xy = TranslatePosition(ThisEvaluate.Substring(0, 1));
                int x = Int32.Parse(xy.Substring(0, 1));
                int y = Int32.Parse(xy.Substring(1, 1));
                int ValueToEvaluateAgainst = Int32.Parse(ThisEvaluate.Substring(1, 1));
                if (GameState[x, y] != ValueToEvaluateAgainst) return false;
            }
            return true;
        }
        static int ObviousMove(string Team)
        {
            // up and down
            for (int i = 0; i <= 2; i++)
            {
                if (DoesStateExist("10,2t,3t".Replace("t", Team))) return 1;
                if (DoesStateExist("20,1t,3t".Replace("t", Team))) return 2;
                if (DoesStateExist("30,1t,2t".Replace("t", Team))) return 3;
                if (DoesStateExist("40,5t,6t".Replace("t", Team))) return 4;
                if (DoesStateExist("50,4t,6t".Replace("t", Team))) return 5;
                if (DoesStateExist("60,4t,5t".Replace("t", Team))) return 6;
                if (DoesStateExist("70,8t,9t".Replace("t", Team))) return 7;
                if (DoesStateExist("80,7t,9t".Replace("t", Team))) return 8;
                if (DoesStateExist("90,7t,8t".Replace("t", Team))) return 9;

                if (DoesStateExist("10,4t,7t".Replace("t", Team))) return 1;
                if (DoesStateExist("20,5t,8t".Replace("t", Team))) return 2;
                if (DoesStateExist("30,6t,9t".Replace("t", Team))) return 3;
                if (DoesStateExist("40,1t,7t".Replace("t", Team))) return 4;
                if (DoesStateExist("50,2t,8t".Replace("t", Team))) return 5;
                if (DoesStateExist("60,3t,9t".Replace("t", Team))) return 6;
                if (DoesStateExist("70,1t,4t".Replace("t", Team))) return 7;
                if (DoesStateExist("80,2t,5t".Replace("t", Team))) return 8;
                if (DoesStateExist("90,3t,6t".Replace("t", Team))) return 9;
            }
            //diagonals
            if (DoesStateExist("90,1t,5t".Replace("t", Team))) return 9;
            if (DoesStateExist("50,1t,9t".Replace("t", Team))) return 5;
            if (DoesStateExist("10,5t,9t".Replace("t", Team))) return 1;
            if (DoesStateExist("30,5t,7t".Replace("t", Team))) return 3;
            if (DoesStateExist("50,3t,7t".Replace("t", Team))) return 5;
            if (DoesStateExist("70,3t,5t".Replace("t", Team))) return 7;

            return 0;
        }
        static int Forks(string Team)
        {
            //corner spots first, since we only need to do those once.
            if (DoesStateExist("10,30,50,2t,4t".Replace("t", Team))) return 1;
            if (DoesStateExist("10,30,90,2t,6t".Replace("t", Team))) return 3;
            if (DoesStateExist("10,70,90,4t,8t".Replace("t", Team))) return 7;
            if (DoesStateExist("30,70,90,6t,8t".Replace("t", Team))) return 9;

            //now the sides, we need to have the 5 position for any of these to work. 5 is implied as being part of the "our markers" group in the comments.
            if (DoesStateExist("5t".Replace("t", Team)))
            {
                if (DoesStateExist("20,30,80,1t".Replace("t", Team))) return 2;
                if (DoesStateExist("10,20,80,3t".Replace("t", Team))) return 2;
                if (DoesStateExist("10,40,60,7t".Replace("t", Team))) return 4;
                if (DoesStateExist("40,60,70,1t".Replace("t", Team))) return 4;
                if (DoesStateExist("40,60,90,3t".Replace("t", Team))) return 6;
                if (DoesStateExist("30,40,60,9t".Replace("t", Team))) return 6;
                if (DoesStateExist("20,80,90,7t".Replace("t", Team))) return 8;
                if (DoesStateExist("20,70,80,9t".Replace("t", Team))) return 8;
            }

            //these last ones need 5 to be an option for us, since that will be our return value if we get a hit.
            if (DoesStateExist("50"))
            {
                if (DoesStateExist("80,90,1t,2t".Replace("t", Team))) return 5;
                if (DoesStateExist("70,80,2t,3t".Replace("t", Team))) return 5;
                if (DoesStateExist("40,70,3t,6t".Replace("t", Team))) return 5;
                if (DoesStateExist("10,40,6t,9t".Replace("t", Team))) return 5;
                if (DoesStateExist("10,20,8t,9t".Replace("t", Team))) return 5;
                if (DoesStateExist("20,30,7t,8t".Replace("t", Team))) return 5;
                if (DoesStateExist("30,60,4t,7t".Replace("t", Team))) return 5;
                if (DoesStateExist("60,90,1t,4t".Replace("t", Team))) return 5;
                if (DoesStateExist("70,90,1t,3t".Replace("t", Team))) return 5;
                if (DoesStateExist("10,30,7t,9t".Replace("t", Team))) return 5;
                if (DoesStateExist("10,70,3t,9t".Replace("t", Team))) return 5;
                if (DoesStateExist("30,90,10,7t".Replace("t", Team))) return 5;
            }

            return 0;
        }
        static int OppositeCorner(string Team)
        {
            if (DoesStateExist("1t,90".Replace("t", Team))) return 9;
            if (DoesStateExist("3t,70".Replace("t", Team))) return 7;
            if (DoesStateExist("9t,10".Replace("t", Team))) return 1;
            if (DoesStateExist("7t,30".Replace("t", Team))) return 3;

            return 0;
        }
        static int EmptyCorner()
        {
            if (DoesStateExist("90")) return 9;
            if (DoesStateExist("70")) return 7;
            if (DoesStateExist("10")) return 1;
            if (DoesStateExist("30")) return 3;

            return 0;
        }
        static int EmptySide()
        {
            if (DoesStateExist("10,20,30")) return 2;
            if (DoesStateExist("10,40,70")) return 4;
            if (DoesStateExist("30,60,90")) return 6;
            if (DoesStateExist("70,80,90")) return 8;

            return 0;
        }
        #endregion
    }
}
