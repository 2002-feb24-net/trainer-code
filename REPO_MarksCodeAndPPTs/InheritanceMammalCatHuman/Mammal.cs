using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceMammalCatHuman
{
    /*add the modifier so that this class won't be instantiated*/ 
    public abstract class Mammal
    {
        public bool     hasFur       = true;
        public int      numLegs      { get; set; }
        public int      avgHeartRate { get; set; }
        public String   breathsWith  = "lungs";

        //default constructor
        public Mammal()
        {

        }

        //parameterized overloaded constructor
        public Mammal(bool hasFur, int numLegs, int ahr, String breathsWith)
        {
            this.hasFur = hasFur;
            this.numLegs = numLegs;
            avgHeartRate = ahr;
            this.breathsWith = breathsWith;
        }

        //overtride this
        public abstract String Says();

        public int GetAvgHeartRate()
        {
            return avgHeartRate; 
        }




    }
}
