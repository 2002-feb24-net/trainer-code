using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
        /// Get all restaurants.
        /// </summary>
        /// <returns>The collection of restaurants</returns>
        public IEnumerable<Restaurant> GetRestaurants(string search = null)
        {
            // LINQ has two sets of methods: one for IEnumerable, one for IQueryable.
            // IQueryable supports translation of the overall query to something very different from C#, like SQL.
            // DbSets implement the IQueryable interface.
            IQueryable<Restaurant> items = _context.Restaurants
                .Include(r => r.Reviews)
                .AsNoTracking();

            // AsNoTracking() disables tracking on the objects taken through this particular call
            // tracking is that behavior of EF which allows it to notice any changes
            // to the objects taken from the DbSets.
            
            // why do this? repository pattern tries to keep the details about how we are storing
            // data encapsulated inside this class. someone calling this method shouldn't have to
            // know that EF might be noticing the changes he makes to the returned objects.

            // deferred execution lets me do things like modify the query conditionally before it executes.
            if (search != null)
            {
                items = items.Where(r => r.Name.Contains(search));
            }

            // only at this point is the query sent to the database and the data retrieved (deferred execution).
            return items.ToList();
        }

        /// <summary>
        /// Get a restaurants by ID.
        /// </summary>
        /// <returns>The restaurant</returns>
        public Restaurant GetRestaurantById(int id)
        {
            return _context.Restaurants
                .Include(r => r.Reviews)
                .AsNoTracking()
                .First(r => r.Id == id);
        }

        /// <summary>
        /// Add a restaurant, including any associated reviews.
        /// </summary>
        /// <remarks>
        /// Ignores any set ID, recalculating an appropriate one.
        /// </remarks>
        /// <param name="restaurant">The restaurant</param>
        public void AddRestaurant(Restaurant restaurant)
        {
            // with DB-generated IDs, instead we must leave an int ID at default 0 when adding.
            // with SQLite, we need to come up with one. here's one way:
            int maxId = _context.Restaurants.Max(r => r.Id);
            restaurant.Id = maxId + 1;

            _context.Restaurants.Add(restaurant); // also adds any connected reviews
            _context.SaveChanges();
        }

        /// <summary>
        /// Delete a restaurant by ID, including any reviews associated to it.
        /// </summary>
        /// <param name="restaurantId">The ID of the restaurant</param>
        public void DeleteRestaurant(int restaurantId)
        {
            Restaurant entity = _context.Restaurants
                .Include(r => r.Reviews)
                .First(r => r.Id == restaurantId);
            _context.Remove(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Update a restaurant, ignoring any attached reviews.
        /// </summary>
        /// <param name="restaurant">The restaurant with changed values</param>
        public void UpdateRestaurant(Restaurant restaurant)
        {
            // one of several ways to do updates with EF Core.
            // in this case, we get the current values from the DB...
            Restaurant currentEntity = _context.Restaurants
                .First(r => r.Id == restaurant.Id);
            // and use these APIs on the context to copy the regular properties over.
            _context.Entry(currentEntity).CurrentValues.SetValues(restaurant);

            // it could also work to do _context.Restaurants.Update(restaurant).
            // this would cause the object to become tracked by the context,
            // and it would apply any changes found in the nested reviews too.

            _context.SaveChanges();
        }

        /// <summary>
        /// Add a review and associate it with a restaurant.
        /// </summary>
        /// <remarks>
        /// Ignores any set ID in the review, recalculating an appropriate one.
        /// </remarks>
        /// <param name="review">The review</param>
        /// <param name="restaurant">The restaurant</param>
        public void AddReview(Review review, Restaurant restaurant)
        {
            // with DB-generated IDs, instead we must leave an int ID at default 0 when adding.
            // but with SQLite, we need to come up with one. here's one way:
            int maxId = _context.Reviews.Max(r => r.Id);
            review.Id = maxId + 1;

            // get the db's version of that restaurant
            Restaurant restaurantEntity = _context.Restaurants
                .Include(r => r.Reviews)
                .First(r => r.Id == restaurant.Id);
            restaurantEntity.Reviews.Add(review);
            _context.SaveChanges();

            // also, modify the parameter
            restaurant.Reviews.Add(review);
        }

        /// <summary>
        /// Delete a review by ID.
        /// </summary>
        /// <param name="reviewId">The ID of the review</param>
        public void DeleteReview(int reviewId)
        {
            Review entity = _context.Reviews.First(r => r.Id == reviewId);
            _context.Remove(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Update a review.
        /// </summary>
        /// <param name="review">The review with changed values</param>
        public void UpdateReview(Review review)
        {
            Review currentEntity = _context.Reviews.First(r => r.Id == review.Id);

            _context.Entry(currentEntity).CurrentValues.SetValues(review);
            _context.SaveChanges();
        }
    }
}
