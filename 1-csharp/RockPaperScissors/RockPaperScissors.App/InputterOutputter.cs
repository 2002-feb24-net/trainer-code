using RockPaperScissors.Library;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace RockPaperScissors.App
{
    // class (and interface, etc.) default access is "internal"
    // the only access that makes sense is "public" "internal"
    public class InputterOutputter : IInputterOutputter
    {
        public void Output(string str)
        {
            Console.Write(str);
        }

        public string Input()
        {
            return Console.ReadLine();
        }
    }
}
