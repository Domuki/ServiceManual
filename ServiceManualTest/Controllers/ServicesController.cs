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
    public class ServicesController : ControllerBase
    {
        private readonly DeviceDbContext _context;

        public ServicesController(DeviceDbContext context)
        {
            _context = context;
        }
       

        [HttpGet]
        [Route("[action]")]
        public IActionResult SearchService(string type)
        {
            var services = _context.Devices.Where(q => q.Name.StartsWith(type));
            return Ok(services);
        }

       /* //GET: api/services/GetDevice/
        [HttpGet("[action]")]
        public IActionResult GetDevices()
        {
            var servives = _context.Service.Include("Devices");
            return Ok(servives);

        }

        //GET: api/services/GetDevice/5
        [HttpGet("[action]/{id}")]
        public IActionResult GetDevice(int id)
        {

            var service = _context.Service.Include("Devices").FirstOrDefault(s => s.Id == id);
            return Ok(service);
        } 
        */


        // GET: /api/services?sort=asc
        [HttpGet]
        public IActionResult Get(string sort)
        {
            IQueryable<Service> services;
            switch (sort)
            {

                case "desc":
                    services = _context.Service.OrderByDescending(s => s.Importance).ThenBy(s => s.Date);
                    break;

                case "asc":
                    services = _context.Service.OrderBy(s => s.Importance).ThenBy(s => s.Date); 
                    break;

                default:
                    services = _context.Service.OrderBy(s => s.Importance).ThenBy(s => s.Date); 
                    break;
            }
            return Ok(services);
        }

        // GET: api/Services/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetService(int id)
        {
            var service = await _context.Service.FindAsync(id);

            if (service == null)
            {
                return NotFound();
            }

            return service;
        }

        // PUT: api/Services/5
        [HttpPut("{id}")]
        public void PutService(int id, [FromBody]Service service)
        {

            var entity = _context.Service.Find(id);
            entity.Date = service.Date;
            entity.Time = service.Time;
            entity.Importance = service.Importance;
            entity.State = service.State;
            _context.SaveChanges();

        }

        // POST: api/Services
        [HttpPost]
        public void PostService([FromBody]Service service)
        {
            _context.Service.Add(service);
            _context.SaveChanges();
        }

        // DELETE: api/Services/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Service>> DeleteService(int id)
        {
            var service = await _context.Service.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            _context.Service.Remove(service);
            await _context.SaveChangesAsync();

            return service;
        }

        private bool ServiceExists(int id)
        {
            return _context.Service.Any(e => e.Id == id);
        }
    }
}
