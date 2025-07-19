using Microsoft.AspNetCore.Mvc;

namespace MeuTodo.Controllers
{    
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet(Name = "home-index")]
        public IActionResult Index()
        {
            var result = new { controller = "Home", action = "Index" };

            return Ok(result);
        }
    }
}
