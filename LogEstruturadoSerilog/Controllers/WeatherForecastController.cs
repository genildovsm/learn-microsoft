using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
            _logger.LogError(e,"Algo deu errado por aqui: {@CustomCode}.",5);

            return BadRequest(); 
        }
       
    }
}
