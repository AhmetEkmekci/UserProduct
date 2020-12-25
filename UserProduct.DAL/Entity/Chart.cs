using ServiceStack.DataAnnotations;

namespace UserProduct.DAL.Entity
{
    public class Cart : BaseEntity
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }

        public virtual User User { get; set; }
        public virtual Product Product { get; set; }

    }
}