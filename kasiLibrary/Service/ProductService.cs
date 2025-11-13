using kasiShop.Entities;
using kasiShop.Entities.Model;
using kasiShop.Helpers;
using Microsoft.EntityFrameworkCore;

namespace kasiShop.Service
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext context;

        public ProductService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> AddProduct(ProductInputModel model)
        {
            var newProduct = new Product(model.Name, model.Description, model.Price);
            await context.Products.AddAsync(newProduct);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveProductById(int productId)
        {
            var product = await context.Products.FirstOrDefaultAsync(p =>p.ProductID == productId) ?? throw new NullReferenceException("product not found");
            context.Products.Remove(product);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<ProductDto> UpdateProduct(ProductUpdateInputModel model)
        {
            var product = await context.Products.FirstOrDefaultAsync(p => p.ProductID == model.ProductID) ?? throw new NullReferenceException("product not found");
            product.Update(model.Name, model.Description, model.Price);
            context.Products.Update(product);
            await context.SaveChangesAsync();
            var dto = new ProductDto();
            return  dto.toDto(product);
        }

        public async Task<ProductDto> GetProduct(int productId)
        {
            var product = await context.Products.FirstOrDefaultAsync(p => p.ProductID == productId) ?? throw new NullReferenceException("product not found");
            var dto = new ProductDto();
            return dto.toDto(product);
        }
    }
}
