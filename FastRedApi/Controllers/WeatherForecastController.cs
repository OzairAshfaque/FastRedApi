using Data.Services.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Data.Services.Models;
using Data.Services.Response;

namespace FastRedApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
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

        [HttpGet]
        [ActionName("getweatherforecast")]
        public async Task<ActionResult<WeatherForecast>> GetWeatherForecast()
        {
          
            //var rng = new Random();
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();
            var filePath = "dataset.json";
            var json = filePath.ReturnFileInString();
            var  response = JsonSerializer.Deserialize<IEnumerable<DataSetDto>>(json);
            var msg = response.Where(x => x.birthyear == null).FirstOrDefault();
            
            
            return Ok(msg);

        }
    }
}
