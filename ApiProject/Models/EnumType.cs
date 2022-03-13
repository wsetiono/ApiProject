using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Models
{
    public class EnumType 
    {
        public enum TemperatureMeasurement
        {
            farenheit,
            celcius
        }
    }
}
