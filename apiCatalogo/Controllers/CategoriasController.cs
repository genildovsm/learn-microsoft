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
    ICategoriaRepository categoriaRepository) : ControllerBase
{
    private readonly ICategoriaRepository _categoriaRepository = categoriaRepository;

    /// <summary>
    /// Obtém todas as categorias e seus produtos relacionados
    /// </summary>
    /// <response code="200">A consulta encontrou registros</response>
    /// <response code="204">A consulta não encontrou registros</response>
    [HttpGet("Produtos")]
    [ProducesResponseType(typeof(Categoria), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAll()
    {
        var categorias = await _categoriaRepository
            .CategoriasProdutosGetAll()
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
    public async Task<IActionResult> GetById(int id)
    {
        var categoria = await _categoriaRepository.CategoriaGetByIdAsync(id);

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
        var categoria = await _categoriaRepository.CategoriaCreateAsync(model);

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
        Categoria? result = await _categoriaRepository.CategoriaGetByIdAsync(id);

        if (result is null) return BadRequest("Categoria não encontrada");

        Categoria novaCategoria = (Categoria)model;
        novaCategoria.Id = id;

        await _categoriaRepository.CategoriaUpdateAsync(novaCategoria);

        return Ok(novaCategoria);
    }

    /// <summary>
    /// Deleta uma categoria
    /// </summary>
    /// <param name="id">identificador da categoria</param>
    /// <response code="204"></response>
    /// <response code="404">Categoria não localizada</response>
    [HttpDelete("{id:int:min(1)}")]    
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        bool wasDeleted = await _categoriaRepository.CategoriaDeleteAsync(id);

        return (wasDeleted) ? Ok("Categoria excluída") : BadRequest("Nenhum dado foi alterado");
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
