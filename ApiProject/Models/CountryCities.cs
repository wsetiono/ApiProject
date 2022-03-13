using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Models
{
    public class CountryCities
    {
        public Countries Country { get; set; }
        public IEnumerable<Cities> Cities { get; set; }

    }
}
