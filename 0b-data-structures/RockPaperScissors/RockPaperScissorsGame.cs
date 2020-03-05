using System;
using System.Collections.Generic;

namespace RockPaperScissors
{
    class RockPaperScissorsGame
    {
        // fields
        // int wins = 0;
        // int losses = 0;
        // int ties = 0;

        List<string> roundResults = new List<string>();

        // methods
        public void PlayRound()
        {
            int roundNumber = roundResults.Count + 1;

            Console.Write("Round " + roundNumber + ". Enter R, P, or S: ");
            string input = Console.ReadLine();

            var computersMove = DecideMove();

            // some people put var literally everywhere


            Console.WriteLine("Computer chose " + computersMove);

            // e.g... a bunch of nested if-else
            // compare input and computersMove
            if (input == computersMove)
            {
                // if the moves are the same, it's a tie
                roundResults.Add("tie");
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
                        roundResults.Add("win");
                        Console.WriteLine("You won.");
                    }
                    else
                    {
                        roundResults.Add("loss");
                        Console.WriteLine("You lose.");
                    }
                }
                else if (input == "P")
                {
                    // if the player said paper
                    if (computersMove == "R")
                    {
                        roundResults.Add("win");
                        Console.WriteLine("You won.");
                    }
                    else
                    {
                        roundResults.Add("loss");
                        Console.WriteLine("You lose.");
                    }
                }
                else
                {
                    // if the player said scissors
                    if (computersMove == "P")
                    {
                        roundResults.Add("win");
                        Console.WriteLine("You won.");
                    }
                    else
                    {
                        roundResults.Add("loss");
                        Console.WriteLine("You lose.");
                    }
                }
            }
        }

        public void PrintSummary()
        {
            // print out the round results list
            foreach (string result in roundResults)
            {
                Console.Write(result + " ");
            }
            Console.WriteLine(); // line break
        }

        string DecideMove()
        {
            if (!roundResults.Contains("loss"))
            {
                return "P";
            }
            return "S";
        }
    }
}
