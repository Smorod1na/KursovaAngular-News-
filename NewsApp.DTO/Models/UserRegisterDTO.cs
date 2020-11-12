using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewsApp.DTO.Models
{
   public class UserRegisterDTO
    {
        [Required(ErrorMessage = "Not text")]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Not text")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
       
        [Required(ErrorMessage = "Not text")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Not text")]
        public string FullName { get; set; }
        //[Required(ErrorMessage = "Not text")]

        //public string Image { get; set; }
        [Required(ErrorMessage = "Not text")]
        public string Address { get; set; }
    }
}
