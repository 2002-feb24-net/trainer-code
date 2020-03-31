using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcProjectStarter.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcProjectStarter.Controllers
{
    public class HelloWorldController : Controller
    {
        // a new controller (and a new everything) is instantiated for each HTTP request
        // so an instance property will not help be remember data from request to request
        // several ways to accomplish that e.g....
        //   1. TempData (is stored in cookies by default... in other words, sent to the browser for it to send back later)
        //   2. put it on the HTML somewhere, and arrange for it to be sent back on the next request e.g. in query string
        //   3. use a singleton service
        //   4. use a SQL DB

        // a static property is not good practice
        //public static int TotalRequestCount { get; set; } = 0;

        private readonly IRequestCounter _counter;

        // ASP.NET Core is responsible for making the controllers,
        // and for filling it its ctor parameters (dependency injection)
        public HelloWorldController(IRequestCounter counter)
        {
            // this is the opposite of dependency injection - instantiating our dependencies right here
            // "new is glue" - if your class says "new" in it, it's tightly coupled to some other class's
            // specific implementation. harder to unit test that code, harder to evolve it later.
            //_counter = new RequestCounter();
            counter.IncrementRequestCount();
            _counter = counter;
        }

        // GET: /HelloWorld/
        public IActionResult Index()
        {
            return View();
        }

        // GET: /HelloWorld/Welcome?name=Mark
        public IActionResult Welcome(string name, [FromServices] IRequestCounter counter2)
        {
            // with FromServices attribute, you can get dependencies injected into specific action methods

            ViewData["Message"] = "Hello" + name;
            ViewData["NumTimes"] = _counter.TotalRequestCount;
            ViewData["NumTimes2"] = counter2.TotalRequestCount;

            return View();
        }
    }
}
