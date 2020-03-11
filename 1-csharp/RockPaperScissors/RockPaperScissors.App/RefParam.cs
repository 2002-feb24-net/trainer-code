using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.App
{
    static class RefParam
    {
        static void UseSpecialParams()
        {
            // int is a value type
            int x = 10;

            SetIntTo50ButFail(x);
            // x is still 10

            SetIntTo50(ref x);
            // x is now 50

            // List<T> is a reference type.
            var list = new List<string> { "asdf" };
            ReplaceListWithNullButFail(list);
            // list still points to the same list

            ReplaceListWithNull(ref list);
            // now list is actually null

            // the list we created has no more references to it and will eventually
            // be garbage-collected.
        }

        static void SetIntTo50ButFail(int y)
        {
            y = 50;
        }

        static void SetIntTo50(ref int y)
        {
            y = 50;
        }

        static void ReplaceListWithNullButFail(List<string> theList)
        {
            theList = null;
            // theList is its own variable, separate from any other method
            // here we change it so it doesn't reference the initial list anymore,
            // but that doesn't change any other variable that might be referencing that list.

            // so even though List is a reference type, two separate variables
            // are still two separate variables.
        }

        static void ReplaceListWithNull(ref List<string> theList)
        {
            theList = null;
            // since we're using ref, reassigning theList also reassigns the
            // outside variable that was passed in.
        }
    }
}
