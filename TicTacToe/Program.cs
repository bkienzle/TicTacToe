using System;

namespace TicTacToe
{
    class Program
    {
        static void Main()
        {
            Player human = new Player();
            Game TicTacToe = new Game();
            human.GetName();
            human.TeamNumber = TicTacToe.GetTeam();
            
            
            while (TicTacToe.IsPlaying)
            {
                TicTacToe.InitializeGameState();
                while (!TicTacToe.IsMatchOver)
                {
                    Console.Clear();
                    human.ShowRecord();
                    TicTacToe.DoTurn(human.TeamNumber);
                    int CurrentGameState = TicTacToe.EvaluateGameState(human.TeamNumber);
                    if (CurrentGameState != (int)Game.TurnResult.Ongoing) {
                        Console.Clear();
                        human.ShowRecord();
                        TicTacToe.DrawBoardState();
                        switch (CurrentGameState)
                        {
                            case (int)Game.TurnResult.Tied:
                                Console.WriteLine("Tied game.");
                                human.TieRecord++;
                                break;
                            case (int)Game.TurnResult.Lost:
                                Console.WriteLine("You lose.");
                                human.LossRecord++;
                                break;
                            case (int)Game.TurnResult.Won:
                                Console.WriteLine("You win.");
                                human.WinRecord++;
                                break;
                            default:
                                break;
                        }
                        TicTacToe.MatchFinished();
                    }
                }
            }
        }
    }
}
