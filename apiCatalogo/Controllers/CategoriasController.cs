using apiCatalogo.DTOs.Inputs;
using apiCatalogo.DTOs.Views;
using apiCatalogo.Filters;
using apiCatalogo.Models;
using apiCatalogo.Repositories;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult Get()
    {
        var categorias = _categoriaRepository.GetAll().ToList(); 

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
    public IActionResult Get(int id)
    {
        var categoria = _categoriaRepository.Get(c => c.Id == id);

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
    public IActionResult Post(CategoriaInputModel model)
    {
        var categoria = _categoriaRepository.Create(model);

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
    /// <param name="model">Instância do modelo de entrada de categoria</param>    
    /// <response code="200">Categoria atualizada</response>
    /// <response code="404">Categoria não encontrada</response>
    [HttpPut]
    [ProducesResponseType(typeof(CategoriaViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]    
    public IActionResult Put(CategoriaInputModel model)
    {
        if ( _categoriaRepository.Any(c => c.Id == model.Id) )
        {
            Categoria categoria = _categoriaRepository.Update(model);

            return Ok(categoria);
        }

        return BadRequest("Categoria não encontrada");
    }

    /// <summary>
    /// Deleta uma categoria
    /// </summary>
    /// <param name="id">Id da categoria</param>
    /// <response code="200">Categoria excluída</response>
    /// <response code="404">Categoria não encontrada</response>
    [HttpDelete("{id:int:min(1)}")]    
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public IActionResult Delete(int id)
    {
        Categoria? categoria = _categoriaRepository.Get(c => c.Id == id);

        if (categoria is not null)
        {
            _categoriaRepository.Delete(categoria);

            return Ok("Categoria excluída");
        }

        return NotFound("Categoria não encontrada");
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
