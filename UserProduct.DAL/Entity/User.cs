using ServiceStack.DataAnnotations;
using System.Collections.Generic;

namespace UserProduct.DAL.Entity
{
    public class User : BaseContentEntity
    {
        [Required]
        [StringLength(11,11)]
        public string IdentityNumber { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        [Unique]
        public string EMailAddress { get; set; }

        public virtual ICollection<Cart> Cart { get; set; }

    }
}