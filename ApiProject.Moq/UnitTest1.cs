using ApiProject.Controllers;
using ApiProject.Models;
using ApiProject.Repositories;
using ApiProject.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ApiProject.Moq
{
    [TestClass]
    public class WeatherServiceTests
    {
        private readonly WeatherService _weatherService;
        private readonly Mock<IWeatherRepository> _weatherRepoMock = new Mock<IWeatherRepository>();

        public WeatherServiceTests()
        {
            _weatherService = new WeatherService(_weatherRepoMock.Object);
        }

        //[TestMethod]

        //private readonly Mock<IWeatherService>

        //public WeatherServiceTests()
        //{
        //    //_sut = new WeatherService(_)
        //}

        [Fact]
        public void ConvertTemperature_FromFarenheitToCelcius_ShouldReturnRightValue()
        {
            //Arrange
            var farenheitTemp = 100;
            var celciusTemp = ConvertTemperature(EnumType.TemperatureMeasurement.farenheit.ToString(), EnumType.TemperatureMeasurement.celcius.ToString(), farenheitTemp);

            //Act
            var resultTemp =  _weatherService.ConvertTemperature(EnumType.TemperatureMeasurement.farenheit.ToString(), EnumType.TemperatureMeasurement.celcius.ToString(), farenheitTemp);

            //Assert
            Assert.Equals(celciusTemp, resultTemp.Temp);

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
