using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsApp.DAL.Entity;
using NewsApp.Domain.Interfaces;
using NewsApp.DTO.Models;
using NewsApp.DTO.Models.Results;

namespace NewsApp.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly ICategoriService _categoriService;

        private readonly INewsService _newsService;
        private readonly IMapper _mapper;
        public NewsController(INewsService newsService,IMapper mapper, ICategoriService categoriService)
        {
            _categoriService = categoriService;
            _newsService = newsService;
            _mapper = mapper;
        }

        [HttpGet]
        public List<NewsDTO> getAllNews()
        {
            var newsList = _newsService.GetAllNews().ToArray();
            var newsListDTO = _mapper.Map<IEnumerable<NewsDTO>>(newsList).ToList();
            for (int i = 0; i < newsList.Length; i++)
            {
                newsListDTO[i].CategoriName = _categoriService.getCategori(newsList[i].CategoriId).Name.ToString();
            }

            return newsListDTO;
        }
        [HttpPost("addnews")]
        public async Task<ResultDTO> addNews([FromBody]NewsDTO news)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return new ResultDTO
                    {
                        Status = 400,
                        Message = "model is not valit"
                    };
                }
               
                var categoriAll = _categoriService.GetAllCategori();
                var currentCategorie = categoriAll.FirstOrDefault(x => x.Name == news.CategoriId);

                var newNews = _mapper.Map<News>(news);
                newNews.CategoriId = currentCategorie.Id;
                newNews.Categori = currentCategorie;

                _newsService.AddNews(newNews);
                return new ResultDTO
                {
                    Status = 200,
                    Message = newNews.Id
                };
            }
            catch(Exception e)
            {
                return new ResultDTO
                {
                    Status = 500,
                    Message = e.Message
                };
            }
        }

        [HttpPost("setFavorite")]
        public async Task<ResultDTO> setFavorite([FromBody]UserIsFavoriteDTO favorite)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return new ResultDTO
                    {
                        Status = 400,
                        Message = "model is not valit"
                    };
                }
                return new ResultDTO
                {
                    Status = 200,
                    Message ="Ok"
                };
            }
            catch (Exception e)
            {
                return new ResultDTO
                {
                    Status = 500,
                    Message = e.Message
                };
            }
        }
    }
}