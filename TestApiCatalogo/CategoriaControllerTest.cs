using apiCatalogo.Controllers;
using apiCatalogo.DTOs;
using apiCatalogo.Models;
using apiCatalogo.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Drawing;
using System.Runtime.Intrinsics.X86;

namespace TestApiCatalogo
{
    public class CategoriaControllerTest
    {
        private readonly Mock<IUnitOfWork> _mockUOW;
        private readonly CategoriasController _categoriasController;

        public CategoriaControllerTest()
        {
            _mockUOW = new Mock<IUnitOfWork>();
            _categoriasController = new CategoriasController(_mockUOW.Object);
        }

        [Fact]
        public async Task ObterCategoriaProdutos_Ok()
        {
            // Arrange

            IList<Categoria> categoriasEsperadas = [
                new () { Id = 1, Nome = "Eletrônicos", ImagemUrl = "eletronicos.jpg" },
                new () { Id = 2, Nome = "Roupas", ImagemUrl = "roupas.jpg" },
                new () { Id = 3, Nome = "Livros", ImagemUrl = "livros.jpg" },
            ];

            // Define que quando GetAllAsync() for chamado no repositório de categorias,
            // deve retornar as categorias esperadas
            _mockUOW.Setup( repo => repo.CategoriaRepository.GetAllAsync() )
                .ReturnsAsync(categoriasEsperadas);

            // Action

            // Executa o método que está sendo testado no controller
            var resultado = await _categoriasController.ObterCategoriaProdutos();

            // Assert
            
            // Verifica se o resultado é do tipo OkObjectResult (status HTTP 200)            
            var okResult = Assert.IsType<OkObjectResult>(resultado.Result);

            // Extrai o valor do resultado e verifica se é uma lista de CategoriaDTO
            // exactMatch: false: Permite tipos derivados ou implementações da interface
            var categoriaProdutos = Assert.IsType<IList<CategoriaDTO>>(okResult.Value, exactMatch: false);

            // Verifica se a quantidade de categorias retornadas é igual a 3
            Assert.Equal(3, categoriaProdutos.Count);

            // Verifica se o método GetAllAsync() foi chamado exatamente uma vez
            _mockUOW.Verify(repo => repo.CategoriaRepository.GetAllAsync(), Times.Once());
        }
    }
} 
