using apiCatalogo.Context;
using apiCatalogo.DTOs.Inputs;
using apiCatalogo.DTOs.Views;
using apiCatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

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
    public async Task<IActionResult> GetCategoriasProdutos()
    {
        IEnumerable<Categoria> categorias = await _context.Categorias
            .AsNoTracking()
            .Include(c => c.Produtos)
            .ToListAsync();

        return (categorias is null) ? NoContent() : Ok(categorias);
    }

    /// <summary>
    /// Obtém a categoria por id
    /// </summary>
    /// <param name="id">Identificador da categoria</param>
    /// <returns>Retorna uma categoria</returns>
    /// <response code="200">Categoria encontrada</response>
    /// <response code="404">Categoria não encontrada</response>
    [HttpGet("{id:int:min(1)}", Name = "ObterCategoria")]
    [ProducesResponseType(typeof(Categoria), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        Categoria? categoria = await _context.Categorias
            .Where(p => p.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (categoria is null) return NotFound("Categoria não encontrada");

        return Ok((CategoriaViewModel)categoria); 
    }

    /// <summary>
    /// Cria um nova categoria
    /// </summary>
    /// <param name="model">Modelo de entrada para categoria</param>
    /// <returns>Retorna a categoria adicionada</returns>
    /// <response code="400">Categoria não informada</response>
    /// <response code="201">Categoria cadastrada</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Categoria),StatusCodes.Status201Created)]
    public async Task<IActionResult> Post(CategoriaInputModel model)
    {
        Categoria categoria = model;

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
    [HttpPut("{id:int:min(1)}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Categoria), StatusCodes.Status200OK)]
    public async Task<IActionResult> Put(int id, CategoriaInputModel model)
    {
        Categoria categoria = model;
        categoria.Id = id;

        _context.Entry(categoria).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        _context.Entry(categoria).State = EntityState.Detached;

        return Ok(categoria);
    }

    /// <summary>
    /// Deleta uma categoria
    /// </summary>
    /// <param name="id">identificador da categoria</param>
    /// <returns></returns>
    /// <response code="204">Retorna a categoria excluída</response>
    /// <response code="404">Categoria não localizada</response>
    [HttpDelete("{id:int:min(1)}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(int id)
    {
        var categoria = await _context.Categorias
            .FirstOrDefaultAsync(c => c.Id == id);

        if (categoria is null) return NotFound("Categoria não encontrada");

        _context.Remove(categoria);
        await _context.SaveChangesAsync();

        _context.Entry(categoria).State = EntityState.Detached;

        return NoContent();
    }
}
