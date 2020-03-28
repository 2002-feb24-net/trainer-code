using RestaurantReviews.Domain.Model;
using System;
using System.Linq;
using Xunit;

namespace RestaurantReviews.Tests.Domain.Model
{
    public class RestaurantTest
    {
        // the test class is instantiated again for each test, so it is safe to put common setup code
        // in the class constructor or members. this will be a new restaurant object for each test.
        // it's made readonly to satisfy static analysis warnings.
        private readonly Restaurant _restaurant = new Restaurant();

        [Fact]
        public void Name_NonEmptyValue_StoresCorrectly()
        {
            string randomNameValue = "Komi";
            _restaurant.Name = randomNameValue;
            Assert.Equal(randomNameValue, _restaurant.Name);
        }

        [Fact]
        public void Name_EmptyValue_ThrowsArgumentException()
        {
            Assert.ThrowsAny<ArgumentException>(() => _restaurant.Name = string.Empty);
        }

        [Fact]
        public void Reviews_DefaultValue_Empty()
        {
            // "Empty" would throw an exception if it received a null value.
            // that would result in a failed test as expected, but this way is
            // a bit cleaner.
            Assert.NotNull(_restaurant.Reviews);
            Assert.Empty(_restaurant.Reviews);
        }

        [Fact]
        public void Score_EmptyReviews_Null()
        {
            Assert.Null(_restaurant.Score);
        }

        [Fact]
        public void Score_NullReviews_Null()
        {
            // being able to set Reviews to null is not necessarily required behavior,
            // so it's not tested, but this test will ensure that if that behavior is
            // available, then Score will behave appropriately and not throw an exception.
            try
            {
                _restaurant.Reviews = null;
            }
            catch
            {
                return;
            }
            Assert.Null(_restaurant.Score);
        }

        [Theory]
        [InlineData(1, 5)]
        [InlineData(6, 7, 8)]
        // "params" keyword lets the caller pass an arbitrary number of arguments and have them
        // put into an array automatically.
        public void Score_RestaurantHasReviews_IsAverageValue(params int[] reviewScores)
        {
            // use LINQ with a lambda expression to add reviews in one line.
            _restaurant.Reviews.AddRange(reviewScores.Select(s => new Review { Score = s }));
            var average = reviewScores.Average();
            // "HasValue" and "Value" are part of the definition of nullable types.
            Assert.True(_restaurant.Score.HasValue);
            // xUnit allows checking for floating-point equality allowing for imprecision.
            Assert.Equal(average, _restaurant.Score.Value, precision: 6);
        }
    }
}
