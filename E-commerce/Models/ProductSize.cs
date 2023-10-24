using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Models
{
    public class ProductSize
    {
        public int SizeId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        [ForeignKey("SizeId")]
        public Size Size { get; set; }
        public int ProductId { get; set; }
    }
}
