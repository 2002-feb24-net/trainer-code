using System; // fixes the "error" of typing just "Console" and not "System.Console"

namespace DemoObject
{
    class Product
    {
        string ProductId;
        int Stock;
        double StarRating;

        public void SetDefaultValues()
        {
            ProductId = "1";
            Stock = 0;
            StarRating = 5;
        }

        public void SetValues(string id, int quantity, double rating)
        {
            // business logic like "no product can have more than 50 quantity"
            // belongs in the classes that represent those entities.
            // not in input/output code.
            if (quantity > 50)
            {
                Console.WriteLine("Error! too much quantity");
            }
            if (quantity < 0)
            {
                Console.WriteLine("Error - can't have negative quantity");
            }

            ProductId = id;
            Stock = quantity;
            StarRating = rating;
        }

        public override string ToString()
        {
            return "product " + ProductId + ", "
                + Stock + " in stock, " + StarRating + " star rating";
        }
    }
}
