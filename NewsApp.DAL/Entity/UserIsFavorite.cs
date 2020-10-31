using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NewsApp.DAL.Entity
{
   public class UserIsFavorite
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string NewsId { get; set; }
        [Required]
        public bool IsFavorite { get; set; }
        [ForeignKey("UserAdditional")]
        public string UserAdditionalId { get; set; }
        public virtual UserAdditional UserAdditional { get; set; }
    }
}
