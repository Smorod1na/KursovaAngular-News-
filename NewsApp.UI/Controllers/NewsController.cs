using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsApp.DAL;
using NewsApp.DAL.Entity;
using NewsApp.Domain.Interfaces;
using NewsApp.DTO.Models;
using NewsApp.DTO.Models.Results;
using NewsApp.UI.Helper;

namespace NewsApp.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly ICategoriService _categoriService;
        private readonly ICommentService _commentService;
        private readonly EFContext _eFContext;

        private readonly INewsService _newsService;
        private readonly IUserService _usertService;

        private readonly IMapper _mapper;
        public NewsController(INewsService newsService,IMapper mapper, 
            ICategoriService categoriService,ICommentService commentService,
            EFContext eFContext, IUserService usertService)
        {
            _commentService = commentService;
            _categoriService = categoriService;
            _newsService = newsService;
            _mapper = mapper;
            _eFContext = eFContext;
            _usertService = usertService;
        }
        //[Authorize]
        [HttpGet]
        public List<NewsDTO> getAllNews()
        {
            var newsList = _newsService.GetAllNews().ToArray();
            var newsListDTO = _mapper.Map<IEnumerable<NewsDTO>>(newsList).ToList();
  

            return newsListDTO;
        }

        [HttpGet("getlistfavorite/{email}")]
        public List<NewsDTO> getListFavorite([FromRoute]string email)
        {
            var allUserFavorite = _newsService.GetAllFavorite().Where(x => x.UserEmail == email).ToArray();
            var allNews = _newsService.GetAllNews().ToList();
            var allFavoriteNews = new List<NewsDTO>();
            foreach(var item in allUserFavorite)
            {
                if (allNews.FirstOrDefault(x => x.Id == item.NewsId) != null&&
                    item.IsFavorite==true)
                    allFavoriteNews.Add(_mapper.Map<NewsDTO>(allNews.FirstOrDefault(x => x.Id == item.NewsId)));
            }
                return allFavoriteNews;
        }
        [HttpGet("{value}/{filter}")]
        public PaginationList getPagNews([FromRoute]int value,[FromRoute] string filter)
        {
            if (filter == "null")
            {
                var newsList = _newsService.GetAllNews().ToArray();
                var newsListDTO = _mapper.Map<IEnumerable<NewsDTO>>(newsList).ToList();

                int number_1 = value * 6 - 6;
                int number_2 = value * 6;
                var modelForm = new PaginationList();
                for (int i = number_1; i < number_2; i++)
                {
                        try
                        {
                            modelForm.News.Add(newsListDTO[i]);
                        }
                        catch(ArgumentOutOfRangeException e)
                        {

                        }
                }
                int count = newsList.Length / 6;
                if (newsList.Length % 6 > 0)
                    modelForm.countButton = count + 1;
                else
                    modelForm.countButton = count;
                return modelForm;
            }
            else
            {
                var allCategorie = _categoriService.GetAllCategori().FirstOrDefault(x => x.Name == filter);
                if(allCategorie==null)
                {
                    var newsList = _newsService.GetAllNews().Where(x=>x.ManagerName==filter).ToArray();
                    var newsListDTO = _mapper.Map<IEnumerable<NewsDTO>>(newsList).ToList();

                    int number_1 = value * 6 - 6;
                    int number_2 = value * 6;
                    var modelForm = new PaginationList();
                    for (int i = number_1; i < number_2; i++)
                    {
                        try
                        {
                            modelForm.News.Add(newsListDTO[i]);
                        }
                        catch (ArgumentOutOfRangeException e)
                        {

                        }
                    }
                    int count = newsList.Length / 6;
                    if (newsList.Length % 6 > 0)
                        modelForm.countButton = count + 1;
                    else
                        modelForm.countButton = count;
                    return modelForm;
                }
                else
                {
                    var newsList = _newsService.GetAllNews().Where(x => x.CategoriName == filter).ToArray();
                    var newsListDTO = _mapper.Map<IEnumerable<NewsDTO>>(newsList).ToList();

                    int number_1 = value * 6 - 6;
                    int number_2 = value * 6;
                    var modelForm = new PaginationList();
                    for (int i = number_1; i < number_2; i++)
                    {
                        try
                        {
                            modelForm.News.Add(newsListDTO[i]);
                        }
                        catch (ArgumentOutOfRangeException e)
                        {

                        }
                    }
                    int count = newsList.Length / 6;
                    if (newsList.Length % 6 > 0)
                        modelForm.countButton = count + 1;
                    else
                        modelForm.countButton = count;
                    return modelForm;
                }
            }
        }

        //[Authorize(Roles = "Manager")]
        [HttpPost("deleteNews")]
        public async Task<ResultDTO> deleteNews([FromBody]NewsDTO news)
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

                var currentNews = _newsService.GetAllNews().FirstOrDefault(x => x.Title == news.Title);

                var commentList = _commentService.GetAllComment().
                    Where(x => x.NewsId == currentNews.Id).ToArray();

                foreach(var item in commentList)
                {
                    _commentService.DeleteComment(item);
                }
                var currentUser = _eFContext.UserAdditional.FirstOrDefault(x => x.Id == currentNews.ManagerId);

                currentUser.PublishCount = (Int32.Parse(currentUser.PublishCount) - 1).ToString();
                _usertService.editUser(currentUser);
                var isFavorite = _newsService.GetAllFavorite().FirstOrDefault(x => x.NewsId == currentNews.Id);
                if (isFavorite != null)
                {
                    _newsService.deleteFavorite(isFavorite);
                }
                _newsService.deleteNews(currentNews);
                return new ResultDTO
                {
                    Status = 200,
                    Message = "Ok"
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
        //[Authorize(Roles = "Manager")]
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
                var currentCategorie = categoriAll.FirstOrDefault(x => x.Name == news.CategoriName);

                var newNews = _mapper.Map<News>(news);

                newNews.Categori = currentCategorie;
                newNews.CategoriId = currentCategorie.Id;
                var currentUser = _eFContext.UserAdditional.FirstOrDefault(x => x.Id == newNews.ManagerId);
                currentUser.PublishCount= (Int32.Parse(currentUser.PublishCount)+1).ToString();
                _usertService.editUser(currentUser);
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

        //[Authorize]
        [HttpGet("getfavorite/{title}")]
        public Favorite getFavorite([FromRoute]string title)
        {
            var currentNews = _newsService.GetAllNews().FirstOrDefault(x => x.Title == title);
            var allfavorite = _newsService.GetAllFavorite().ToList();
            var currentFavorite = allfavorite.FirstOrDefault(x => x.NewsId == currentNews.Id);
            var result = new Favorite();
            if (currentFavorite != null)
                result.IsFavorite = currentFavorite.IsFavorite;
            else
                result.IsFavorite = false;
            return result;
        }

        //[Authorize(Roles = "User")]
        [HttpPost("setFavorite/{id}")]
        public async Task<ResultDTO> setFavorite([FromBody]NewsDTO model,string id)
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
                var userEmail = _eFContext.Users.FirstOrDefault(x => x.Id == id).UserName;

                var currentNews = _newsService.GetAllNews().FirstOrDefault(x => x.DatePost == model.DatePost);
                var allfavorite = _newsService.GetAllFavorite().ToList();
                var currentFavorite = allfavorite.FirstOrDefault(x => x.NewsId == currentNews.Id);
                if (currentFavorite == null)
                {
                    var isFavorite = new UserIsFavorite
                    {
                        Id = Guid.NewGuid().ToString(),
                        News = currentNews,
                        NewsId = currentNews.Id,
                        UserEmail = userEmail,
                        IsFavorite = true
                    };
                    _newsService.addFavorite(isFavorite);
                    
                }
                else
                {
                    currentFavorite.IsFavorite =!currentFavorite.IsFavorite;
                    _newsService.setFavorite(currentFavorite);


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

        [HttpGet("{id}")]
        public List<NewsDTO> getManagerNews([FromRoute]string id)
        {
            var newsList = _newsService.GetAllNews().Where(x => x.ManagerId == id).ToArray();
            var newsListDTO = _mapper.Map<IEnumerable<NewsDTO>>(newsList).ToList();
            for (int i = 0; i < newsList.Length; i++)
            {
                newsListDTO[i].CategoriName = _categoriService.getCategori(newsList[i].CategoriId).Name.ToString();
            }

            return newsListDTO;
        }
    }
}