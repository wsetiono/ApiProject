using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Models
{
    public class Weathers
    {
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
        public string Timezone { get; set; }
        public decimal WindSpeed { get; set; }
        public decimal WindDegree { get; set; }
        public decimal Visibility { get; set; }
        public string WeatherMain { get; set; }
        public string WeatherDescription { get; set; }
        public decimal TempFarenheit { get; set; }
        public decimal TempCelcius { get; set; }
        public decimal DewPoint { get; set; }
        public decimal RelativeHumidity { get; set; }
        public decimal Pressure { get; set; }

    }
}
