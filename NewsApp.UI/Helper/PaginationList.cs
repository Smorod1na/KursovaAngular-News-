using NewsApp.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApp.UI.Helper
{
    public class PaginationList
    {
        public List<NewsDTO> News { get; set; }
        public int countButton { get; set; }
        public PaginationList()
        {
            News = new List<NewsDTO>();
        }
    }
}
