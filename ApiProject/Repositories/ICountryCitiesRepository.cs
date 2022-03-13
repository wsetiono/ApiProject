using ApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Repositories
{
    public interface ICountryCitiesRepository
    {
        IEnumerable<Countries> GetCountries();
        IEnumerable<CountryCities> GetCountryCities();
        IEnumerable<Cities> GetCitiesOfSelectedCountry(int countryId);

    }
}
