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
        IInputterOutputter _io; // filled in by constructor

        List<string> roundResults = new List<string>();

        // constructor
        public RockPaperScissorsGame(IInputterOutputter io)
        {
            _io = io;
            // we're using a principle called dependency inversion here
        }

        // methods
        public void PlayRound()
        {
            int roundNumber = roundResults.Count + 1;

            Output("Round " + roundNumber + ". Enter R, P, or S: ");
            string input = Input();

            var computersMove = DecideMove();

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
            _io.Output(str);
        }

        private string Input()
        {
            return _io.Input();
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

