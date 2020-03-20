using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NLog;
using RestaurantReviews.DataAccess.Entities;
using RestaurantReviews.Library.Interfaces;

namespace RestaurantReviews.DataAccess.Repositories
{
    /// <summary>
    /// A repository managing data access for restaurant objects and their review members,
    /// using Entity Framework.
    /// </summary>
    /// <remarks>
    /// This class ought to have better exception handling and logging.
    /// </remarks>
    public class RestaurantRepository : IRestaurantRepository, IDisposable
    {
        private readonly RestaurantReviewsDbContext _dbContext;

        private static readonly ILogger s_logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initializes a new restaurant repository given a suitable restaurant data source.
        /// </summary>
        /// <param name="dbContext">The data source</param>
        public RestaurantRepository(RestaurantReviewsDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Get all restaurants with deferred execution,
        /// including associated reviews.
        /// </summary>
        /// <returns>The collection of restaurants</returns>
        public IEnumerable<Library.Models.Restaurant> GetRestaurants(string search = null)
        {
            // disable unnecessary tracking for performance benefit
            IQueryable<Restaurant> items = _dbContext.Restaurant
                .Include(r => r.Review).AsNoTracking();
            if (search != null)
            {
                items = items.Where(r => r.Name.Contains(search));
            }
            return items.Select(Mapper.MapRestaurantWithReviews);
        }

        /// <summary>
        /// Get a restaurant by ID.
        /// </summary>
        /// <returns>The restaurant</returns>
        public Library.Models.Restaurant GetRestaurantById(int id)
        {
            return Mapper.MapRestaurantWithReviews(_dbContext.Restaurant.Find(id));
        }

        /// <summary>
        /// Add a restaurant, including any associated reviews.
        /// </summary>
        /// <param name="restaurant">The restaurant</param>
        public void AddRestaurant(Library.Models.Restaurant restaurant)
        {
            if (restaurant.Id != 0)
            {
                s_logger.Warn($"Restaurant to be added has an ID ({restaurant.Id}) already: ignoring.");
            }

            s_logger.Info($"Adding restaurant");

            Restaurant entity = Mapper.MapRestaurantWithReviews(restaurant);
            entity.Id = 0;
            _dbContext.Add(entity);
        }

        /// <summary>
        /// Delete a restaurant by ID. Any reviews associated to it will also be deleted.
        /// </summary>
        /// <param name="restaurantId">The ID of the restaurant</param>
        public void DeleteRestaurant(int restaurantId)
        {
            s_logger.Info($"Deleting restaurant with ID {restaurantId}");
            Restaurant entity = _dbContext.Restaurant.Find(restaurantId);
            _dbContext.Remove(entity);
        }

        /// <summary>
        /// Update a restaurant as well as its reviews.
        /// </summary>
        /// <param name="restaurant">The restaurant with changed values</param>
        public void UpdateRestaurant(Library.Models.Restaurant restaurant)
        {
            s_logger.Info($"Updating restaurant with ID {restaurant.Id}");

            // calling Update would mark every property as Modified.
            // this way will only mark the changed properties as Modified.
            Restaurant currentEntity = _dbContext.Restaurant.Find(restaurant.Id);
            Restaurant newEntity = Mapper.MapRestaurantWithReviews(restaurant);

            _dbContext.Entry(currentEntity).CurrentValues.SetValues(newEntity);
        }

        /// <summary>
        /// Add a review and associate it with a restaurant.
        /// </summary>
        /// <param name="review">The review</param>
        /// <param name="restaurant">The restaurant</param>
        public void AddReview(Library.Models.Review review, Library.Models.Restaurant restaurant = null)
        {
            if (restaurant.Id != 0)
            {
                s_logger.Warn($"Review to be added has an ID ({review.Id}) already: ignoring.");
            }

            s_logger.Info($"Adding review to restaurant with ID {restaurant.Id}");

            if (restaurant != null)
            {
                // get the db's version of that restaurant
                // (can't use Find with Include)
                Restaurant restaurantEntity = _dbContext.Restaurant
                    .Include(r => r.Review).First(r => r.Id == restaurant.Id);
                Review newEntity = Mapper.Map(review);
                restaurantEntity.Review.Add(newEntity);
                // also, modify the parameters
                restaurant.Reviews.Add(review);
            }
            else
            {
                Review newEntity = Mapper.Map(review);
                _dbContext.Add(newEntity);
            }
        }

        /// <summary>
        /// Delete a review by ID.
        /// </summary>
        /// <param name="reviewId">The ID of the review</param>
        public void DeleteReview(int reviewId)
        {
            s_logger.Info($"Deleting review with ID {reviewId}");

            Review entity = _dbContext.Review.Find(reviewId);
            _dbContext.Remove(entity);
        }

        /// <summary>
        /// Update a review.
        /// </summary>
        /// <param name="review">The review with changed values</param>
        public void UpdateReview(Library.Models.Review review)
        {
            s_logger.Info($"Updating review with ID {review.Id}");

            Review currentEntity = _dbContext.Review.Find(review.Id);
            Review newEntity = Mapper.Map(review);

            _dbContext.Entry(currentEntity).CurrentValues.SetValues(newEntity);
        }

        /// <summary>
        /// Persist changes to the data source.
        /// </summary>
        public void Save()
        {
            s_logger.Info("Saving changes to the database");
            _dbContext.SaveChanges();
        }

        #region IDisposable Support
        private bool _disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }

                _disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
