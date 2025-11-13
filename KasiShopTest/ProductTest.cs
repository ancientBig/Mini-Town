using kasiShop.Entities;
using kasiShop.Entities.Model;
using kasiShop.Helpers;
using kasiShop.Service;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace KasiShopTest
{
    public class ProductTest
    {
        private AppDbContext _context;
        private IProductService productService;

        public ProductTest()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new AppDbContext(options);
            _context.Database.EnsureCreated();
            productService = new ProductService(_context);
            SeedData(_context).Wait();
        }

        private async Task SeedData(AppDbContext context)
        {
            var product = new Product("test 1", " This is testing product", 20);
            context.Products.Add(product);
            await context.SaveChangesAsync();
        }


        [Fact]
        public async void WhenUpdatingProduct_GivenInformationIsCorrect_Then_successullyUdpate()
        {
            
            var inputModel = new ProductUpdateInputModel() { Description = "New info", Name = "Updated info", ProductID = 1 };
            var productExists = await _context.Products.FirstOrDefaultAsync(p => p.ProductID == inputModel.ProductID);
            Xunit.Assert.NotNull(productExists);

            await productService.UpdateProduct(inputModel);
            var productUpdated = await _context.Products.FirstOrDefaultAsync(p => p.ProductID == inputModel.ProductID);
            Xunit.Assert.Equal(productUpdated.Name, inputModel.Name);
        }
    }
}