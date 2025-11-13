using System.ComponentModel.DataAnnotations;

namespace kasiShop.Entities.Model
{
    public class ProductDto
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public ProductDto() { }
        public ProductDto(int productID, string name, string description, decimal price)
        {
            ProductID = productID;
            Name = name;
            Description = description;
            Price = price;
        }

        public ProductDto toDto(Product product)
        {
            return new ProductDto(product.ProductID,
                product.Name,
                product.Description,
                product.Price);
        }
    }

    
}
