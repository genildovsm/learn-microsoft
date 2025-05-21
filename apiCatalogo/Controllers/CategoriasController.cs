using apiCatalogo.Context;
using apiCatalogo.DTOs.Inputs;
using apiCatalogo.DTOs.Views;
using apiCatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiCatalogo.Controllers;

/// <summary>
/// Controlador de categorias
/// </summary>
/// <remarks>
///
/// </remarks>
[ApiController]
[Route("[controller]")]
public class CategoriasController(ApiCatalogoDbContext context) : ControllerBase
{
    private readonly ApiCatalogoDbContext _context = context;

    /// <summary>
    /// Consulta todas as categorias e seus produtos relacionados
    /// </summary>
    /// <returns>Retorna uma lista de categorias</returns>
    /// <response code="200">A consulta encontrou registros</response>
    /// <response code="204">A consulta não encontrou registros</response>
    [HttpGet("Produtos")]
    [ProducesResponseType(typeof(Categoria), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<IEnumerable<Categoria>>> GetCategoriasProdutos()
    {
        var categorias = await _context.Categorias
            .AsNoTracking()
            .Include(c => c.Produtos)
            .ToListAsync();

        return categorias != null ? Ok(categorias) : NoContent();
    }

    /// <summary>
    /// Obtém uma categoria com base no id informado
    /// </summary>
    /// <param name="id">Identificador da categoria</param>
    /// <returns>Retorna uma categoria</returns>
    /// <response code="200">Categoria encontrada</response>
    /// <response code="404">Categoria não encontrada</response>
    [HttpGet("{id:int}", Name = "ObterCategoria")]
    public async Task<ActionResult<CategoriaViewModel>> Get(int id)
    {
        Categoria? categoria = await _context.Categorias
            .Where(p => p.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (categoria == null) return NotFound("Categoria não encontrada");

        return new CategoriaViewModel(categoria); 
    }

    /// <summary>
    /// Cria um nova categoria
    /// </summary>
    /// <param name="categoria">Instãncia da entidade categoria</param>
    /// <returns>Retorna a categoria adicionada</returns>
    /// <response code="400">Categoria não informada</response>
    [HttpPost]
    public async Task<ActionResult<Categoria>> Post(Categoria categoria)
    {
        if (categoria is null) return BadRequest("");

        _context.Categorias.Add(categoria);
        await _context.SaveChangesAsync();

        return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.Id }, categoria);
    }

    /// <summary>
    /// Atualiza os dados da categoria
    /// </summary>
    /// <param name="id">Identificador da categoria</param>
    /// <param name="model">Instância do modelo de entrada de categoria</param>
    /// <returns>Retorna uma categoria atualizada</returns>
    /// <response code="400">Categoria não informada</response>
    /// <response code="200">Categoria atualizada</response>
    [HttpPut("{id:int}")]
    public async Task<ActionResult<Categoria>> Put(int id, CategoriaInputModel model)
    {
        if (model is null) return BadRequest("Categoria não informada");

        Categoria categoria = model;
        categoria.Id = id;

        _context.Entry(categoria).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return Ok(categoria);
    }

    /// <summary>
    /// Deleta uma categoria
    /// </summary>
    /// <param name="id">identificador da categoria</param>
    /// <returns></returns>
    /// <response code="204">Retorna a categoria excluída</response>
    /// <response code="400">Categoria não localizada</response>
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Categoria>> Delete(int id)
    {
        var categoria = await _context.Categorias
            .FirstOrDefaultAsync(c => c.Id == id);

        if (categoria is null) return BadRequest("Categoria não encontrada");

        _context.Remove(categoria);
        await _context.SaveChangesAsync();

        _context.Entry(categoria).State = EntityState.Detached;

        return NoContent();
    }
}
