using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewsApp.DAL.Entity
{
   public class UserAdditional
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Address { get; set; }
        public string Image { get; set; }
        public virtual User User { get; set; }

        public string FullName { get; set; }
        public string DataRegister { get; set; }
        public string UserRole { get; set; }
        public string PublishCount { get; set; }
    }
}
