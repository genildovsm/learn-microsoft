using apiCatalogo.Models;
using System.Reflection.Metadata.Ecma335;

namespace apiCatalogo.DTOs.Mappings
{
    /// <summary>
    /// Classe de extensão
    /// </summary>
    public static class CategoriaMappingExtensions
    {
        /// <summary>
        /// Converte a entidade Categoria para CategoriaDTO
        /// </summary>
        /// <param name="categoria">Instância de Categoria</param>
        /// <returns>
        /// Retorna uma instância de CategoriaDTO ou nulo
        /// </returns>
        public static CategoriaDTO? ToCategoriaDTO(this Categoria categoria)
        {
            if (categoria is null) return null;

            return new CategoriaDTO
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
                ImagemUrl = categoria.ImagemUrl
            };
        }

        /// <summary>
        /// Converte CategoriaRequestDTO em Categoria
        /// </summary>
        /// <param name="categoriaRequestDTO"></param>
        /// <param name="id">Id da categoria</param>
        /// <returns>Retorna uma instância de categoria</returns>
        public static Categoria ToCategoria(this CategoriaRequestDTO categoriaRequestDTO, int id = 0)
        {
            return new Categoria
            {
                Id = id,
                Nome = categoriaRequestDTO.Nome,
                ImagemUrl = categoriaRequestDTO.ImagemUrl
            };
        }

        /// <summary>
        /// Converte Categoria em CategoriaResponseDTO
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns></returns>
        public static CategoriaResponseDTO ToCategoriaResponseDTO(this Categoria categoria)
        {
            return new CategoriaResponseDTO
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
                ImagemUrl = categoria.ImagemUrl
            };
        }

        /// <summary>
        /// Converte CategoriaDTO para entidade Categoria 
        /// </summary>
        /// <returns>
        /// Retorna uma instância da entidade categoria
        /// </returns>
        public static Categoria? ToCategoria(this CategoriaDTO categoriaDTO)
        {
            if (categoriaDTO is null) return null;

            return new Categoria
            {
                Id = categoriaDTO.Id,
                Nome = categoriaDTO.Nome,
                ImagemUrl = categoriaDTO.ImagemUrl
            };
        }

        /// <summary>
        /// Converte uma lista de entidade Categoria em uma lista de CategoriaDTO
        /// </summary> 
        /// <param name="categorias">Lista de entidade Categoria</param>
        /// <returns>Retorna uma lista de CategoriaDTO</returns>
        public static IEnumerable<CategoriaDTO> ToCategoriaDTOList(this IEnumerable<Categoria> categorias)
        {
            if (categorias is null || !categorias.Any()) return [];

            return categorias.Select(c => new CategoriaDTO
            {
                Id = c.Id,
                Nome = c.Nome,
                ImagemUrl = c.ImagemUrl

            }).ToList();
        }
    }
}
