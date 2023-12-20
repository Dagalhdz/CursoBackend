using CursoBackend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CursoBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly AppDbContext _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecast()
        {
            return await _context.WeatherForecasts.ToListAsync();
        }

        [HttpPost(Name = "PostWeatherForecast")]
        public async Task<ActionResult> PostWeatherForecast(WeatherForecast weatherForecast)
        {
            if(weatherForecast == null)
            {
                return BadRequest("Datos vacios");
            }
            await _context.AddAsync(weatherForecast);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{id}", Name = "GetByIdWeatherForecast")]
        public async Task<ActionResult<WeatherForecast>> GetByIdWeatherForecast (int id)
        {
            var weather = await _context.WeatherForecasts.FirstOrDefaultAsync(weahterForecast => weahterForecast.Id == id);
            if (weather == null) return NotFound("No existe el dato");

            return Ok(weather);
        }

        [HttpDelete("{id}", Name = "DeleteWeatherForecast")]
        public async Task<ActionResult<WeatherForecast>> DeleteWeatherForecast(int id)
        {
            var exist = await _context.WeatherForecasts.AnyAsync(weahterForecast => weahterForecast.Id == id);
            if (!exist) return NotFound("No existe el dato");

            _context.WeatherForecasts.Remove(new WeatherForecast() { Id = id });
            await _context.SaveChangesAsync();

            return Ok("Dato eliminado correctamente");
        }


        [HttpPut("{id}", Name = "PutWeatherForecast")]
        public async Task<ActionResult<WeatherForecast>> PutWeatherForecast(WeatherForecast weather, int id)
        {
            var exist = await _context.WeatherForecasts.AnyAsync(weahterForecast => weahterForecast.Id == id);
            if (!exist) return NotFound("No existe el dato");
            if (weather == null) return BadRequest("Datos vacios");

            _context.Update(weather);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
