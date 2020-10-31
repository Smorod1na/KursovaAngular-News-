using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NewsApp.DAL.Entity
{
    [Table("Categori")]
    public class Categori
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<News> CategoryNews { get; set; }

    }
}
