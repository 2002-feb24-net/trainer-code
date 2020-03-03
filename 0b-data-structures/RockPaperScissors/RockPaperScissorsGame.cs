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
            Console.WriteLine("Computer chose " + computersMove);

            // e.g... a bunch of nested if-else
            // compare input and computersMove
            if (input == computersMove)
            {
                // if the moves are the same, it's a tie
                ties++;
                Console.WriteLine("Tie game.");
            }
            else
            {
                // otherwise, it's either a player win or a player loss.
                if (input == "R")
                {
                    // if the player said rock, the computer either said scissors or paper.
                    if (computersMove == "S")
                    {
                        wins++;
                        Console.WriteLine("You won.");
                    }
                    else
                    {
                        losses++;
                        Console.WriteLine("You lose.");
                    }
                }
                else if (input == "P")
                {
                    // if the player said paper
                    // ...
                }
                else
                {
                    // if the player said scissors
                    // ...
                }
            }
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
