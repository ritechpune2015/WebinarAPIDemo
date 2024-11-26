namespace APIDemo.Dtos
{
    public class ProductCreateDto
    {
        public string ProductName { get; set; }
        public string MfgName { get; set; }
        public decimal Price { get; set; }
        public int ProductCategoryID { get; set; }
    }
}
