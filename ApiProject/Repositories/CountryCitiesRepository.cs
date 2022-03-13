using ApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Repositories
{
    public class CountryCitiesRepository : ICountryCitiesRepository
    {
        private IEnumerable<CountryCities> countryCities = GenerateCountryCitiesData();

        public static IEnumerable<CountryCities> GenerateCountryCitiesData()
        {
            IEnumerable<CountryCities> lsCountryCities = new List<CountryCities>() {
                new CountryCities()
                {
                    Country = new Countries { Id = 1,  Name = "Australia" },
                    Cities = new List<Cities>
                    {
                        new Cities { Id = 4, Name = "Canberra" },
                        new Cities { Id = 5, Name = "Perth" },
                        new Cities { Id = 6, Name = "Sidney" },
                        new Cities { Id = 7, Name = "Brisbane" },
                    }
                },
                new CountryCities()
                {
                    Country = new Countries { Id = 2, Name = "Indonesia" },
                    Cities = new List<Cities>
                    {
                        new Cities { Id = 8, Name = "Jakarta" },
                        new Cities { Id = 9, Name = "Surabaya" },
                        new Cities { Id = 10, Name = "Medan" },
                    }
                },
                new CountryCities()
                {
                    Country = new Countries { Id = 3, Name = "Singapore" },
                    Cities = new List<Cities>
                    {
                        new Cities { Id = 11, Name = "Jurong West" },
                        new Cities { Id = 12, Name = "Jurong East" },
                        new Cities { Id = 13, Name = "Punggol" },
                    }
                }
            };

            return lsCountryCities;
        }

        public IEnumerable<CountryCities> GetCountryCities()
        {
            countryCities = GenerateCountryCitiesData();
            return countryCities;
        }

        public IEnumerable<Countries> GetCountries()
        {
            countryCities = GenerateCountryCitiesData();
            List<Countries> countries = new List<Countries>();
            foreach (var item in countryCities)
            {
                countries.Add(item.Country);
            }
            return countries;
        }

        public IEnumerable<Cities> GetCitiesOfSelectedCountry(int countryId)
        {
            countryCities = GenerateCountryCitiesData();
            List<Cities> cities = new List<Cities>();
            foreach (var eachCountryCities in countryCities)
            {
                if(eachCountryCities.Country.Id.Equals(countryId))
                {
                    foreach (var eachCity in eachCountryCities.Cities)
                    {
                        cities.Add(eachCity);
                    }
                }
            }
           
            return cities;
        }

    }
}
