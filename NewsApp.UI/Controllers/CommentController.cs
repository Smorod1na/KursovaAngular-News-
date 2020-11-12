using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly INewsService _newsService;

        private readonly IMapper _mapper;
        public CommentController(ICommentService commentService,IMapper mapper,INewsService newsService)
        {
            _commentService = commentService;
            _mapper = mapper;
            _newsService = newsService;
        }
        //[Authorize]
        [HttpGet("{title}")]
        public List<CommentsDTO> getNewsComment([FromRoute]string title)
        {
            var news = _newsService.GetAllNews();
            var newsComments = _commentService.GetAllComment().
                Where(x => x.NewsId==news.FirstOrDefault(x=>x.Title==title).Id).ToArray();
            var com = _mapper.Map<IEnumerable<CommentsDTO>>(newsComments).ToList();
            return com;
        }
        //[Authorize(Roles ="User")]
        [HttpPost("deletecomment")]
        public async Task<ResultDTO> deleteNewsComment([FromBody]CommentsDTO comment)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return new ResultDTO
                    {
                        Status = 400,
                        Message = "model not valid"
                    };
                }
                var com= _mapper.Map<Comments>(comment);
                var sss = _commentService.GetAllComment().FirstOrDefault(x => x.Text == com.Text);
                //com.News = _newsService.GetAllNews().FirstOrDefault(x => x.Title == "Test2");
                _commentService.DeleteComment(sss);
                return new ResultDTO
                {
                    Status = 200,
                    Message = "Ok"
                };
            }
            catch(Exception e)
            {
                return new ResultDTO
                {
                    Status = 400,
                    Message = e.Message
                };
            }
        }
        //[Authorize(Roles = "User")]
        [HttpPost("addcomment/{title}")]
        public async Task<ResultDTO> addComment([FromBody]CommentsDTO comment,[FromRoute]string title)
        {
            try
            {

            
            if(!ModelState.IsValid)
            {
                return new ResultDTO
                {
                    Status = 400,
                    Message = "model not valid"
                };
            }
                var newComment = _mapper.Map<Comments>(comment);
                newComment.News = _newsService.GetAllNews().FirstOrDefault(x => x.Title == title);
                newComment.NewsId = _newsService.GetAllNews().FirstOrDefault(x => x.Title == title).Id;
                _commentService.AddComment(newComment);
                return new ResultDTO
                { 
                Status=200,
                Message="Ok"
                };
            }
            catch(Exception e)
            {
                return new ResultDTO
                {
                    Status = 400,
                    Message = e.Message
                };
            }
        }

    }
}