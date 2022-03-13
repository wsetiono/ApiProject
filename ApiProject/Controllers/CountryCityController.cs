using ApiProject.Models;
using ApiProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CountryCityController : ControllerBase
    {
        private readonly ICountryCitiesService _countryCitiesService;
        public CountryCityController(ICountryCitiesService countryCitiesService)
        {
            _countryCitiesService = countryCitiesService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Countries>> GetCountries()
        {
            try
            {
                IEnumerable<Countries> countries = _countryCitiesService.GetCountries();
                return Ok(countries);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cities>> GetCities_FromSelectedCountry(int countryId)
        {
            try
            {
                IEnumerable<Cities> cities = _countryCitiesService.GetCitiesOfSelectedCountry(countryId);

                return Ok(cities);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

     
    }
}
