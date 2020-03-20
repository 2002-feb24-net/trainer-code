using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceMammalCatHuman
{
    class Cat : Mammal
    {
/*        public bool     hasFur       = true;
        public int      numLegs      { get; set; }
        public int      avgHeartRate { get; set; }
        public String   breathsWith  = "lungs";*/
        
        /*Add a characteristic specific to cats*/

        //default constructor
        public Cat()
        {

        }

        //override constructor
        public Cat(bool hasFur, int numLegs, int ahr, String breathsWith)
        {
            this.hasFur = hasFur;
            this.numLegs = numLegs;
            avgHeartRate = ahr;
            this.breathsWith = breathsWith;
        }

        public override String Says()
        {
            return $"meooow fft fft";
        }



        /*Add an action specific to cats*/

    }
}
