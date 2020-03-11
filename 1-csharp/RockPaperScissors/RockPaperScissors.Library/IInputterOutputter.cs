using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.Library
{
    // interface default access internal
    public interface IInputterOutputter
    {
        // you can't write access modifiers on interface members...
        // because they HAVE to have the same one as their containing type (the interface)

        void Output(string str);
        string Input();
    }
    // we could improve this interface to better follow
    // interface segregation principle
}
