namespace InheritanceMammalCatHuman
{
    public class Cat : Mammal
    {
        public Cat(int avgHeartRate)
            : base(hasFur: true, numLegs: 4, avgHeartRate: avgHeartRate, "lungs")
        {
        }

        public override string Says()
        {
            return "Meow";
        }
    }
}
