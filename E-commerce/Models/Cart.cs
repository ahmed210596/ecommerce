using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Models
{
    public class Cart
    {
        public int CartId { get; set; } 
        public decimal quantity { get; set; } 
         public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }
    }
}
