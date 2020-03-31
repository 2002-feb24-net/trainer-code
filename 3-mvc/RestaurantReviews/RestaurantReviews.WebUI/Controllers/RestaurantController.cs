using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using RestaurantReviews.Domain.Interfaces;
using RestaurantReviews.Domain.Model;
using RestaurantReviews.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantReviews.WebUI.Controllers
{
    public class RestaurantController : Controller
    {
        public IRestaurantRepository Repo { get; }

        public RestaurantController(IRestaurantRepository repo) =>
            Repo = repo ?? throw new ArgumentNullException(nameof(repo));

        // GET: Restaurant
        // default value for "search" means i can use this method both for search results
        // and for "show all restaurants"
        // [FromQuery] makes it explicit that i'm looking to get this from the query string
        // e.g. Restaurant?search=Fred
        // e.g. Restaurant/?search=Fred
        // e.g. Restaurant/Index?search=Fred
        // e.g. Restaurant/Index/?search=Fred
        public ActionResult Index([FromQuery]string search = "")
        {
            IEnumerable<Restaurant> restaurants = Repo.GetRestaurants(search);
            IEnumerable<RestaurantViewModel> viewModels = restaurants.Select(x => new RestaurantViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Reviews = x.Reviews.Select(y => new ReviewViewModel()),
                Score = x.Score
            });
            return View(viewModels);
        }

        // GET: Restaurant/Details/5
        public ActionResult Details(int id)
        {
            Restaurant restaurant = Repo.GetRestaurantById(id);
            var viewModel = new RestaurantViewModel
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Reviews = restaurant.Reviews.Select(y => new ReviewViewModel
                {
                    Id = y.Id,
                    ReviewerName = y.ReviewerName,
                    Score = y.Score,
                    Text = y.Text
                }),
                Score = restaurant.Score
            };
            return View(viewModel);
        }

        // GET: Restaurant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurant/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Name")]RestaurantViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var restaurant = new Restaurant
                    {
                        Name = viewModel.Name
                    };
                    Repo.AddRestaurant(restaurant);
                    Repo.Save();

                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch
            {
                return View(viewModel);
            }
        }

        // GET: Restaurant/Edit/5
        public ActionResult Edit(int id)
        {
            // we pass the current values into the Edit view
            // so that the input fields can be pre-populated instead of blank
            // (important for good UX)
            Restaurant restaurant = Repo.GetRestaurantById(id);
            var viewModel = new RestaurantViewModel
            {
                Id = restaurant.Id,
                Name = restaurant.Name
            };
            return View(viewModel);
        }

        // POST: Restaurant/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        // without [Bind("Name")], this would look in the request body, or query string
        // for the restaurant.Id and for restaurant.Reviews
        // this way, it will only try to bind restaurant.Name, and will leave other properties
        // at default.
        // this is really more of a security thing, because your rendered views should only
        // be sending what you expect
        public ActionResult Edit([FromRoute]int id, [Bind("Name")]RestaurantViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Restaurant restaurant = Repo.GetRestaurantById(id);
                    restaurant.Name = viewModel.Name;
                    Repo.UpdateRestaurant(restaurant);
                    Repo.Save();

                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch (Exception)
            {
                return View(viewModel);
            }
        }

        // GET: Restaurant/Delete/5
        public ActionResult Delete(int id)
        {
            Restaurant restaurant = Repo.GetRestaurantById(id);
            var viewModel = new RestaurantViewModel
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Reviews = restaurant.Reviews.Select(x => new ReviewViewModel())
            };
            return View(viewModel);
        }

        // POST: Restaurant/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, [BindNever]IFormCollection collection)
        {
            try
            {
                Repo.DeleteRestaurant(id);
                Repo.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
