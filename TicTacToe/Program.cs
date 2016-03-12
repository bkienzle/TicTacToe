using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            player.GetName();
            player.ShowRecord();
            Game TicTacToe = new Game();
            TicTacToe.DrawBoardState();

            Console.ReadKey();
        }
    }
}
