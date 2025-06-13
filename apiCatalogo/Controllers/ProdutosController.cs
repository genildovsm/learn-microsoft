using apiCatalogo.Models;
using apiCatalogo.Pagination;
using apiCatalogo.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace apiCatalogo.Controllers;

/// <summary>
/// 
/// </summary>
/// <param name="uof"></param>
/// <param name="logger"></param>
[ApiController]
[Route("[controller]")]
public class ProdutosController(IUnitOfWork uof, ILogger<ProdutosController> logger) : ControllerBase
{
    private readonly IUnitOfWork _uof = uof;
    private readonly ILogger<ProdutosController> _logger = logger;

    /// <summary>
    /// Obter os produtos com base no Id da categoria informada
    /// </summary>
    /// <param name="id">Id da categoria</param>
    [HttpGet("[action]/{id:int:min(1)}")]
    [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<Produto>>> GetProdutosCategoria(int id)
    {
        var produtos = await _uof.ProdutoRepository.GetProdutosPorCategoriaAsync(id);

        if (produtos is null)
        {
            string msg = $"Produto com a categoria={id} não localizado";

            _logger.LogWarning(msg);

            return NotFound(msg);
        }

        return Ok(produtos);
    }

    /// <summary>
    /// Implementação de paginação
    /// </summary>
    /// <param name="produtosParameters">Parâmetros de paginação para produtos</param>
    /// <returns>Retorna os registros usando paginação</returns>
    [HttpGet("pagination", Name = "produtos-pagination")]
    [ProducesResponseType(typeof(PagedList<Produto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<PagedList<Produto>>> Get([FromQuery]ProdutosParameters produtosParameters)
    {
        var produtos = await _uof.ProdutoRepository.GetProdutosAsync(produtosParameters);

        return ObterProdutos(produtos);
    }

    /// <summary>
    /// Obtém uma lista de produtos paginada com base no filtro informado
    /// </summary>
    /// <param name="produtosFiltroParameters"></param>
    /// <returns></returns>
    [HttpGet("filter/preco/pagination", Name = "FilterPrecoPagination")]
    [ProducesResponseType(typeof(PagedList<Produto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<PagedList<Produto>>> GetProdutosFilterPreco([FromQuery]ProdutosFiltroPreco produtosFiltroParameters)
    {
        var produtos = await _uof.ProdutoRepository.GetProdutosFiltroPrecoAsync(produtosFiltroParameters);

        return ObterProdutos(produtos);
    }

    /// <summary>
    /// Método comum às actions que retornam produtos paginados
    /// </summary>
    /// <param name="produtos">Produtos</param>
    /// <returns></returns>
    private ActionResult<PagedList<Produto>> ObterProdutos(PagedList<Produto> produtos)
    {
        var metadata = new
        {
            produtos.TotalCount,
            produtos.PageSize,
            produtos.CurrentPage,
            produtos.TotalPages,
            produtos.HasNext,
            produtos.HasPrevious
        };

        Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(metadata));

        return Ok(produtos);
    }

    /// <summary>
    /// Retorna uma lista de produtos
    /// </summary>
    /// <response code="200">A consulta retornou resultado</response>
    /// <response code="204">Consulta realizada com sucesso mas não retornou resultado</response>
    [HttpGet]
    [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> Get()
    {
        var produtos = await _uof.ProdutoRepository.GetAllAsync();

        if (produtos is null)
        {
            string msg = $"Nenhum produto localizado";

            _logger.LogWarning(msg);

            return NotFound(msg);
        }

        return Ok(produtos);
    }

    /// <summary>
    /// Retorna um produto
    /// </summary>
    /// <param name="id">Identificador do produto</param>
    /// <response code="200">A consulta retornou resultado</response>
    /// <response code="204">Consulta realizada com sucesso mas não retornou resultado</response>
    [HttpGet("{id:int}", Name = "ObterProdutoPorId")]
    [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<Produto>> GetById(int id)
    {
        Produto? produto = await _uof.ProdutoRepository.GetAsync(p => p.Id == id);

        return Ok(produto);
    }

    /// <summary>
    /// Cadastra um produto
    /// </summary>
    /// <param name="produto">Instância de produto</param>
    /// <response code="400">Erro na criação do produto</response>
    /// <response code="201">Produto criado com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Produto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Post(Produto produto)
    {
        if (produto is null) return BadRequest();

        var novoProduto = _uof.ProdutoRepository.Create(produto);

        await _uof.CommitAsync();

        return new CreatedAtRouteResult("ObterProdutoPorId", new { id = novoProduto.Id }, novoProduto);
    }

    /// <summary>
    /// Atualiza um produto existente no sistema
    /// </summary>
    /// <param name="id">Identificador do produto</param>
    /// <param name="produto">Instância de produto</param> 
    /// <response code="200">Produto atualizado com sucesso</response>
    /// <response code="400">
    /// Retorna em caso de: 
    /// - Dados inválidos no modelo
    /// - ID do produto não encontrado
    /// </response>
    [HttpPut("{id:int:min(1)}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Produto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Produto>> Put(int id, Produto produto)
    {
        produto.Id = id;

        var produtoAtualizado = _uof.ProdutoRepository.Update(produto);

        await _uof.CommitAsync();

        return Ok(produtoAtualizado);
    }

    /// <summary>
    /// Remove um produto existente no sistema
    /// </summary>
    /// <param name="id">Identificador do produto</param>
    /// <response code="204">Produto removido</response>
    /// <response code="400">
    /// Retorna em caso de: 
    /// - Dados enviados são inconsistentes
    /// </response>
    /// <response code="404">Produto não encontrado</response>
    [HttpDelete("{id:int:min(1)}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(String))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(String))]
    public async Task<ActionResult> Put(int id)
    {
        var produto = await _uof.ProdutoRepository.GetAsync(p => p.Id == id);

        if (produto is null)
        {
            string msg = $"Produto com Id={id} não encontrado";

            _logger.LogWarning(msg);

            return NotFound(msg);
        }

        _uof.ProdutoRepository.Delete(produto);

        await _uof.CommitAsync();

        return NoContent();
    }

}
