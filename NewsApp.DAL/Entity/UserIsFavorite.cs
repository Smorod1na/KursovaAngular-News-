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
        public bool IsFavorite { get; set; }
        [Required]
        public string UserEmail { get; set; }
        [ForeignKey("News")]
        public string NewsId { get; set; }
        public virtual News News { get; set; }
    }
}
