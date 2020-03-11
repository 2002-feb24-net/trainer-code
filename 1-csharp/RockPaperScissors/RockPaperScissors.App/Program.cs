using RockPaperScissors.Library;
using System;

namespace RockPaperScissors.App
{
    class Program
    {
        static void Main(string[] args)
        {
            InputterOutputter inputOutputSpecific = new InputterOutputter();
            IInputterOutputter inputOutputGeneral = inputOutputSpecific; // this is called upcasting
            var game = new RockPaperScissorsGame(inputOutputGeneral);

            bool readyToQuit = false;

            while (!readyToQuit)
            {
                Console.Write("Do you want to play a round? (y/n)");
                var input = Console.ReadLine();

                if (input == "n")
                {
                    readyToQuit = true;
                }
                else
                {
                    game.PlayRound();
                    // that method should play a round and print the result.
                }
            }

            game.PrintSummary();
            // that method should print out a summary of the rounds.
            // (how many wins, how many losses)
        }
    }
}
