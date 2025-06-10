using apiCatalogo.Models;
using apiCatalogo.Repositories;
using Microsoft.AspNetCore.Mvc;

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
    public ActionResult<IEnumerable<Produto>> GetProdutosCategoria(int id)
    {
        var produtos = _uof.ProdutoRepository.GetProdutosPorCategoria(id);

        if (produtos is null)
        {
            string msg = $"Produto com a categoria={id} não localizado";

            _logger.LogWarning(msg);

            return NotFound(msg);
        }

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
    public ActionResult Get()
    {
        var produtos = _uof.ProdutoRepository.GetAll();

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
    public ActionResult<Produto> GetById(int id)
    {
        Produto? produto = _uof.ProdutoRepository.Get(p => p.Id == id);

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
    public ActionResult Post(Produto produto)
    {
        if (produto is null) return BadRequest();

        var novoProduto = _uof.ProdutoRepository.Create(produto);

        _uof.Commit();

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
    public ActionResult<Produto> Put(int id, Produto produto)
    {
        produto.Id = id;

        var produtoAtualizado = _uof.ProdutoRepository.Update(produto);

        _uof.Commit();

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
    public ActionResult Put(int id)
    {
        var produto = _uof.ProdutoRepository.Get(p =>  p.Id == id);

        if (produto is null)
        {
            string msg = $"Produto com Id={id} não encontrado";

            _logger.LogWarning(msg);

            return NotFound(msg);
        }

        _uof.ProdutoRepository.Delete(produto);

        _uof.Commit();

        return NoContent();
    }

}
