using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSchool_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return NotFound(new
            {
                Nome = "Gilvan"
            });
        }

        [HttpGet("{codigo}")]
        public IActionResult Get(int codigo)
        {
            return NotFound(new
            {
                Nome = "Gilvan " + codigo
            });
        }

        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return Ok("Voce chamou o post: " + value);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Ok("Voce chamou o put de id: " + id + " value: " + value);
        }

                [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok("Voce chamou o delete de id: " + id );
        }
    }
}
