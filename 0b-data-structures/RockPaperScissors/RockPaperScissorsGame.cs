using System;

namespace RockPaperScissors
{
    class RockPaperScissorsGame
    {
        // fields
        int wins = 0;
        int losses = 0;
        int ties = 0;

        // methods
        public void PlayRound()
        {
            int roundNumber = wins + losses + ties + 1;

            Console.Write("Round " + roundNumber + ". Enter R, P, or S: ");
            string input = Console.ReadLine();

            string computersMove = DecideMove();

            // e.g... a bunch of nested if-else
            // compare input and computersMove
        }

        public void PrintSummary()
        {
            // ...
        }

        string DecideMove()
        {
            if (losses == 0)
            {
                return "P";
            }
            return "S";
        }
    }
}
