namespace apiCatalogo.Pagination
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class QueryStringParameters
    {
        /// <summary>
        /// Máximo de registros por página
        /// </summary>
        const int maxPageSize = 50;

        /// <summary>
        /// Número da página
        /// </summary>
        public int PageNumber { get; set; } = 1;

        private int _pageSize = maxPageSize;

        /// <summary>
        /// Quantidade de registros por página
        /// </summary>
        public int PageSize
        {
            get { 
                return _pageSize; 
            }
            set { 
                _pageSize = (value > maxPageSize) ? maxPageSize : value; 
            }
        }
    }
}
