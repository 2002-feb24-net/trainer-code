using System.Collections.Generic;

namespace RestaurantReviews.DataAccess.Entities
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            Review = new HashSet<Review>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Review> Review { get; set; }
    }
}
