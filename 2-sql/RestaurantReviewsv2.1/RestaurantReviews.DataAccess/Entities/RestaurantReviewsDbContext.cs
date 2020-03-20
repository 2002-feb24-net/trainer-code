using Microsoft.EntityFrameworkCore;

namespace RestaurantReviews.DataAccess.Entities
{
    public partial class RestaurantReviewsDbContext : DbContext
    {
        public RestaurantReviewsDbContext()
        {
        }

        public RestaurantReviewsDbContext(DbContextOptions<RestaurantReviewsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Restaurant> Restaurant { get; set; }
        public virtual DbSet<Review> Review { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.ReviewerName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(2048);
            });
        }
    }
}
