using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewsApp.DTO.Models
{
   public class CategoriDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
