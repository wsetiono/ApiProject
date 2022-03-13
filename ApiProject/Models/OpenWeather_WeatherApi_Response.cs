using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Models
{
    public class OpenWeather_WeatherApi_Response
    {
        public Coord Coord { get; set; }
    }

    public class Coord
    {
        public decimal Lon { get; set; }
        public decimal Lat { get; set; }

    }
}
