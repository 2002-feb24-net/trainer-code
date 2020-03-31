using System;
using System.Collections.Generic;

namespace RestaurantReviews.DataAccess.Model
{
    public partial class Review
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public string ReviewerName { get; set; }
        public int Score { get; set; }
        public string Text { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}
