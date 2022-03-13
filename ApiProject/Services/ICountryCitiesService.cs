using ApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Services
{
    public interface ICountryCitiesService
    {
        IEnumerable<Countries> GetCountries();
        IEnumerable<Cities> GetCitiesOfSelectedCountry(int countryId);

    }
}
