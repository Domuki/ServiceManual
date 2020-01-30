using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManualTest.Data;
using ServiceManualTest.Models;


namespace ServiceManualTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        DeviceDbContext _deviceDbContext;

        public DevicesController(DeviceDbContext deviceDbContext)
        {
            _deviceDbContext = deviceDbContext;
        }
        [HttpGet]
        public IActionResult GetServices()
        {
            var devices = _deviceDbContext.Devices.Include("Services");
            return Ok(devices);

        }

        //api/device/5
        [HttpGet("{id}")]
        public IActionResult GetService(int id)
        {
            
            var device = _deviceDbContext.Devices.Include("Services").FirstOrDefault(m => m.Id == id);
            return Ok(device);

        }

    }
}
