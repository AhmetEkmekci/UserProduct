using System.ComponentModel.DataAnnotations;

namespace UserProduct.Domain
{
    public class ProductDto : BaseContentDto
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}