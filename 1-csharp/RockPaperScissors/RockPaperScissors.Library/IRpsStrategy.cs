using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.Library
{
    // among many "design patterns", this is one, called strategy
    // problem: a class that needs some behavior but could accept several specific ones
    // solution: use an interface to abstract that behavior, and pass in some implementation of that interface
    //     (some class instance which implements it)
    public interface IRpsStrategy
    {
        // we can have properties in interfaces
        // this isn't an "auto property with no set"
        // this is "you have to have some property int Successes with _at least_ a public get"
        //int Successes { get; }

        string DecideMove(List<string> previousOutcomes);
    }
}
