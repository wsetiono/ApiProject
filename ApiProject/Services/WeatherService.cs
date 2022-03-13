using ApiProject.Models;
using ApiProject.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ApiProject.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherRepository _weatherRepository;

        public WeatherService(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }

        
        public Task<Weathers> GetWeather(string cityName)
        {
            Task<Weathers> weather = _weatherRepository.GetWeathers(cityName);

            weather.Result.TempCelcius = ConvertTemperature(EnumType.TemperatureMeasurement.farenheit.ToString(), EnumType.TemperatureMeasurement.celcius.ToString(), weather.Result.TempFarenheit).Temp;

            return weather;
        }

        public WeatherConvertionResult ConvertTemperature(string from, string to, decimal temp)
        {
            decimal finalTemp = 0;

            if (from.ToLower().Equals(EnumType.TemperatureMeasurement.farenheit.ToString()) && to.ToLower().Equals(EnumType.TemperatureMeasurement.celcius.ToString()))
            {
                finalTemp = (temp - 32) * 5 / 9;
            }

            finalTemp = Math.Round(finalTemp, 2);

            WeatherConvertionResult weatherConvertionResult = new WeatherConvertionResult();
            weatherConvertionResult.Temp = finalTemp;

            return weatherConvertionResult;
        }


    }
}
