namespace InheritanceMammalCatHuman
{
    public abstract class Mammal
    {
        public bool HasFur { get; }
        public int NumLegs { get; set; }
        public int AvgHeartRate { get; set; }
        public string BreathsWith { get; } = "lungs";

        public Mammal(bool hasFur, int numLegs, int avgHeartRate, string breathesWith)
        {
            HasFur = hasFur;
            NumLegs = numLegs;
            AvgHeartRate = avgHeartRate;
            BreathsWith = breathesWith;
        }

        public abstract string Says();
    }
}
