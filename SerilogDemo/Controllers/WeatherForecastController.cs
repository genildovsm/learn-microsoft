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
            return Ok();

        }
        catch(Exception ex)
        {
            _logger.LogError(
                "Ocorreu um erro inesperado: {@RequestName}, {@Error}, {@DateTimeUtc}", 
                Url.RouteUrl("GetWeatherForecast"),
                ex.StackTrace, 
                DateTime.Now);

            return BadRequest();
        }
       
    }
}
