using apiCatalogo.Context;
using apiCatalogo.DTOs.Produto;
using apiCatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiCatalogo.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutosController(ApiCatalogoDbContext context) : ControllerBase
{
    private readonly ApiCatalogoDbContext _context = context;

    [HttpGet]
    [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Get([FromQuery] ProdutoGetInputModel model)
    {
        IEnumerable<Produto> produtos = await _context.Produtos
            .AsNoTracking()
            .Where(x =>
                (string.IsNullOrEmpty(model.Nome) || x.Nome.Contains(model.Nome)) &&
                (string.IsNullOrEmpty(model.Descricao) || x.Descricao.Contains(model.Descricao))
            ).ToListAsync();

        return Ok(produtos);
    }

}
