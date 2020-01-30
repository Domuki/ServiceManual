using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceManualTest.Models;



namespace ServiceManualTest.Data
{
    public class DeviceDbContext: DbContext
    {
        public DbSet<Service> Service { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DeviceDbContext(DbContextOptions<DeviceDbContext>options):base(options)
        {
        }
      

    }
}
