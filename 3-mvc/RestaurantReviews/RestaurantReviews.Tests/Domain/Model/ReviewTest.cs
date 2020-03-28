using RestaurantReviews.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RestaurantReviews.Testing.Domain.Models
{
    public class ReviewTest
    {
        private readonly Review _review = new Review();

        [Fact]
        public void ReviewerName_NonEmptyValue_StoresCorrectly()
        {
            const string randomReviewerNameValue = "Al Gore";
            _review.ReviewerName = randomReviewerNameValue;
            Assert.Equal(randomReviewerNameValue, _review.ReviewerName);
        }

        [Fact]
        public void ReviewerName_EmptyValue_ThrowsArgumentException()
        {
            Assert.ThrowsAny<ArgumentException>(() => _review.ReviewerName = string.Empty);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(3)]
        [InlineData(10)]
        public void Score_ValueBetween0And10_StoresCorrectly(int scoreValue)
        {
            _review.Score = scoreValue;
            Assert.Equal(scoreValue, _review.Score);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(11)]
        public void Score_ValueNotBetween0And10_ThrowsArgumentException(int scoreValue)
        {
            Assert.ThrowsAny<ArgumentException>(() => _review.Score = scoreValue);
        }

        // being able to store null values is not necessarily required behavior
        [Theory]
        [InlineData("Perfect")]
        [InlineData("")]
        public void Text_NonNullValue_StoresCorrectly(string textValue)
        {
            _review.Text = textValue;
            Assert.Equal(textValue, _review.Text);
        }
    }
}
