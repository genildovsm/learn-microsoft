using apiCatalogo.Context;
using apiCatalogo.DTOs.Inputs;
using apiCatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiCatalogo.Controllers;

/// <summary>
/// Controlador de produtos
/// </summary>
/// <param name="context">Contexto da aplicação</param>
[ApiController]
[Route("[controller]")]
public class ProdutosController(ApiCatalogoDbContext context) : ControllerBase
{
    private readonly ApiCatalogoDbContext _context = context;

    /// <summary>
    /// Retorna uma lista de produtos
    /// </summary>
    /// <param name="model">Modelo de entrada da consulta</param>
    /// <returns></returns>
    /// <response code="200">A consulta retornou resultado</response>
    /// <response code="204">Consulta realizada com sucesso mas não retornou resultado</response>
    [HttpGet]
    [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Get([FromQuery] ProdutoInputModel model)
    {
        IEnumerable<Produto> produtos = await _context.Produtos
            .AsNoTracking()
            .Where(x =>
                (string.IsNullOrEmpty(model.Nome) || x.Nome.Contains(model.Nome)) &&
                (string.IsNullOrEmpty(model.Descricao) || x.Descricao.Contains(model.Descricao))
            ).ToListAsync();

        return Ok(produtos);
    }

    /// <summary>
    /// Retorna um produto
    /// </summary>
    /// <param name="id">Identificador do produto</param>
    /// <returns></returns>
    /// <response code="200">A consulta retornou resultado</response>
    /// <response code="204">Consulta realizada com sucesso mas não retornou resultado</response>
    [HttpGet("{id:int}", Name = "ObterProdutoPorId")]
    [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetById(int id)
    {
        Produto? produto = await _context.Produtos
            .AsNoTracking()
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

        return Ok(produto);
    }

    /// <summary>
    /// Cadastra um produto
    /// </summary>
    /// <param name="produto">Instância de produto</param>
    /// <returns></returns>
    /// <response code="400">Erro na criação do produto</response>
    /// <response code="201">Produto criado com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Produto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post(Produto produto)
    {
        if (produto is null)
            return BadRequest();

        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();

        return new CreatedAtRouteResult("ObterProdutoPorId", new { id = produto.Id }, produto);
    }

    /// <summary>
    /// Atualiza um produto existente no sistema
    /// </summary>
    /// <param name="id">Identificador do produto</param>
    /// <param name="model">Instância de produto</param>
    /// <returns>Retorna o produto atualizado</returns>    
    /// <response code="200">Produto atualizado com sucesso</response>
    /// <response code="400">
    /// Retorna em caso de: 
    /// - Dados inválidos no modelo
    /// - ID do produto não encontrado
    /// </response>
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Produto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(ProdutoInputModel model, int id)
    {
        Produto produto = model;
        produto.Id = id;

        _context.Entry(produto).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return Ok(produto);
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
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(String))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(String))]
    public async Task<IActionResult> Put(int id)
    {
        var produto = await _context.Produtos.FindAsync(id);

        if (produto is null) return NotFound("Produto não encontrado");

        _context.Produtos.Remove(produto);
        await _context.SaveChangesAsync();

        _context.Entry(produto).State = EntityState.Detached;

        return NoContent();
    }

}
