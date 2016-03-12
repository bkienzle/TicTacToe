using System;

namespace TicTacToe
{
    class Program
    {
        static void Main()
        {
            Player player = new Player();
            Game TicTacToe = new Game();
            player.GetName();
            player.TeamNumber = TicTacToe.GetTeam();

            while (TicTacToe.IsPlaying)
            {
                Console.Clear();
                player.ShowRecord();
                TicTacToe.PlayerTurn(player.TeamNumber);
            }

            Console.ReadKey();
        }
    }
}
