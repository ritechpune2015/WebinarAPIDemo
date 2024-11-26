using Microsoft.EntityFrameworkCore;

namespace APIDemo.Models
{
    public class ProductContext:DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> opt):base(opt)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductCategory>().HasData(
                 new ProductCategory() {ProductCategoryID=1,ProductCategoryName="Electornics"},
                 new ProductCategory() { ProductCategoryID = 2, ProductCategoryName = "Books" }
                );

            modelBuilder.Entity<Product>().HasData(
                 new Product() {
                     ProductID=1,
                     ProductName="Mouse",
                     MfgName="Logitech", 
                     Price=550,ProductCategoryID=1
                 },
                new Product()
                {
                    ProductID = 2,
                    ProductName = "Let us C",
                    MfgName = "Kanetkar",
                    Price = 750,
                    ProductCategoryID =2
                }
                );
        }

        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
