using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceManualTest.Models
{
    public class Service
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int Time { get; set; }
        public string Description { get; set; }
        public string Importance { get; set; }
        public bool State { get; set; }

    }
}
