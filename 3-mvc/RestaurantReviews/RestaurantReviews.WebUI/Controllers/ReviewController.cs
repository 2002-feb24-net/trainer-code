using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using RestaurantReviews.Domain.Interfaces;
using RestaurantReviews.Domain.Model;
using RestaurantReviews.WebUI.ViewModels;

namespace RestaurantReviews.WebUI.Controllers
{
    public class ReviewController : Controller
    {
        public IRestaurantRepository Repo { get; }

        public ReviewController(IRestaurantRepository repo) =>
            Repo = repo ?? throw new ArgumentNullException(nameof(repo));

        // GET: Review/Details/5
        public ActionResult Details(int id)
        {
            Review review = Repo.GetReviewById(id);
            var restaurantId = Repo.RestaurantIdFromReviewId(id);
            var viewModel = new ReviewViewModel
            {
                Id = review.Id,
                ReviewerName = review.ReviewerName,
                Score = review.Score,
                Text = review.Text,
                RestaurantId = restaurantId
            };
            return View(viewModel);
        }

        // GET: Review/Create?restaurantId=5
        public ActionResult Create([FromQuery]int restaurantId)
        {
            var review = new ReviewViewModel
            {
                RestaurantId = restaurantId
            };
            return View(review);
        }

        // POST: Review/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("ReviewerName,Score,Text,RestaurantId")]ReviewViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(viewModel);
                }

                Restaurant restaurant = Repo.GetRestaurantById(viewModel.RestaurantId);
                var review = new Review
                {
                    ReviewerName = viewModel.ReviewerName,
                    Score = viewModel.Score,
                    Text = viewModel.Text
                };
                Repo.AddReview(review, restaurant);
                Repo.Save();

                return RedirectToAction(nameof(RestaurantController.Details),
                    "Restaurant", new { id = viewModel.RestaurantId });
            }
            catch
            {
                return View(viewModel);
            }
        }

        // GET: Review/Delete/5
        public ActionResult Delete(int id)
        {
            Review review = Repo.GetReviewById(id);
            var restaurantId = Repo.RestaurantIdFromReviewId(id);
            var viewModel = new ReviewViewModel
            {
                Id = review.Id,
                ReviewerName = review.ReviewerName,
                Score = review.Score,
                Text = review.Text,
                RestaurantId = restaurantId
            };
            return View(viewModel);
        }

        // POST: Review/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, [BindNever]IFormCollection collection)
        {
            try
            {
                var restaurantId = Repo.RestaurantIdFromReviewId(id);
                Repo.DeleteReview(id);
                Repo.Save();

                return RedirectToAction(nameof(RestaurantController.Details),
                    "Restaurant", new { id = restaurantId });
            }
            catch
            {
                return View();
            }
        }

    }
}
