namespace APIDemo.Dtos
{
    public class ProductDto:ProductCreateDto
    {
        public int ProductID { get; set; }
        public string ProductCategoryName { get; set; }

    }
}
