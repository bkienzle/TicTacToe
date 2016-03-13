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
                if (TicTacToe.HasWonCoinToss()) TicTacToe.IsPlayersTurn = true;
                while (!TicTacToe.IsMatchOver)
                {
                    Console.Clear();
                    human.ShowRecord();
                    TicTacToe.DoTurn(human.TeamNumber);
                    int CurrentGameState = TicTacToe.EvaluateGameState();
                    if (CurrentGameState != (int)Game.TurnResult.Ongoing) {
                        switch (CurrentGameState)
                        {
                            case (int)Game.TurnResult.Tied:
                                human.TieRecord++;
                                break;
                            case (int)Game.TurnResult.Lost:
                                human.LossRecord++;
                                break;
                            case (int)Game.TurnResult.Won:
                                human.WinRecord++;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
