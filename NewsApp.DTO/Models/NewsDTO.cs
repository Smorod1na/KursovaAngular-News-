using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewsApp.DTO.Models
{
   public class NewsDTO
    {

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
        //[Required]
        public string CategoriId { get; set; }
        public string CategoriName { get; set; }
        public bool IsBlocked { get; set; }

    }
}
