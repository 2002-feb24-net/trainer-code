using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceMammalCatHuman
{
    /*add the modifier so that this class won't be instantiated*/ 
    class Mammal
    {
        public bool     hasFur       = true;
        public int      numLegs      { get; set; }
        public int      avgHeartRate { get; set; }
        public String   breathsWith  = "lungs";

        //default constructor
        public Mammal()
        {

        }

        //parameterized override constructor
        public Mammal(/*set the four fields*/)
        {

        }

        public String Says()
        {
            /*what does the animal say?*/
        }

        public void GetAvgHeartRate()
        {
            /*how many beats per minute?*/

        }




    }
}
