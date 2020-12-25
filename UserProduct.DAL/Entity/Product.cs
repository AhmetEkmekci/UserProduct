using ServiceStack.DataAnnotations;

namespace UserProduct.DAL.Entity
{
    public class Product : BaseContentEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}