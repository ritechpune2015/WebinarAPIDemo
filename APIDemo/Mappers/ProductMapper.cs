using APIDemo.Dtos;
using APIDemo.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace APIDemo.Mappers
{
    public static class ProductMapper
    {
        public static ProductDto MapToProductDto(this Product rec)
        {
            return new ProductDto
            {
                 MfgName=rec.MfgName,
                 Price=rec.Price,
                 ProductCategoryID=rec.ProductCategoryID,
                 ProductID=rec.ProductID,
                 ProductName=rec.ProductName
            };
        }

        public static Product MapToProduct(this ProductCreateDto rec)
        {
            return new Product
            {
                MfgName = rec.MfgName,
                Price = rec.Price,
                ProductCategoryID = rec.ProductCategoryID,
                ProductName = rec.ProductName
            };
        }

        public static Product MapToProduct(this ProductUpdateDto rec)
        {
            return new Product
            {
                ProductID= rec.ProductID,
                MfgName = rec.MfgName,
                Price = rec.Price,
                ProductCategoryID = rec.ProductCategoryID,
                ProductName = rec.ProductName
            };
        }
    }
}
