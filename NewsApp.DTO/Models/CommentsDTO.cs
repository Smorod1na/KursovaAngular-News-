using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.DTO.Models
{
    public class CommentsDTO
    {
        public string DatePost { get; set; }
        public string Text { get; set; }
        public string UserName { get; set; }
        public string NewsId { get; set; }
    }
}
