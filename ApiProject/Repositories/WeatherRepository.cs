using ApiProject.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiProject.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly IConfiguration _config;

        public WeatherRepository(IConfiguration config)
        {
            _config = config;

        }


        public OpenWeatherSecret GetWeatherApi()
        {
            OpenWeatherSecret openWeatherApiKey = new OpenWeatherSecret();
            string result = _config.GetSection("OpenWeatherApi").Value;
            openWeatherApiKey.ApiKey = result;
            return openWeatherApiKey;

        }


        public async Task<Weathers> GetWeathers(string cityName)
        {
            
            OpenWeather_WeatherApi_Response openWeather_WeatherApi_Response = new OpenWeather_WeatherApi_Response();

            OpenWeather_OneCallApi_Response openWeather_OnceCallApi_Response = new OpenWeather_OneCallApi_Response();

            Weathers weather_Response = new Weathers();

            OpenWeatherSecret openWeatherApiKey = GetWeatherApi();


            string apiKey = openWeatherApiKey.ApiKey;
            string lat = string.Empty;
            string lon = string.Empty;

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = "https://api.openweathermap.org/data/2.5/weather?q=" + cityName + "&appid=" + apiKey;
                    using (var response = await httpClient.GetAsync(url))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        };
                        openWeather_WeatherApi_Response = JsonSerializer.Deserialize<OpenWeather_WeatherApi_Response>(apiResponse, options);

                        lat = openWeather_WeatherApi_Response.Coord.Lat.ToString().Replace("(", "-");
                        lon = openWeather_WeatherApi_Response.Coord.Lon.ToString().Replace("(", "-");

                    }
                }

                using (var httpClient = new HttpClient())
                {
                    string url = "https://api.openweathermap.org/data/2.5/onecall?lat=" + lat + "&lon=" + lon + "&exclude=hourly,daily&appid=" + apiKey;
                    using (var response = await httpClient.GetAsync(url))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        };

                        openWeather_OnceCallApi_Response = JsonSerializer.Deserialize<OpenWeather_OneCallApi_Response>(apiResponse, options);
                    }
                }

                weather_Response.DewPoint = openWeather_OnceCallApi_Response.Current.Dew_point;
                weather_Response.Lat = openWeather_OnceCallApi_Response.Lat;
                weather_Response.Lon = openWeather_OnceCallApi_Response.Lon;
                weather_Response.Pressure = openWeather_OnceCallApi_Response.Current.Pressure;
                weather_Response.RelativeHumidity = openWeather_OnceCallApi_Response.Current.Humidity;
                weather_Response.Timezone = openWeather_OnceCallApi_Response.Timezone;
                weather_Response.Visibility = openWeather_OnceCallApi_Response.Current.Visibility;
                weather_Response.WeatherDescription = openWeather_OnceCallApi_Response.Current.Weather.FirstOrDefault().Description;
                weather_Response.WeatherMain = openWeather_OnceCallApi_Response.Current.Weather.FirstOrDefault().Description;
                weather_Response.WindDegree = openWeather_OnceCallApi_Response.Current.Wind_deg;
                weather_Response.WindSpeed = openWeather_OnceCallApi_Response.Current.Wind_speed;
                weather_Response.TempFarenheit = openWeather_OnceCallApi_Response.Current.Temp;
              

            }
            catch (Exception ex)
            {

            }


            return weather_Response;

        }

        
    }
}
