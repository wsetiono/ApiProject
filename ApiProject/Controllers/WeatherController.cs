using ApiProject.Models;
using ApiProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IWeatherService _weatherService;

        public WeatherController(IConfiguration config, IWeatherService weatherService)
        {
            _config = config;
            _weatherService = weatherService;
        }

        public async Task<IActionResult> GetWeather(string cityName)
        {
            Weathers openWeatherResponse = await _weatherService.GetWeather(cityName);
            return Ok(openWeatherResponse);
        }


    }
}
