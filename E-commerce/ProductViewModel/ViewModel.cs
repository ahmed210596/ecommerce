using E_commerce.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.ProductViewModel
{
    public class ViewModel
    {
        
        public int ProductId { get; set; }
        public string? ProdutName { get; set; }
        public string? ProductDescription { get; set; }
        public decimal Price { get; set; }
        public string ?ProductImage { get; set; }
        public int CategoryId { get; set; }
        
        public ICollection<Size> ? productSizes { get; set; }
        public ICollection<int>? SelectedtSizeId { get; set; }

    }
}
