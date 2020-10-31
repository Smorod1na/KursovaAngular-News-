using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewsApp.DTO.Models
{
   public class UserLoginDTO
    {
        [Required(ErrorMessage = "Not text")]
        [EmailAddress(ErrorMessage = "Inavalid email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Not text")]

        public string Password { get; set; }
    }
}
