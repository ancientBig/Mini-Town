using System.ComponentModel.DataAnnotations;

namespace kasiShop.Entities.Model
{
    public class ProductUpdateInputModel
    {
        [Required]
        public int ProductID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
