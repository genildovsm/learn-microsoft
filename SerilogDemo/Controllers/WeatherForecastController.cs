using Microsoft.AspNetCore.Mvc;

namespace SerilogDemo.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{   

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IActionResult Get()
    {
        try
        {
            throw new ArgumentNullException();            

        }
        catch(Exception e)
        {
            _logger.LogError("{@Message}", e.StackTrace);

            return BadRequest(); 
        }
       
    }
}
