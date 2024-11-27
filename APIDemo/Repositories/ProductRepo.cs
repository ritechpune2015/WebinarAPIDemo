using APIDemo.Dtos;
using APIDemo.Helpers;
using APIDemo.Interfaces;
using APIDemo.Mappers;
using APIDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace APIDemo.Repositories
{
    public class ProductRepo : IProductRepo
    {
        private readonly ProductContext _cntx;
        public ProductRepo(ProductContext cntx)
        {
            this._cntx = cntx;
        }

        public async Task<ProductDto> Create(ProductCreateDto product)
        {
            var model = product.MapToProduct();
            await this._cntx.AddAsync(model);
            await this._cntx.SaveChangesAsync();
            return model.MapToProductDto();
        }

        public async Task Delete(int id)
        {
            var model =await this._cntx.Products.FindAsync(id);
            this._cntx.Products.Remove(model);
            await this._cntx.SaveChangesAsync();
        }

        public async Task<List<ProductDto>> GetAll(QueryObject obj)
        {
            var products= this._cntx.Products.AsQueryable();
            if (obj.ProductName != null)
            {
                products = products.Where(p=>p.ProductName==obj.ProductName);
            }

            if (obj.SortBy == "ProductName")
            {
                products = obj.IsDescending ? products.OrderByDescending(p => p.ProductName) : products.OrderBy(p => p.ProductName);
            }

            int skipnumber = (obj.PageNumber - 1) * obj.PageSize;
            products = products.Skip(skipnumber).Take(obj.PageSize);
            return await products.Select(p=>p.MapToProductDto()).ToListAsync();
           
        }

        public async Task<ProductDto> GetById(int id)
        {
            var model= await this._cntx.Products.FindAsync(id);
            return model.MapToProductDto();
        }

        public async Task<ProductDto> Update(int id,ProductUpdateDto rec)
        {
            var oldrec = await this._cntx.Products.FindAsync(id);
            oldrec.ProductName = rec.ProductName;
            oldrec.Price = rec.Price;
            oldrec.ProductCategoryID = rec.ProductCategoryID;
            oldrec.MfgName = rec.MfgName;
            await this._cntx.SaveChangesAsync();
            return oldrec.MapToProductDto();
        }
    }
}
