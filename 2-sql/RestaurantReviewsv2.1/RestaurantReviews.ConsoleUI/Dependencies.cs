using System.Collections.Generic;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RestaurantReviews.DataAccess.Entities;
using RestaurantReviews.DataAccess.Repositories;
using RestaurantReviews.Library.Interfaces;

namespace RestaurantReviews.ConsoleUI
{
    // if you want to do code-first with migrations, EF needs to be able to see the connection string somehow.
    // either you have the DbContext.OnConfiguring method, or, you implement an IDesignTimeDbContextFactory.
    // then, the command like "dotnet ef migrations add InitialCreate --startup-project ../RestaurantReviews.ConsoleUI/"
    // will work.
    public class Dependencies : IDesignTimeDbContextFactory<RestaurantReviewsDbContext>
    {
        public RestaurantReviewsDbContext CreateDbContext(string[] args = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RestaurantReviewsDbContext>();
            optionsBuilder.UseSqlServer(SecretConfiguration.ConnectionString);

            return new RestaurantReviewsDbContext(optionsBuilder.Options);
        }

        public IRestaurantRepository CreateRestaurantRepository()
        {
            var dbContext = CreateDbContext();
            return new RestaurantRepository(dbContext);
        }

        public XmlSerializer CreateXmlSerializer()
        {
            return new XmlSerializer(typeof(List<Library.Models.Restaurant>));
        }
    }
}
