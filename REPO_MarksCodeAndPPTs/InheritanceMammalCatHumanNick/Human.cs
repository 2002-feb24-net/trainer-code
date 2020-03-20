namespace InheritanceMammalCatHuman
{
    public class Human : Mammal
    {
        public string FavoriteColor { get; set; }

        public Human(int avgHeartRate, string favoriteColor)
            : base(hasFur: false, numLegs: 2, avgHeartRate, breathesWith: "lungs")
        {
            FavoriteColor = favoriteColor;
        }

        public override string Says()
        {
            return "How YOU doin?";
        }
    }
}
