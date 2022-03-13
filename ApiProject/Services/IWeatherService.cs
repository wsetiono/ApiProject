using ApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Services
{
    public interface IWeatherService
    {
        Task<Weathers> GetWeather(string cityName);
        WeatherConvertionResult ConvertTemperature(string from, string to, decimal temp);

    }
}
