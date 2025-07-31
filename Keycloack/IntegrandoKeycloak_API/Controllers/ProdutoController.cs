using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IntegrandoKeycloak_API.Controllers
{
    [ApiController]    
    [Route("api/[controller]")]
    [Authorize]
    public class ProdutoController : ControllerBase
    {
        private readonly ILogger<ProdutoController> _logger;

        public ProdutoController(ILogger<ProdutoController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "index")]
        public IActionResult Index()
        {
            return Ok( Marcas() );
        }

        [HttpPost("[action]", Name = "criar")]
        [Authorize(Roles = "Create")]
        public IActionResult Criar()
        {
            return Ok("Produto criado com sucesso");
        }

        [HttpDelete("[action]", Name = "delete")]
        [Authorize(Roles = "Delete")]
        public IActionResult Deletar()
        {
            return Ok("Produto removido com sucesso");
        }

        [HttpGet("[action]", Name = "admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
            return Ok("Exibe conteúdo da área administrativa");
        }



        private static IEnumerable<string> Marcas()
        {            
            return [ "Apple", "Samsung", "Microsoft", "Sony", "LG"];
        }
    }
}
 