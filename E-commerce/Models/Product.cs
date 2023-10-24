using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProdutName { get; set; }
         public string ProductDescription { get; set; }
         public decimal Price { get; set; }
        public string ProductImage { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; private set; }
        public ICollection<ProductSize> productSizes { get; set; }
        public ICollection<Review> reviews { get; set; }
    }
}
