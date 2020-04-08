using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NotesService.Api.Controllers
{
    // with web APIs in ASP.NET Core,
    // everything about that request-routing-controller-model-binding-action-filters-response
    // is all the same, except: instead of the "result" usually being a ViewResult that renders to HTML,
    // the result is usually something else implementing IActionResult, such as ObjectResult,
    // which "executes" into some format like JSON or XML rather than HTML.

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        // with MVC, we used IActionResult for the return type
        // that still definitely works with web APIs

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        // you can write action methods specific to different representations of a resource,
        // but ideally you don't, and you write the code more generically
    }
}
