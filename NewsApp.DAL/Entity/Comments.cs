using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NewsApp.DAL.Entity
{
    [Table("Comments")]
    public class Comments
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string UserName { get; set; }
        [ForeignKey("News")]
        public string NewsId { get; set; }
        public virtual News News { get; set; }
    }
}
