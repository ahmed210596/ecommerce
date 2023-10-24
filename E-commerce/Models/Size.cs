namespace E_commerce.Models
{
    public class Size
    {
        public int SizeId { get; set; } 
        public String SizeName { get; set; }
        public ICollection<ProductSize> productSizes { get; set; }

    }
}
