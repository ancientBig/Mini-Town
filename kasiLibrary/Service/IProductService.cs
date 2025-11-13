using kasiShop.Entities.Model;

namespace kasiShop.Service
{
    public interface IProductService
    {
        Task<bool> AddProduct(ProductInputModel model);
        Task<bool> RemoveProductById(int productId);
        Task<ProductDto> UpdateProduct(ProductUpdateInputModel model);
        Task<ProductDto> GetProduct(int productId);
    }
}
