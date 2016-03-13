namespace TicTacToe
{
    static class AI
    {
        static int ObviousMove(int[,] GameState, int Team)
        {
            for (int i = 0; i <= 2; i++)
            {
                if (GameState[i, 0] == Team && GameState[i, 1] == Team && GameState[i, 2] == (int)Game.Mark.Empty) return (i + 1) * 3; // 3 6 or 9
                if (GameState[i, 0] == Team && GameState[i, 1] == (int)Game.Mark.Empty && GameState[i, 2] == Team) return ((i + 1) * 3) - 1; // 2 5 or 8
                if (GameState[i, 0] == (int)Game.Mark.Empty && GameState[i, 1] == Team && GameState[i, 2] == Team) return ((i + 1) * 3) - 2; // 1 4 or 7
                if (GameState[0, i] == Team && GameState[1, i] == Team && GameState[2, i] == (int)Game.Mark.Empty) return (i + 7); // 7 8 or 9
                if (GameState[0, i] == Team && GameState[1, i] == (int)Game.Mark.Empty && GameState[2, i] == Team) return (i + 4); // 4 5 or 6
                if (GameState[0, i] == (int)Game.Mark.Empty && GameState[1, i] == Team && GameState[2, i] == Team) return (i + 1); // 1 2 or 3
            }

            if (GameState[2, 2] == (int)Game.Mark.Empty && GameState[0, 0] == Team && GameState[1, 1] == Team) return 9; // 9 empty, 1 5 our markers
            if (GameState[1, 1] == (int)Game.Mark.Empty && GameState[0, 0] == Team && GameState[2, 2] == Team) return 5; // 5 empty, 1 9 our markers
            if (GameState[0, 0] == (int)Game.Mark.Empty && GameState[1, 1] == Team && GameState[2, 2] == Team) return 1; // 1 empty, 5 9 our markers

            if (GameState[0, 2] == (int)Game.Mark.Empty && GameState[1, 1] == Team && GameState[2, 0] == Team) return 3; // 3 empty, 5 7 our markers
            if (GameState[1, 1] == (int)Game.Mark.Empty && GameState[0, 2] == Team && GameState[2, 0] == Team) return 5; // 5 empty, 3 7 our markers
            if (GameState[2, 0] == (int)Game.Mark.Empty && GameState[0, 2] == Team && GameState[1, 1] == Team) return 7; // 7 empty, 3 5 our markers

            return 0;
        }
        static int Forks(int[,] GameState, int Team)
        {
            //corner spots first, since we only need to do those once.  see the tic tac toe diagram if the numbers dont make sense.
            if (GameState[0, 0] == (int)Game.Mark.Empty && GameState[0, 2] == (int)Game.Mark.Empty && GameState[2, 0] == (int)Game.Mark.Empty && GameState[0, 1] == Team && GameState[1, 0] == Team) return 1; // 1 3 5 empty, 2 4 our markers
            if (GameState[0, 0] == (int)Game.Mark.Empty && GameState[0, 2] == (int)Game.Mark.Empty && GameState[2, 2] == (int)Game.Mark.Empty && GameState[0, 1] == Team && GameState[1, 2] == Team) return 3; // 1 3 9 empty, 2 6 our markers
            if (GameState[0, 0] == (int)Game.Mark.Empty && GameState[0, 2] == (int)Game.Mark.Empty && GameState[2, 2] == (int)Game.Mark.Empty && GameState[1, 0] == Team && GameState[2, 1] == Team) return 7; // 1 7 9 empty, 4 8 our markers
            if (GameState[0, 2] == (int)Game.Mark.Empty && GameState[2, 0] == (int)Game.Mark.Empty && GameState[2, 2] == (int)Game.Mark.Empty && GameState[1, 2] == Team && GameState[2, 1] == Team) return 9; // 3 7 9 empty, 6 8 our markers

            //now the sides, we need to have the 5 position for any of these to work. 5 is implied as being part of the "our markers" group in the comments.
            if (GameState[1, 1] == Team)
            {
                if (GameState[0, 1] == (int)Game.Mark.Empty && GameState[0, 2] == (int)Game.Mark.Empty && GameState[2, 1] == (int)Game.Mark.Empty && GameState[0, 0] == Team) return 2; // 2 3 8 empty, 1 our markers
                if (GameState[0, 0] == (int)Game.Mark.Empty && GameState[0, 1] == (int)Game.Mark.Empty && GameState[2, 1] == (int)Game.Mark.Empty && GameState[0, 2] == Team) return 2; // 1 2 8 empty, 3 our markers

                if (GameState[0, 0] == (int)Game.Mark.Empty && GameState[1, 0] == (int)Game.Mark.Empty && GameState[1, 2] == (int)Game.Mark.Empty && GameState[2, 0] == Team) return 4; // 1 4 6 empty, 7 our markers
                if (GameState[1, 0] == (int)Game.Mark.Empty && GameState[1, 2] == (int)Game.Mark.Empty && GameState[2, 0] == (int)Game.Mark.Empty && GameState[0, 0] == Team) return 4; // 4 6 7 empty, 1 our markers

                if (GameState[1, 0] == (int)Game.Mark.Empty && GameState[1, 2] == (int)Game.Mark.Empty && GameState[2, 2] == (int)Game.Mark.Empty && GameState[0, 2] == Team) return 6; // 4 6 9 empty, 3 our markers
                if (GameState[0, 2] == (int)Game.Mark.Empty && GameState[1, 0] == (int)Game.Mark.Empty && GameState[1, 2] == (int)Game.Mark.Empty && GameState[2, 2] == Team) return 6; // 3 4 6 empty, 9 our markers

                if (GameState[0, 1] == (int)Game.Mark.Empty && GameState[2, 1] == (int)Game.Mark.Empty && GameState[2, 2] == (int)Game.Mark.Empty && GameState[2, 0] == Team) return 8; // 2 8 9 empty, 7 our markers
                if (GameState[0, 1] == (int)Game.Mark.Empty && GameState[2, 0] == (int)Game.Mark.Empty && GameState[2, 1] == (int)Game.Mark.Empty && GameState[2, 2] == Team) return 8; // 2 7 8 empty, 9 our markers
            }

            //these last ones need 5 to be an option for us, since that will be our return value if we get a hit.
            if (GameState[1,1] == (int)Game.Mark.Empty)
            {
                if (GameState[2, 1] == (int)Game.Mark.Empty && GameState[2, 2] == (int)Game.Mark.Empty && GameState[0, 0] == Team && GameState[0, 1] == Team) return 5; // 8 9 empty, 1 2 our markers
                if (GameState[2, 0] == (int)Game.Mark.Empty && GameState[2, 2] == (int)Game.Mark.Empty && GameState[0, 1] == Team && GameState[0, 2] == Team) return 5; // 7 8 empty, 2 3 our markers
                if (GameState[1, 0] == (int)Game.Mark.Empty && GameState[2, 0] == (int)Game.Mark.Empty && GameState[0, 2] == Team && GameState[1, 2] == Team) return 5; // 4 7 empty, 3 6 our markers
                if (GameState[0, 0] == (int)Game.Mark.Empty && GameState[1, 0] == (int)Game.Mark.Empty && GameState[1, 2] == Team && GameState[2, 2] == Team) return 5; // 1 4 empty, 6 9 our markers
                if (GameState[0, 0] == (int)Game.Mark.Empty && GameState[0, 1] == (int)Game.Mark.Empty && GameState[2, 1] == Team && GameState[2, 2] == Team) return 5; // 1 2 empty, 8 9 our markers
                if (GameState[0, 1] == (int)Game.Mark.Empty && GameState[0, 2] == (int)Game.Mark.Empty && GameState[2, 0] == Team && GameState[2, 1] == Team) return 5; // 2 3 empty, 7 8 our markers
                if (GameState[0, 2] == (int)Game.Mark.Empty && GameState[1, 2] == (int)Game.Mark.Empty && GameState[1, 0] == Team && GameState[2, 0] == Team) return 5; // 3 6 empty, 4 7 our markers
                if (GameState[1, 2] == (int)Game.Mark.Empty && GameState[2, 2] == (int)Game.Mark.Empty && GameState[0, 0] == Team && GameState[1, 0] == Team) return 5; // 6 9 empty, 1 4 our markers

                if (GameState[2, 0] == (int)Game.Mark.Empty && GameState[2, 2] == (int)Game.Mark.Empty && GameState[0, 0] == Team && GameState[0, 2] == Team) return 5; // 7 9 empty, 1 3 our markers
                if (GameState[0, 0] == (int)Game.Mark.Empty && GameState[0, 2] == (int)Game.Mark.Empty && GameState[2, 0] == Team && GameState[2, 2] == Team) return 5; // 1 3 empty, 7 9 our markers
                if (GameState[0, 0] == (int)Game.Mark.Empty && GameState[2, 0] == (int)Game.Mark.Empty && GameState[0, 2] == Team && GameState[2, 2] == Team) return 5; // 1 7 empty, 3 9 our markers
                if (GameState[0, 2] == (int)Game.Mark.Empty && GameState[2, 2] == (int)Game.Mark.Empty && GameState[0, 0] == Team && GameState[2, 0] == Team) return 5; // 3 9 empty, 1 7 our markers
            }

            return 0;
        }
        public static int FindBestMove(int[,] GameState, int EnemyTeamMarker)
        {
            int HumanTeamMarker = Game.GetEnemyTeam(EnemyTeamMarker);
            int TakenCells = 0;
            int CurrentBestMove = 0;
            /* 123
             * 456
             * 789
             */
            // determine which game move

            foreach (int i in GameState)
            {
                if (i != (int)Game.Mark.Empty) TakenCells++;
            }
            if (TakenCells == 0) return 1; // 1 is always the best first move.
            if (TakenCells == 1)
            {
                if (GameState[1, 1] == (int)Game.Mark.Empty) return 5; // 5 is always the best second move if it's available
                return 1;
            }

            // From here on out I'm using the strategy used in Newell and Simon's 1972 Tic Tac Toe program.

            CurrentBestMove = ObviousMove(GameState, EnemyTeamMarker); // Play obvious winning moves
            if (CurrentBestMove != 0) return CurrentBestMove;

            CurrentBestMove = ObviousMove(GameState, HumanTeamMarker); // Block obvious winning opponent moves
            if (CurrentBestMove != 0) return CurrentBestMove;

            CurrentBestMove = Forks(GameState, EnemyTeamMarker); // Looks for ways to create forks
            if (CurrentBestMove != 0) return CurrentBestMove;

            CurrentBestMove = Forks(GameState, HumanTeamMarker); // Looks for fork opportunities to block
            if (CurrentBestMove != 0) return CurrentBestMove;

            if (GameState[1, 1] == (int)Game.Mark.Empty) return 5; // play in the center if it's available

            if (GameState[0, 0] == HumanTeamMarker && GameState[2, 2] == (int)Game.Mark.Empty) return 9; // play in an opposite corner
            if (GameState[0, 2] == HumanTeamMarker && GameState[2, 0] == (int)Game.Mark.Empty) return 7;
            if (GameState[2, 2] == HumanTeamMarker && GameState[0, 0] == (int)Game.Mark.Empty) return 1;
            if (GameState[2, 0] == HumanTeamMarker && GameState[0, 2] == (int)Game.Mark.Empty) return 3;

            if (GameState[2, 2] == (int)Game.Mark.Empty) return 9; // play in an empty corner
            if (GameState[2, 0] == (int)Game.Mark.Empty) return 7;
            if (GameState[0, 0] == (int)Game.Mark.Empty) return 1;
            if (GameState[0, 2] == (int)Game.Mark.Empty) return 3;

            if (GameState[0, 0] == (int)Game.Mark.Empty && GameState[0, 1] == (int)Game.Mark.Empty && GameState[0, 2] == (int)Game.Mark.Empty) return 2; //play in the middle of an empty side
            if (GameState[0, 0] == (int)Game.Mark.Empty && GameState[0, 1] == (int)Game.Mark.Empty && GameState[0, 2] == (int)Game.Mark.Empty) return 4;
            if (GameState[0, 0] == (int)Game.Mark.Empty && GameState[0, 1] == (int)Game.Mark.Empty && GameState[0, 2] == (int)Game.Mark.Empty) return 6;
            if (GameState[2, 0] == (int)Game.Mark.Empty && GameState[2, 1] == (int)Game.Mark.Empty && GameState[2, 2] == (int)Game.Mark.Empty) return 8;

            return 1; // this shouldn't ever be reached.
        }
    }
}
