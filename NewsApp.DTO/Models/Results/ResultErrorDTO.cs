using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.DTO.Models.Results
{
   public class ResultErrorDTO:ResultDTO
    {
        public List<string> Errors { get; set; }
    }
}
