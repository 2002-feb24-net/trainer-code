using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RestaurantReviews.DataAccess.Model
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
                entity.HasIndex(e => e.RestaurantId);

                entity.Property(e => e.ReviewerName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(2048);

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.RestaurantId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
