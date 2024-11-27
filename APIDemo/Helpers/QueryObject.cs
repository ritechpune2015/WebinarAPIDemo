namespace APIDemo.Helpers
{
    public class QueryObject
    {
        public string ProductName { get; set; }
        public string SortBy { get; set; }
        public bool IsDescending { get; set; }
        public int PageSize { get; set; } = 4;
        public int PageNumber { get; set; } = 1;
    }
}
