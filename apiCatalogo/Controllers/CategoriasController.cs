using apiCatalogo.DTOs;
using apiCatalogo.DTOs.Mappings;
using apiCatalogo.Filters;
using apiCatalogo.Models;
using apiCatalogo.Pagination;
using apiCatalogo.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace apiCatalogo.Controllers;

/// <summary>
/// Controlador de categorias
/// </summary>
[ApiController]
[Route("[controller]")]
public class CategoriasController : ControllerBase
{
    private readonly IUnitOfWork _uof;
        
    /// <summary>
    /// 
    /// </summary>
    /// <param name="uof"></param>
    public CategoriasController(IUnitOfWork uof)
    {        
        _uof = uof;
    }

    /// <summary>
    /// Obtém todas as categorias e seus produtos relacionados
    /// </summary>
    /// <response code="200">A consulta encontrou registros</response>
    /// <response code="204">A consulta não encontrou registros</response>
    [HttpGet("[action]")]
    [ProducesResponseType(typeof(IList<CategoriaDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<IList<CategoriaDTO>>> ObterCategoriaProdutos()
    {
        var categorias = await _uof.CategoriaRepository.GetAllAsync();
        var categoriasDTO = categorias.ToCategoriaDTOList();

        return (categoriasDTO is null) ? NoContent() : Ok(categoriasDTO);
    }

    /// <summary>
    /// Categorias paginadas
    /// </summary>
    /// <param name="categoriasParameters">Parâmetros de paginação</param>
    [HttpGet("pagination")]
    [ProducesResponseType(typeof(IEnumerable<Categoria>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<PagedList<Categoria>>> Get([FromQuery]CategoriasParameters categoriasParameters)
    {
        var categorias = await _uof.CategoriaRepository.GetCategoriasAsync(categoriasParameters);

        return ObterCategorias(categorias);
    }

    private ActionResult ObterCategorias(PagedList<Categoria> categorias)
    {
        var metadata = new
        {
            categorias.TotalCount,
            categorias.PageSize,
            categorias.CurrentPage,
            categorias.TotalPages,
            categorias.HasNext,
            categorias.HasPrevious
        };

        Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(metadata));

        return Ok(categorias);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="categoriasFiltro"></param>
    /// <returns></returns>
    [HttpGet("filter/nome/pagination", Name = "FiltroNomePagination")]
    [ProducesResponseType(typeof(PagedList<Categoria>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PagedList<Categoria>>> GetCategoriasFiltradas([FromQuery]CategoriasFiltroNome categoriasFiltro)
    {
        var categoriasFiltradas = await _uof.CategoriaRepository.GetCategoriasFiltroNomeAsync(categoriasFiltro);

        return ObterCategorias(categoriasFiltradas);
    }

    /// <summary>
    /// Obtém a categoria por id
    /// </summary>
    /// <param name="id">Identificador da categoria</param>
    /// <response code="200">Categoria encontrada</response>
    /// <response code="404">Nenhum registro encontrado</response>
    [HttpGet("{id:int:min(1)}", Name = "ObterCategoria")]
    [ProducesResponseType(typeof(CategoriaResponseDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string),StatusCodes.Status404NotFound)]    
    public ActionResult<CategoriaResponseDTO> Get(int id)
    {
        var categoria = _uof.CategoriaRepository.Find(id);

        if (categoria is null)
        {
            string message = $"Categoria com id={id} não encontrada";
            return NotFound(message);
        }

        var CategoriaResponseDTO = categoria.ToCategoriaResponseDTO();   

        return Ok(CategoriaResponseDTO);
    }

    /// <summary>
    /// Cria uma categoria
    /// </summary>
    /// <param name="categoriaRequestDTO">Modelo de entrada para categoria</param>    
    /// <response code="201">Categoria cadastrada</response>
    /// <response code="400">Categoria não informada</response>
    [HttpPost(Name = "CriarCategoria")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]    
    public async Task<IActionResult> Post(CategoriaRequestDTO categoriaRequestDTO)
    {
        var categoria = categoriaRequestDTO.ToCategoria();
            
        var novaCategoria = _uof.CategoriaRepository.Create(categoria);

        await _uof.CommitAsync();

        var categoriaResponseDTO = novaCategoria.ToCategoriaResponseDTO();

        return CreatedAtRoute("ObterCategoria", new { id = categoriaResponseDTO.Id }, categoriaResponseDTO);
    }

    /// <summary>
    /// Atualiza os dados da categoria
    /// </summary>
    /// <param name="id">Id da categoria a ser atualizada</param>
    /// <param name="categoriaRequestDTO">Instância do modelo de entrada de categoria</param>    
    /// <response code="200">Categoria atualizada</response>
    /// <response code="404">Categoria não encontrada</response>
    [HttpPut("{id:int:min(1)}", Name = "AtualizarCategoria")]
    [ProducesResponseType(typeof(CategoriaResponseDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CategoriaResponseDTO>> Put(int id, CategoriaRequestDTO categoriaRequestDTO)
    {
        if ( _uof.CategoriaRepository.Any(c => c.Id == id) )
        {
            var categoria = categoriaRequestDTO.ToCategoria();
            categoria.Id = id;

            var categoriaAtualizada = _uof.CategoriaRepository.Update(categoria);

            await _uof.CommitAsync();

            var categoriaResponseDTO = new CategoriaResponseDTO
            {
                Id = categoriaAtualizada.Id,
                Nome = categoriaAtualizada.Nome,
                ImagemUrl = categoriaAtualizada.ImagemUrl
            };

            return Ok(categoriaResponseDTO);
        }

        return NotFound("Categoria não encontrada");
    }

    /// <summary>
    /// Deleta uma categoria
    /// </summary>
    /// <param name="id">Id da categoria</param>
    /// <response code="204">Categoria excluída</response>
    /// <response code="404">Categoria não encontrada</response>
    [HttpDelete("{id:int:min(1)}")]    
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var categoria = _uof.CategoriaRepository.Find(id);

        if (categoria is null) return NotFound("Categoria não encontrada");
       
        _uof.CategoriaRepository.Delete(categoria);

        await _uof.CommitAsync();

        return NoContent();        
    }

    /// <summary>
    /// Exemplificação do uso de Filters a nível de actions
    /// </summary>
    [HttpGet("[action]", Name = "usando-filters")]
    [ServiceFilter(typeof(ApiLoggingFilter))]
    [ProducesResponseType(typeof(string),StatusCodes.Status200OK)]
    public ActionResult<string> UsandoFilters()
    {
        return Ok("Esta action está usando o recurso de Filters");
    }
}
