
using System.ComponentModel.DataAnnotations;

namespace UserProduct.Domain
{
    public class CartDto : BaseDto
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }

        public ProductDto Product { get; set; }

    }
}