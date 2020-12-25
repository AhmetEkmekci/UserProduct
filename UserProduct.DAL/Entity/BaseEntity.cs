using System;
using System.ComponentModel.DataAnnotations;

namespace UserProduct.DAL.Entity
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
    public abstract class BaseContentEntity : BaseEntity
    {
        public BaseContentEntity()
        {
            CreateDate = DateTime.Now;
            IsDeleted = false;
            IsActive = true;
        }
        
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}