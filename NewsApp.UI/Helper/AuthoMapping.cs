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
            CreateMap<NewsDTO,News>().ForMember(x => x.Id, opt =>opt.MapFrom(x=> Guid.NewGuid()));

            CreateMap<Comments, CommentsDTO>();
            CreateMap<CommentsDTO, Comments>().ForMember(x => x.Id, opt => opt.MapFrom(x => Guid.NewGuid()));

            CreateMap<Categori, CategoriDTO>();
            CreateMap<CategoriDTO, Categori>().ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<UserAdditional, UserAdditionalDTO>();
            CreateMap<UserAdditionalDTO, UserAdditional>().ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
