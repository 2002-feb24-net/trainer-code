using RockPaperScissors.Library;
using System;
using System.IO;

namespace RockPaperScissors.App
{
    class Program
    {
        // logging
        // input validation, exception handling, unit testing

        // because sometimes we only care about errors, other times we want lots of extra info
        // for this reason we use different log levels: Critical, Error, Warning, Information, Debug, Trace

        // i'll implemented some logging for this solution
        // we'll use something called "events" to do it, but in real life,
        //  everyone uses some third-party logging library e.g. Serilog, NLog

        static void Main(string[] args)
        {
            InputterOutputter inputOutputSpecific = new InputterOutputter();
            IInputterOutputter inputOutputGeneral = inputOutputSpecific; // this is called upcasting
            var game = new RockPaperScissorsGame(inputOutputGeneral, inputOutputGeneral, new RandomStrategy());

            // subscribing to the event with a lambda expression
            // (which has to match the parameters defined by the event)
            //game.Log += s => Console.WriteLine(s);

            // subscribe with a method name
            game.Log += LogToConsole;
            game.Log += LogToFile;

            // unsubscribe
            //game.Log -= LogToConsole;

            //var game = new RockPaperScissorsGame(inputOutputGeneral, new SomeOtherStrategy());

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

        static void LogToConsole(string str)
        {
            Console.WriteLine(str);
        }

        static void LogToFile(string str)
        {
            var filePath = $"../../../{DateTime.Today:yyyy-M-dd--HH-mm-ss}.log";
            Console.WriteLine(filePath);

            File.AppendAllText(filePath, str);
        }
    }
}
