using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestaurantReviews.DataAccess.Model;
using RestaurantReviews.Domain.Interfaces;

namespace RestaurantReviews.DataAccess.Repositories
{
    /// <summary>
    /// A repository managing data access for restaurant objects and their review members,
    /// using Entity Framework.
    /// </summary>
    /// <remarks>
    /// This class ought to have better exception handling and logging.
    /// </remarks>
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly RestaurantReviewsDbContext _dbContext;

        private readonly ILogger<RestaurantRepository> _logger;

        /// <summary>
        /// Initializes a new restaurant repository given a suitable restaurant data source.
        /// </summary>
        /// <param name="dbContext">The data source</param>
        /// <param name="logger">The logger</param>
        public RestaurantRepository(RestaurantReviewsDbContext dbContext, ILogger<RestaurantRepository> logger)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Get all restaurants with deferred execution,
        /// including associated reviews.
        /// </summary>
        /// <returns>The collection of restaurants</returns>
        public IEnumerable<Domain.Model.Restaurant> GetRestaurants(string search = null)
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
        /// Get a restaurant by ID, including any associated reviews.
        /// </summary>
        /// <returns>The restaurant</returns>
        public Domain.Model.Restaurant GetRestaurantById(int id)
        {
            Restaurant restaurant = _dbContext.Restaurant
                .Include(r => r.Review)
                .FirstOrDefault(r => r.Id == id);

            return Mapper.MapRestaurantWithReviews(restaurant);
        }

        /// <summary>
        /// Add a restaurant, including any associated reviews.
        /// </summary>
        /// <param name="restaurant">The restaurant</param>
        public void AddRestaurant(Domain.Model.Restaurant restaurant)
        {
            if (restaurant.Id != 0)
            {
                _logger.LogWarning("Restaurant to be added has an ID ({restaurantId}) already: ignoring.", restaurant.Id);
            }

            _logger.LogInformation("Adding restaurant");

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
            _logger.LogInformation("Deleting restaurant with ID {restaurantId}", restaurantId);
            Restaurant entity = _dbContext.Restaurant.Find(restaurantId);
            _dbContext.Remove(entity);
        }

        /// <summary>
        /// Update a restaurant as well as its reviews.
        /// </summary>
        /// <param name="restaurant">The restaurant with changed values</param>
        public void UpdateRestaurant(Domain.Model.Restaurant restaurant)
        {
            _logger.LogInformation("Updating restaurant with ID {restaurantId}", restaurant.Id);

            // calling Update would mark every property as Modified.
            // this way will only mark the changed properties as Modified.
            Restaurant currentEntity = _dbContext.Restaurant.Find(restaurant.Id);
            Restaurant newEntity = Mapper.MapRestaurantWithReviews(restaurant);

            _dbContext.Entry(currentEntity).CurrentValues.SetValues(newEntity);
        }

        /// <summary>
        /// Get a review.
        /// </summary>
        /// <param name="reviewId">The ID of the review</param>
        public Domain.Model.Review GetReviewById(int reviewId)
        {
            Review review = _dbContext.Review.AsNoTracking()
                .First(r => r.Id == reviewId);
            return Mapper.Map(review);
        }

        /// <summary>
        /// Add a review and associate it with a restaurant.
        /// </summary>
        /// <param name="review">The review</param>
        /// <param name="restaurant">The restaurant</param>
        public void AddReview(Domain.Model.Review review, Domain.Model.Restaurant restaurant = null)
        {
            if (restaurant.Id != 0)
            {
                _logger.LogWarning("Review to be added has an ID ({reviewId}) already: ignoring.", review.Id);
            }

            _logger.LogInformation("Adding review to restaurant with ID {restaurantId}", restaurant.Id);

            if (restaurant != null)
            {
                // get the db's version of that restaurant
                // (can't use Find with Include)
                Restaurant restaurantEntity = _dbContext.Restaurant
                    .Include(r => r.Review)
                    .First(r => r.Id == restaurant.Id);
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
            _logger.LogInformation("Deleting review with ID {reviewId}", reviewId);

            Review entity = _dbContext.Review.Find(reviewId);
            _dbContext.Remove(entity);
        }

        /// <summary>
        /// Update a review.
        /// </summary>
        /// <param name="review">The review with changed values</param>
        public void UpdateReview(Domain.Model.Review review)
        {
            _logger.LogInformation("Updating review with ID {reviewId}", review.Id);

            Review currentEntity = _dbContext.Review.Find(review.Id);
            Review newEntity = Mapper.Map(review);

            _dbContext.Entry(currentEntity).CurrentValues.SetValues(newEntity);
        }

        /// <summary>
        /// Get the ID of the restaurant associated to the review with the given ID.
        /// </summary>
        /// <param name="reviewId">The ID of the review</param>
        /// <returns>The ID of the restaurant</returns>
        public int RestaurantIdFromReviewId(int reviewId)
        {
            return _dbContext.Review.AsNoTracking()
                .Where(r => r.Id == reviewId)
                .Select(r => r.RestaurantId)
                .First();
        }

        /// <summary>
        /// Persist changes to the data source.
        /// </summary>
        public void Save()
        {
            _logger.LogInformation("Saving changes to the database");
            _dbContext.SaveChanges();
        }
    }
}
