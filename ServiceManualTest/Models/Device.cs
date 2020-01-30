using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceManualTest.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Type { get; set; }


        public ICollection<Service> Services { get; set; }
}
}
