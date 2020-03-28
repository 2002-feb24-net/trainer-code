using System;
using System.Linq;

namespace RestaurantReviews.DataAccess
{
    public static class Mapper
    {
        /// <summary>
        /// Maps an Entity Framework restaurant DAO to a business model,
        /// including all reviews if present.
        /// </summary>
        /// <param name="restaurant">The restaurant DAO.</param>
        /// <returns>The restaurant business model.</returns>
        public static Domain.Model.Restaurant MapRestaurantWithReviews(Model.Restaurant restaurant)
        {
            return new Domain.Model.Restaurant
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Reviews = restaurant.Review.Select(Map).ToList()
            };
        }

        /// <summary>
        /// Maps a restaurant business model to a DAO for Entity Framework,
        /// including all reviews if present.
        /// </summary>
        /// <param name="restaurant">The restaurant business model.</param>
        /// <returns>The restaurant DAO.</returns>
        public static Model.Restaurant MapRestaurantWithReviews(Domain.Model.Restaurant restaurant)
        {
            return new Model.Restaurant
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Review = restaurant.Reviews.Select(Map).ToList()
            };
        }

        /// <summary>
        /// Maps an Entity Framework review DAO to a business model,
        /// not including the restaurant.
        /// </summary>
        /// <param name="restaurant">The review DAO.</param>
        /// <returns>The review business model.</returns>
        public static Domain.Model.Review Map(Model.Review review)
        {
            return new Domain.Model.Review
            {
                Id = review.Id,
                ReviewerName = review.ReviewerName,
                Score = review.Score,
                Text = review.Text
            };
        }

        /// <summary>
        /// Maps a review business model to a DAO for Entity Framework,
        /// not including the restaurant.
        /// </summary>
        /// <param name="review">The review business model.</param>
        /// <returns>The review DAO.</returns>
        public static Model.Review Map(Domain.Model.Review review)
        {
            return new Model.Review
            {
                Id = review.Id,
                ReviewerName = review.ReviewerName,
                Score = review.Score ?? throw new ArgumentException("review score cannot be null.", nameof(review)),
                Text = review.Text
            };
        }
    }
}
