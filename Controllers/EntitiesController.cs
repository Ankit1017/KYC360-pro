using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using YourProjectName.Models; // Adjust namespace if necessary

namespace YourProjectName.Controllers
{
    [ApiController]
    [Route("api/entities")]
    public class EntitiesController : ControllerBase
    {
        private readonly List<Entity> _entities; // Assume this is your data source

        public EntitiesController()
        {
            // Initialize sample data
            _entities = new List<Entity>
            {
                // Sample entities
            };
        }
        
        // GET: api/entities
        [HttpGet]
        public ActionResult<IEnumerable<Entity>> GetEntities(
            string search,
            string gender,
            DateTime? startDate,
            DateTime? endDate,
            List<string> countries)
        {
            IEnumerable<Entity> entities = _entities;

            // Search entities
            if (!string.IsNullOrEmpty(search))
            {
                entities = entities.Where(e =>
                    e.Addresses.Any(a =>
                        a.Country.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                        a.AddressLine.Contains(search, StringComparison.OrdinalIgnoreCase)) ||
                    e.Names.Any(n =>
                        n.FirstName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                        n.MiddleName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                        n.Surname.Contains(search, StringComparison.OrdinalIgnoreCase)));
            }

            // Filter by gender
            if (!string.IsNullOrEmpty(gender))
            {
                entities = entities.Where(e => e.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase));
            }

            // Filter by start date
            if (startDate != null)
            {
                entities = entities.Where(e => e.Dates.Any(d => d.DateValue >= startDate));
            }

            // Filter by end date
            if (endDate != null)
            {
                entities = entities.Where(e => e.Dates.Any(d => d.DateValue <= endDate));
            }

            // Filter by countries
            if (countries != null && countries.Any())
            {
                entities = entities.Where(e => e.Addresses.Any(a => countries.Contains(a.Country)));
            }

            return Ok(entities);
        }

        // GET: api/entities/{id}
        [HttpGet("{id}")]
        public ActionResult<Entity> GetEntityById(string id)
        {
            var entity = _entities.FirstOrDefault(e => e.Id == id);
            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }
    }
}
