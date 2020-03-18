using System;
using System.Collections.Generic;
using System.Linq;
using RestaurantReviews.Library.Models;

namespace RestaurantReviews.Library.Repositories
{
    /// <summary>
    /// A repository managing data access for restaurant objects and their review members.
    /// </summary>
    /// <remarks>
    /// The repository design pattern has us keep data access code in a class of its own;
    /// operations like create, read, update, and delete (CRUD operations)
    /// </remarks>
    public class RestaurantRepository
    {
        private readonly RestaurantContext _context;

        /// <summary>
        /// Initializes a new restaurant repository given a suitable restaurant data source.
        /// Creates the backing database if it doesn't exist.
        /// </summary>
        /// <param name="context">The EF Core restaurant database context</param>
        public RestaurantRepository(RestaurantContext context)
        {
            context.Database.EnsureCreated();

            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Get all restaurants with deferred execution.
        /// </summary>
        /// <returns>The collection of restaurants</returns>
        public IEnumerable<Restaurant> GetRestaurants(string search = null)
        {
            throw new NotImplementedException();
            //if (search == null)
            //{
            //    foreach (var item in _data)
            //    {
            //        yield return item;
            //    }
            //}
            //else
            //{
            //    foreach (var item in _data.Where(r => r.Name.Contains(search)))
            //    {
            //        yield return item;
            //    }
            //}
        }

        /// <summary>
        /// Get a restaurants by ID.
        /// </summary>
        /// <returns>The restaurant</returns>
        public Restaurant GetRestaurantById(int id)
        {
            throw new NotImplementedException();
            //return _data.First(r => r.Id == id);
        }

        /// <summary>
        /// Add a restaurant, including any associated reviews.
        /// </summary>
        /// <param name="restaurant">The restaurant</param>
        public void AddRestaurant(Restaurant restaurant)
        {
            throw new NotImplementedException();
            //if (_data.Any(r => r.Id == restaurant.Id))
            //{
            //    throw new InvalidOperationException($"Restaurant with ID {restaurant.Id} already exists.");
            //}
            //_data.Add(restaurant);
        }

        /// <summary>
        /// Delete a restaurant by ID. Any reviews associated to it will not be deleted.
        /// </summary>
        /// <param name="restaurantId">The ID of the restaurant</param>
        public void DeleteRestaurant(int restaurantId)
        {
            throw new NotImplementedException();
            //_data.Remove(_data.First(r => r.Id == restaurantId));
        }

        /// <summary>
        /// Update a restaurant as well as its reviews.
        /// </summary>
        /// <param name="restaurant">The restaurant with changed values</param>
        public void UpdateRestaurant(Restaurant restaurant)
        {
            throw new NotImplementedException();
            //DeleteRestaurant(restaurant.Id);
            //AddRestaurant(restaurant);
        }

        /// <summary>
        /// Add a review and associate it with a restaurant.
        /// </summary>
        /// <param name="review">The review</param>
        /// <param name="restaurant">The restaurant</param>
        public void AddReview(Review review, Restaurant restaurant)
        {
            throw new NotImplementedException();
            //restaurant.Reviews.Add(review);
        }

        /// <summary>
        /// Delete a review by ID.
        /// </summary>
        /// <param name="reviewId">The ID of the review</param>
        public void DeleteReview(int reviewId)
        {
            throw new NotImplementedException();
            //var restaurant = _data.First(x => x.Reviews.Any(y => y.Id == reviewId));
            //restaurant.Reviews.Remove(restaurant.Reviews.First(y => y.Id == reviewId));
        }

        /// <summary>
        /// Update a review.
        /// </summary>
        /// <param name="review">The review with changed values</param>
        public void UpdateReview(Review review)
        {
            throw new NotImplementedException();
            //var restaurant = _data.First(x => x.Reviews.Any(y => y.Id == review.Id));
            //var index = restaurant.Reviews.IndexOf(restaurant.Reviews.First(y => y.Id == review.Id));
            //restaurant.Reviews[index] = review;
        }
    }
}
