namespace apiCatalogo.Pagination
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">Classe genérica</typeparam>
    public class PagedList<T> : List<T> where T : class
    {
        /// <summary>
        /// Página atual
        /// </summary>
        public int CurrentPage { get; private set; }

        /// <summary>
        /// Total de páginas
        /// </summary>
        public int TotalPages { get; private set; }

        /// <summary>
        /// Número de registros por página
        /// </summary>
        public int PageSize { get; private set; }

        /// <summary>
        /// Quantidade de registros retornados
        /// </summary>
        public int TotalCount { get; private set; }

        /// <summary>
        /// Verifica se existe página anterior
        /// </summary>
        public bool HasPrevious => CurrentPage > 1;

        /// <summary>
        /// Verifica se existe próxima página
        /// </summary>
        public bool HasNext => CurrentPage < TotalPages;
        
        /// <param name="items">Dados retornados pela consulta</param>
        /// <param name="count">Quantidade de registros</param>
        /// <param name="pageNumber">Número da página atual</param>
        /// <param name="pageSize">Quantidade de registros por página</param>
        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            AddRange(items);
        }
       
        /// <param name="source">Consulta não materializada</param>
        /// <param name="pageNumber">Número da página atual</param>
        /// <param name="pageSize">Quantidade de registros por página</param>
        /// <returns></returns>
        public static PagedList<T> ToPagedList(IQueryable<T> source, int pageNumber, int pageSize)
        {
            int count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
