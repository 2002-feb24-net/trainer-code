using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceMammalCatHuman
{
    class Cat
    {
        public bool     hasFur       = true;
        public int      numLegs      { get; set; }
        public int      avgHeartRate { get; set; }
        public String   breathsWith  = "lungs";
        /*Add a characteristic specific to cats*/

        //default constructor
        public Mammal()
        {

        }

        //override constructor
        public Mammal(/*set the four fields*/)
        {

        }

        public String Says()
        {
            /*what does the amimal say?*/
        }

        public void GetAvgHeartRate()
        {
            /*how many beats per minute?*/

        }

        /*Add an action specific to cats*/

    }
}
