namespace APIDemo.Dtos
{
    public class ProductUpdateDto
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string MfgName { get; set; }
        public decimal Price { get; set; }
        public int ProductCategoryID { get; set; }
    }
}
