using System.ComponentModel.DataAnnotations;

namespace UserProduct.Domain
{
    public class UserDto : BaseContentDto
    {
        [MaxLength(11)]
        [MinLength(11)]
        [Required]
        public string IdentityNumber { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string EMailAddress { get; set; }


    }
}