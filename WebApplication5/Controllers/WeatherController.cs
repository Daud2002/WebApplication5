using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly AppDbContext _context;

        public WeatherController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Weather
        [HttpGet]
        public ActionResult<IEnumerable<Weather>> GetWeather()
        {
            return _context.Weather.ToList();
        }

        // GET: api/Weather/5
        [HttpGet("{id}")]
        public ActionResult<Weather> GetWeather(int id)
        {
            var weather = _context.Weather.Find(id);

            if (weather == null)
            {
                return NotFound();
            }

            return weather;
        }

        // POST: api/Weather
        [HttpPost]
        public IActionResult PostWeather(Weather weather)
        {
            _context.Weather.Add(weather);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetWeather), new { id = weather.Id }, weather);
        }

        // PUT: api/Weather/5
        [HttpPut("{id}")]
        public IActionResult PutWeather(int id, Weather weather)
        {
            if (id != weather.Id)
            {
                return BadRequest();
            }

            _context.Entry(weather).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Weather/5
        [HttpDelete("{id}")]
        public IActionResult DeleteWeather(int id)
        {
            var weather = _context.Weather.Find(id);

            if (weather == null)
            {
                return NotFound();
            }

            _context.Weather.Remove(weather);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
