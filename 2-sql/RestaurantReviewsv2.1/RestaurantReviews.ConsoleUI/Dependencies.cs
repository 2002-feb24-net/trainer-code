using System.Collections.Generic;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using RestaurantReviews.DataAccess.Entities;
using RestaurantReviews.DataAccess.Repositories;
using RestaurantReviews.Library.Interfaces;

namespace RestaurantReviews.ConsoleUI
{
    public static class Dependencies
    {
        public static IRestaurantRepository CreateRestaurantRepository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<RestaurantReviewsDbContext>();
            optionsBuilder.UseSqlServer(SecretConfiguration.ConnectionString);

            var dbContext = new RestaurantReviewsDbContext(optionsBuilder.Options);

            return new RestaurantRepository(dbContext);
        }

        public static XmlSerializer CreateXmlSerializer()
        {
            return new XmlSerializer(typeof(List<Library.Models.Restaurant>));
        }
    }
}
