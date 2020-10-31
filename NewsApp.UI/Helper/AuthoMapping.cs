using AutoMapper;
using NewsApp.DAL.Entity;
using NewsApp.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApp.UI.Helper
{
    public class AuthoMapping:Profile
    {
        public AuthoMapping()
        {
            CreateMap<News,NewsDTO>();
            CreateMap<NewsDTO,News>().ForMember(x => x.Id, opt => Guid.NewGuid().ToString())
              ; 

            CreateMap<Categori, CategoriDTO>();
            CreateMap<CategoriDTO, Categori>().ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
