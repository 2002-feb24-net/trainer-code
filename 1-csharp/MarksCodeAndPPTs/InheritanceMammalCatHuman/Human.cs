using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceMammalCatHuman
{
    class Human
    {
        public bool     hasFur      = true;
        public int      numLegs     { get; set; }
        public String   breathsWith = "lungs";
        public int  avgHeartRate    { get; set; }
        /*Add a characteristic specific to humans*/


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

        /*Add a action specific to humans*/
    }
}
