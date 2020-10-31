using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.DTO.Models
{
   public class UserIsFavoriteDTO
    {
        public string NewsId { get; set; }
        public string UserId { get; set; }
        public bool isFavorite { get; set; }
    }
}
