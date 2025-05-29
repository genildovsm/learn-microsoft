using apiCatalogo.Context;
using apiCatalogo.DTOs.Inputs;
using apiCatalogo.DTOs.Views;
using apiCatalogo.Filters;
using apiCatalogo.Models;
using apiCatalogo.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiCatalogo.Controllers;

/// <summary>
/// Controlador de categorias
/// </summary>
[ApiController]
[Route("[controller]")]
public class CategoriasController (
    ApiCatalogoDbContext context, 
    ICategoriaRepository categoriaRepository) : ControllerBase
{
    private readonly ApiCatalogoDbContext _context = context;
    private readonly ICategoriaRepository _categoriaRepository = categoriaRepository;

    /// <summary>
    /// Obtém todas as categorias e seus produtos relacionados
    /// </summary>
    /// <response code="200">A consulta encontrou registros</response>
    /// <response code="204">A consulta não encontrou registros</response>
    [HttpGet("Produtos")]
    [ProducesResponseType(typeof(Categoria), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetCategoriasProdutos()
    {
        IEnumerable<Categoria> categorias = await _categoriaRepository
            .ObterCategoriasProdutos()
            .ToListAsync();

        return (categorias is null) ? NoContent() : Ok(categorias);
    }

    /// <summary>
    /// Obtém a categoria por id
    /// </summary>
    /// <param name="id">Identificador da categoria</param>
    /// <response code="200">Categoria encontrada</response>
    /// <response code="404">Categoria não encontrada</response>
    [HttpGet("{id:int:min(1)}", Name = "ObterCategoria")]
    [ProducesResponseType(typeof(Categoria), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string),StatusCodes.Status404NotFound)]    
    public async Task<IActionResult> Get(int id)
    {
        var categoria = await _categoriaRepository.ObterCategoriaPorIdAsync(id);

        if (categoria is null) return NotFound("Categoria não encontrada");

        return Ok( (CategoriaViewModel?) categoria ); 
    }

    /// <summary>
    /// Cria um nova categoria
    /// </summary>
    /// <param name="model">Modelo de entrada para categoria</param>    
    /// <response code="201">Categoria cadastrada</response>
    /// <response code="400">Categoria não informada</response>
    [HttpPost]
    [ProducesResponseType(typeof(Categoria),StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]    
    public async Task<IActionResult> Post(CategoriaInputModel model)
    {
        Categoria categoria = await _categoriaRepository.CriarCategoriaAsync(model);

        if (categoria is null) return BadRequest("Erro na criação da categoria");

        return new CreatedAtRouteResult(
            "ObterCategoria", 
            new { id = categoria.Id }, 
            (CategoriaViewModel?)categoria
        );
    }

    /// <summary>
    /// Atualiza os dados da categoria
    /// </summary>
    /// <param name="id">Identificador da categoria</param>
    /// <param name="model">Instância do modelo de entrada de categoria</param>    
    /// <response code="200">Categoria atualizada</response>
    /// <response code="400">Categoria não informada</response>
    [HttpPut("{id:int:min(1)}")]
    [ProducesResponseType(typeof(CategoriaViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]    
    public async Task<IActionResult> Put(int id, CategoriaInputModel model)
    {
        Categoria? result = await _categoriaRepository.ObterCategoriaPorIdAsync(id);

        if (result is null) return BadRequest("Categoria não encontrada");

        Categoria novaCategoria = (Categoria)model;
        novaCategoria.Id = id;

        await _categoriaRepository.AtualizarCategoriaAsync(novaCategoria);

        return Ok(novaCategoria);
    }

    /// <summary>
    /// Deleta uma categoria
    /// </summary>
    /// <param name="id">identificador da categoria</param>
    /// <response code="204"></response>
    /// <response code="404">Categoria não localizada</response>
    [HttpDelete("{id:int:min(1)}")]    
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(string),StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        Categoria? categoria = await _categoriaRepository.ObterCategoriaPorIdAsync(id);

        if (categoria is null) return NotFound("Categoria não encontrada");

        await _categoriaRepository.DeleteCategoriaAsync(categoria);

        return NoContent();
    }

    /// <summary>
    /// Exemplificação do uso de Filters a nível de actions
    /// </summary>
    [HttpGet("[action]", Name = "usando-filters")]
    [ServiceFilter(typeof(ApiLoggingFilter))]
    [ProducesResponseType(typeof(string),StatusCodes.Status200OK)]
    public IActionResult UsandoFilters()
    {
        return Ok("Esta action está usando o recurso de Filters");
    }
}
