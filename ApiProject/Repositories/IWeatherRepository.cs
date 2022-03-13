using ApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Repositories
{
    public interface IWeatherRepository
    {
        Task<Weathers> GetWeathers(string cityName);

    }
}
