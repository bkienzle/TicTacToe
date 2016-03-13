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
        public enum TurnResult
        {
            Ongoing,
            Won,
            Lost,
            Tied,
        }
        public int[,] GameState = new int[3, 3];
        public bool IsPlaying = true;
        public bool IsPlayersTurn { get; set; }
        public bool IsMatchOver { get; set; }

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
        public void InitializeGameState()
        {
            IsMatchOver = false;
            if (HasWonCoinToss()) IsPlayersTurn = true;
            for (int x = 0; x <= 2; x++)
            {
                for (int y = 0; y <= 2; y++)
                {
                    GameState[x, y] = (int)Mark.Empty;
                }
            }
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
        int GetGameStateCellValue(int Position)
        {
            return GameState[((Position - 1) / 3), ((Position - 1) % 3)];
        }
        void SetGameStateCellValue(int Position, int CellValue)
        {
            if (IsPositionValid(Position)) GameState[((Position - 1) / 3), ((Position - 1) % 3)] = CellValue;
        }
        bool IsPositionValid(int Position)
        {
            if (Position != 0 && GetGameStateCellValue(Position) == (int)Mark.Empty) return true;
            return false;
        }
        public void DoTurn(int Team)
        {
            if (IsPlayersTurn)
            {
                DrawBoardState();
                Console.Write("Please select a cell to place your{0}in: ", MarkValueToString(Team).ToString());
                char UserChoice = Console.ReadKey().KeyChar;
                if (Char.IsDigit(UserChoice)) SetGameStateCellValue(int.Parse(UserChoice.ToString()), Team);
                IsPlayersTurn = false;
            }
            else
            {
                ComputerTurn(GetEnemyTeam(Team));
                IsPlayersTurn = true;
            }
        }
        public int GetTeam()
        {
            Console.Write("Please pick your mark, X (default) or O: ");
            string Team = Console.ReadKey().KeyChar.ToString();
            if (Team.ToLower() == "o") return (int)Mark.O;
            return (int)Mark.X;
        }
        int GetEnemyTeam(int Team)
        {
            if (Team == (int)Mark.X) return (int)Mark.O;
            return (int)Mark.X;
        }
        bool IsGameWon(int Team)
        {
            for (int i = 0; i <= 2; i++)
            {
                if (GameState[i, 0] == Team && GameState[i, 1] == Team && GameState[i, 2] == Team) return true;
                if (GameState[0, i] == Team && GameState[1, i] == Team && GameState[2, i] == Team) return true;
            }
            if (GameState[0, 0] == Team && GameState[1, 1] == Team && GameState[2, 2] == Team) return true;
            if (GameState[0, 2] == Team && GameState[1, 1] == Team && GameState[2, 0] == Team) return true;
            return false;
        }
        bool IsTie()
        {
            foreach(int CurrentCell in GameState)
            {
                if (CurrentCell == (int)Mark.Empty) return false;
            }
            return true;
        }
        public int EvaluateGameState(int Team)
        {
            if (IsGameWon(Team)) return (int)TurnResult.Won;
            if (IsGameWon(GetEnemyTeam(Team))) return (int)TurnResult.Lost;
            if (IsTie()) return (int)TurnResult.Tied;
            return (int)TurnResult.Ongoing;
        }
        public void MatchFinished()
        {
            IsMatchOver = true;
            Console.WriteLine();
            Console.Write("Play Again? ");
            if (Console.ReadKey().KeyChar.ToString().ToLower() == "n")
            {
                IsPlaying = false;
            }
        }
        void ComputerTurn(int EnemyTeam)
        {

        }
    }
}
