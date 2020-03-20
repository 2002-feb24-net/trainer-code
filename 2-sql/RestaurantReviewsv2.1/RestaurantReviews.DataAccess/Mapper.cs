using System;
using System.Linq;

namespace RestaurantReviews.DataAccess
{
    public static class Mapper
    {
        /// <summary>
        /// Maps an Entity Framework restaurant entity to a business model,
        /// including all reviews if present.
        /// </summary>
        /// <param name="restaurant">The restaurant entity.</param>
        /// <returns>The restaurant business model.</returns>
        public static Library.Models.Restaurant MapRestaurantWithReviews(Entities.Restaurant restaurant)
        {
            return new Library.Models.Restaurant
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Reviews = restaurant.Review.Select(Map).ToList()
            };
        }

        /// <summary>
        /// Maps a restaurant business model to an entity for Entity Framework,
        /// including all reviews if present.
        /// </summary>
        /// <param name="restaurant">The restaurant business model.</param>
        /// <returns>The restaurant entity.</returns>
        public static Entities.Restaurant MapRestaurantWithReviews(Library.Models.Restaurant restaurant)
        {
            return new Entities.Restaurant
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Review = restaurant.Reviews.Select(Map).ToList()
            };
        }

        /// <summary>
        /// Maps an Entity Framework review entity to a business model,
        /// not including the restaurant.
        /// </summary>
        /// <param name="restaurant">The review entity.</param>
        /// <returns>The review business model.</returns>
        public static Library.Models.Review Map(Entities.Review review)
        {
            return new Library.Models.Review
            {
                Id = review.Id,
                ReviewerName = review.ReviewerName,
                Score = review.Score,
                Text = review.Text
            };
        }

        /// <summary>
        /// Maps a review business model to an entity for Entity Framework,
        /// not including the restaurant.
        /// </summary>
        /// <param name="review">The review business model.</param>
        /// <returns>The review entity.</returns>
        public static Entities.Review Map(Library.Models.Review review)
        {
            return new Entities.Review
            {
                Id = review.Id,
                ReviewerName = review.ReviewerName,
                Score = review.Score ?? throw new ArgumentException("review score cannot be null.", nameof(review)),
                Text = review.Text
            };
        }
    }
}
