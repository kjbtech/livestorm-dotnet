namespace KJBTech.Livestorm
{
    public class PaginationParameter
    {
        private const int DefaultMaxElementByPage = 50;
        public int PageNumber { get; private set; }
        private int _pageSize = DefaultMaxElementByPage;

        public PaginationParameter(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public PaginationParameter(int pageNumber)
        {
            PageNumber = pageNumber;
            PageSize = DefaultMaxElementByPage;
        }

        public PaginationParameter()
        {
            PageNumber = 0;
            PageSize = DefaultMaxElementByPage;
        }

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > DefaultMaxElementByPage) ? DefaultMaxElementByPage : value;
            }
        }
    }
}
