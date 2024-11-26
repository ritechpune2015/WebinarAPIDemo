namespace APIDemo.Models
{
    public class ProductCategory
    {
        public int ProductCategoryID { get; set; }
        public string ProductCategoryName { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
