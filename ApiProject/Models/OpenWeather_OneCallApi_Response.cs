using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Models
{
    public class OpenWeather_OneCallApi_Response
    {
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
        public string Timezone { get; set; }
        public Current Current { get; set; }

    }

    public class Weather
    {
        public string Main { get; set; }
        public string Description { get; set; }
    }

    public class Current
    {
        public decimal Temp { get; set; }
        public decimal Pressure { get; set; }
        public decimal Humidity { get; set; }
        public decimal Dew_point { get; set; }
        public decimal Visibility { get; set; }
        public decimal Wind_speed { get; set; }
        public decimal Wind_deg { get; set; }
        public List<Weather> Weather { get; set; }

    }

   

}
