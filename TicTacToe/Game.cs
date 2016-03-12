using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Game
    {
        enum CellState
        {
            Empty = 0,
            X = 1,
            O = 2,
        }
        public int[,] GameState = new int[3, 3];
        public bool IsPlaying = true;

        string GetCellString(int CellValue)
        {
            switch (CellValue)
            {
                case (int)CellState.X:
                    return " X ";
                case (int)CellState.O:
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
                Result.Append(GetCellString(GameState[Row, ThisCol]));
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
        }
        public void PlayerTurn()
        {

        }
    }
}
