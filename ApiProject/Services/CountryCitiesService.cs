using ApiProject.Models;
using ApiProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Services
{
    public class CountryCitiesService : ICountryCitiesService
    {

        private readonly ICountryCitiesRepository _countryCitiesRepository;

        public CountryCitiesService(ICountryCitiesRepository countryCitiesRepository)
        {
            _countryCitiesRepository = countryCitiesRepository;
        }

        public IEnumerable<Countries> GetCountries()
        {
            IEnumerable<Countries> countries = _countryCitiesRepository.GetCountries();
            return countries;
        }

        public IEnumerable<Cities> GetCitiesOfSelectedCountry(int countryId)
        {
            IEnumerable<Cities> cities = _countryCitiesRepository.GetCitiesOfSelectedCountry(countryId);
            return cities;
        }

    }
}
