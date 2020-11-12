using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NewsApp.DAL.Entity
{
   public class News
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string ManagerId { get; set; }
        [Required]
        public string ManagerName { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string DatePost { get; set; }
        [ForeignKey("Categori")]
        public string CategoriId { get; set; }
        [Required]
        public string CategoriName { get; set; }

        public bool IsBlocked { get; set; }
        public virtual Categori Categori { get; set; }

        public virtual ICollection<Comments> NewsComments { get; set; }

        public virtual ICollection<UserIsFavorite> UserIsFavorites { get; set; }

    }
}
