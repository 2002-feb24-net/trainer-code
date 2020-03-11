using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.App
{
    static class RefParam
    {
        static void UseSpecialParams()
        {
            int x = 10;
            SetIntTo50(ref x);
            // x is now 50

            var list = new List<string> { "asdf" };
            ReplaceListWithNull(ref list);
            // now list is actually null
        }

        static void ReplaceListWithNull(ref List<string> theList)
        {
            theList = null;
        }

        static void SetIntTo50(ref int y)
        {
            y = 50;
        }

        static void SetIntTo50ButFail(int y)
        {
            y = 50;
        }
    }
}
