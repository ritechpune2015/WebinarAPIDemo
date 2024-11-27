using APIDemo.Dtos;
using APIDemo.Helpers;

namespace APIDemo.Interfaces
{
    public interface IProductRepo
    {
        Task<List<ProductDto>> GetAll(QueryObject query);
        Task<ProductDto> GetById(int id);
        Task<ProductDto> Create(ProductCreateDto product);
        Task<ProductDto> Update(int id,ProductUpdateDto product);
        Task Delete(int id);
    }
}
