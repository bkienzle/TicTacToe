using System;
using System.Text;

namespace TicTacToe
{
    class Game
    {
        enum Mark
        {
            Empty = 0,
            X = 1,
            O = 2,
        }
        public int[,] GameState = new int[3, 3];
        public bool IsPlaying = true;
        public bool IsPlayersTurn { get; set; }

        string MarkValueToString(int CellValue)
        {
            switch (CellValue)
            {
                case (int)Mark.X:
                    return " X ";
                case (int)Mark.O:
                    return " O ";
                default:
                    return "   ";
            }
        }

        public bool HasWonCoinToss()
        {
            Random rand = new Random();
            if (rand.Next(0, 2) == 0) return false;
            return true;
        }
        string DrawRow(int Row)
        {
            StringBuilder Result = new StringBuilder();

            for (int ThisCol = 0; ThisCol < 3; ThisCol++)
            {
                Result.Append(MarkValueToString(GameState[Row, ThisCol]));
            }
            Result.Insert(6, "|");
            Result.Insert(3, "|");
            Result.Insert(0, " ", 15);
            return Result.ToString();
        }
        public void DrawBoardState()
        {
            Console.WriteLine();
            Console.WriteLine(new string(' ',15) + "Board State" + new string(' ', 15) + "Cell Numbers");
            Console.WriteLine();
            for (int ThisRow = 0; ThisRow < 3; ThisRow++)
            {
                Console.WriteLine(DrawRow(ThisRow) + new string(' ', 15) + " {0} | {1} | {2} ", ((ThisRow * 3) + 1).ToString(), ((ThisRow * 3) + 2).ToString(), ((ThisRow * 3) + 3).ToString());
                if (ThisRow == 0 | ThisRow == 1) Console.WriteLine(new String(' ', 15) + "---+---+---" + new string(' ', 15) + "---+---+---");
            }
            Console.WriteLine();
        }
        public int GetGameStateCellValue(int Position)
        {
            return GameState[((Position - 1) / 3), ((Position - 1) % 3)];
        }
        public void SetGameStateCellValue(int Position, int CellValue)
        {
            GameState[((Position - 1) / 3), ((Position - 1) % 3)] = CellValue;
        }
        public bool IsPositionValid(int Position)
        {
            if (Position != 0 && GetGameStateCellValue(Position) == (int)Mark.Empty) return true;
            return false;
        }
        public void PlaceMark(int Position, int Team)
        {
            if (IsPositionValid(Position)) SetGameStateCellValue(Position, Team);
        }
        public void PlayerTurn(int Team)
        {
            DrawBoardState();
            Console.Write("Please select a cell to place your{0}in: ", MarkValueToString(Team).ToString());
            char UserChoice = Console.ReadKey().KeyChar;
            if (Char.IsDigit(UserChoice))PlaceMark(int.Parse(UserChoice.ToString()), Team);
        }
        public int GetTeam()
        {
            Console.Write("Please pick your mark, X (default) or O: ");
            string Team = Console.ReadKey().KeyChar.ToString();
            if (Team.ToLower() == "o") return (int)Mark.O;
            return (int)Mark.X;
        }
    }
}
