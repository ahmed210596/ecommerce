using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
            public string Comment { get; set;}
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]

        public Product Product { get; set; }
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]

        public ApplicationUser User { get; set; }

    }
}
