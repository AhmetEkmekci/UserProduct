using System;
using System.ComponentModel.DataAnnotations;

namespace UserProduct.Domain
{
    public abstract class BaseDto
    {
        [Key]
        public int Id { get; set; }
    }

    public abstract class BaseContentDto : BaseDto
    {
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsActive { get; set; }
    }
}