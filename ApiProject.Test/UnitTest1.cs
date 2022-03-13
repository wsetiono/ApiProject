using ApiProject.Models;
using ApiProject.Repositories;
using ApiProject.Services;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ApiProject.Test
{
    public class UnitTest1
    {
        private readonly Mock<IWeatherRepository> _weatherRepoMock = new Mock<IWeatherRepository>();

        public UnitTest1()
        {
        }



        [Fact]
        public async Task ConvertTemperature_FarenheitToCelcius_ShouldReturnRightValue()
        {

            //Arrange
            WeatherService _weatherService = new WeatherService(_weatherRepoMock.Object);

            decimal farenheitTemp = 100;
            decimal celciusTemp = ConvertTemperature(EnumType.TemperatureMeasurement.farenheit.ToString(), EnumType.TemperatureMeasurement.celcius.ToString(), farenheitTemp).Temp;
          
            //Act
            var weatherTemp = _weatherService.ConvertTemperature(EnumType.TemperatureMeasurement.farenheit.ToString(), EnumType.TemperatureMeasurement.celcius.ToString(), farenheitTemp);

            //Assert
            Assert.Equal(celciusTemp, weatherTemp.Temp);
        }


        public static WeatherConvertionResult ConvertTemperature(string from, string to, decimal temp)
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
