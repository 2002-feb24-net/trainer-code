using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceMammalCatHuman
{
    class Human : Mammal
    {
/*        public bool     hasFur      = true;
        public int      numLegs     { get; set; }
        public String   breathesWith = "lungs";
        public int  avgHeartRate    { get; set; }*/
       
        /*Add a characteristic specific to humans*/
        public String favColor { get; set; }

        //default constructor
        public Human()
        {

        }

        //override constructor
        public Human(bool hasFur, int numLegs, int ahr, String breathsWith)
        {
            this.hasFur = hasFur;
            this.numLegs = numLegs;
            avgHeartRate = ahr;
            this.breathsWith = breathsWith;
        }

        //override this
        public override String Says()
        {
            return "How YOU doin?";
        }

        /*Add a action specific to humans*/
        public String FavoriteColor()
        {
            return $"My favorite color is {favColor}";
        }
    }
}
