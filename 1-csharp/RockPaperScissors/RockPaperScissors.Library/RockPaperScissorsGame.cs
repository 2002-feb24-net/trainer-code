 using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.Library
{
    public class RockPaperScissorsGame
    {
        // fields
        // int wins = 0;
        // int losses = 0;
        // int ties = 0;

        // we use interface types to allow for flexibility in our code
        // "i need some input and output but i don't care how
        readonly IInputter _input; // filled in by constructor
        readonly IOutputter _output; // filled in by constructor
        readonly IRpsStrategy _strategy;

        // an event is a special kind of member which supports "publish/subscribe" workflow
        // now that i've declared this event... anyone can subscribe to it.
        // whenever the event gets "published", all the subscribers get called as methods.
        // this class will fire this Log event whenever it wants to log...
        //     but the Program class will subscribe to it, thereby deciding HOW/WHERE to log specifically.

            // because this event's type is "Action<string>", when the event is fired/published,
            //   it always sends a string along with it, which the subscribers get as a parameter.
        public event Action<string> Log;

        List<string> roundResults = new List<string>();

        // constructor
        public RockPaperScissorsGame(IInputter i, IOutputter o,  IRpsStrategy strategy)
        {
            _input = i;
            _output = o;
            _strategy = strategy;
            // we're using a principle called dependency inversion here

            // the specific way we're doing that
            // is called dependency injection
            //   as opposed to going "new RandomStrategy()" right here,
            //   i can get someone else to inject the dependency to me
               //   (as a parameter, which is what i'm doing here)
        }

        // methods
        public void PlayRound()
        {
            int roundNumber = roundResults.Count + 1;

            string input;
            do
            {
                Output("Round " + roundNumber + ". Enter R, P, or S: ");
                input = Input();
                if (input == "R" || input == "P" || input == "S")
                {
                    break;
                }
                Output("Invalid input, try again."); // notify the user of errors

                // fire the Log event, with this string (being the info we want to log somewhere)
                // what code runs here depends entirely on who has subscribed to the event.
                Log?.Invoke($"User typed invalid input {input}");

                // there is an awkwardness to events; if there are no subscribers when you fire it, it throws null exception.
            } while (true);

            var computersMove = _strategy.DecideMove(roundResults);

            // some people put var literally everywhere


            Output("Computer chose " + computersMove + "\n");

            // e.g... a bunch of nested if-else
            // compare input and computersMove
            if (input == computersMove)
            {
                // if the moves are the same, it's a tie
                roundResults.Add("tie");
                Output("Tie game.\n");
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
                        Output("You won.\n");
                    }
                    else
                    {
                        roundResults.Add("loss");
                        Output("You lose.\n");
                    }
                }
                else if (input == "P")
                {
                    // if the player said paper
                    if (computersMove == "R")
                    {
                        roundResults.Add("win");
                        Output("You won.\n");
                    }
                    else
                    {
                        roundResults.Add("loss");
                        Output("You lose.\n");
                    }
                }
                else
                {
                    // if the player said scissors
                    if (computersMove == "P")
                    {
                        roundResults.Add("win");
                        Output("You won.\n");
                    }
                    else
                    {
                        roundResults.Add("loss");
                        Output("You lose.\n");
                    }
                }
            }
        }

        private void Output(string str)
        {
            _output.Output(str);
        }

        private string Input()
        {
            return _input.Input();
        }

        public void PrintSummary()
        {
            // print out the round results list
            string output = "";
            foreach (string result in roundResults)
            {
                output += result + " ";
            }
            output += "\n"; // line break
            Output(output);
        }

        // exercise:
        // make a IRpsStrategy interface in this project
        // which can Decide a Move.
        // (if you want, use a round results parameter)

        // modify this class to use some implementation of that interface,
        // just like how now it uses some implementation of IInputterOutputter for I/O.

        // write two classes that each implement that strategy interface
        // for two different strategies.

        // in the Program class, instantiate one of your strategies and pass it to the game

        // extra: ask the user which strategy he wants to play against and create the corresponding object.

    }
}
