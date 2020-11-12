using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
    public class UserController : ControllerBase
    {
        private readonly EFContext _eFContext;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly INewsService _newsService;
        private readonly ICommentService _commentService;

        public UserController(EFContext eFContext,IUserService userService,IMapper mapper,
                     UserManager<User> userManager, INewsService newsService,
                     ICommentService commentService
)
        {
            _userManager = userManager;
            _eFContext = eFContext;
            _userService = userService;
            _mapper = mapper;
            _newsService = newsService;
            _commentService = commentService;
        }
        //[Authorize(Roles = "Admin")]
        [HttpPost("deleteuser")]
        public async Task<ResultDTO> deleteUser([FromBody]UserAdditionalDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return new ResultDTO
                    {
                        Status = 404,
                        Message = "model not valid"
                    };
                }
                var userA = _eFContext.UserAdditional.FirstOrDefault(x => x.FullName == model.FullName);
                var user = _eFContext.Users.FirstOrDefault(x => x.Id == userA.Id);
                var allUserNews = _newsService.GetAllNews().Where(x => x.ManagerName == userA.FullName).ToArray();
                foreach(var item in allUserNews)
                {
                    var commentList = _commentService.GetAllComment().Where(x => x.NewsId == item.Id).ToArray();
                    foreach (var item2 in commentList)
                    {
                        _commentService.DeleteComment(item2);
                    }
                    var isFavorite = _newsService.GetAllFavorite().FirstOrDefault(x => x.NewsId == item.Id);
                    if(isFavorite!=null)
                    {
                        _newsService.deleteFavorite(isFavorite);
                    }
                    _newsService.deleteNews(item);
                }
                await _userManager.RemoveFromRoleAsync(user, userA.UserRole);
                _userService.deleteUser(userA);
                _eFContext.Users.Remove(user);
                _eFContext.SaveChanges();
                return new ResultDTO
                {
                    Status = 200,
                    Message = "ok"
                };
            }
            catch (Exception e)
            {
                return new ResultDTO
                {
                    Status = 400,
                    Message = e.Message
                };
            }
        }
        //[Authorize(Roles = "Admin")]
        [HttpPost("changeRole/{role}")]
        public async Task<ResultDTO> changeUserRole([FromBody]UserAdditional model,[FromRoute]string role)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return new ResultDTO
                    {
                        Status = 404,
                        Message = "model not valid"
                    };
                }
                var currentUserAditional = _eFContext.UserAdditional.FirstOrDefault(x => x.FullName == model.FullName);
             
                var user = _eFContext.Users.FirstOrDefault(x => x.Id == currentUserAditional.Id);
                if (role == "Manager")
                { await _userManager.RemoveFromRoleAsync(user, "User");
                    var managerNews = _eFContext.News.Where(x => x.ManagerId == user.Id).ToArray();
                foreach(var item in managerNews)
                    {
                        item.IsBlocked = false;
                        _newsService.Update(item);
                    }
                }
                else
                { await _userManager.RemoveFromRoleAsync(user, "Manager");
                    var managerNews = _eFContext.News.Where(x => x.ManagerId == user.Id).ToArray();
                    foreach (var item in managerNews)
                    {
                        item.IsBlocked = true;
                        _newsService.Update(item);
                    }
                }
             
                    await _userManager.AddToRoleAsync(user, role);

                currentUserAditional.UserRole = role;
                _userService.editUser(currentUserAditional);
                return new ResultDTO
                {
                    Status = 200,
                    Message = "ok"
                };
            }
            catch (Exception e)
            {
                return new ResultDTO
                {
                    Status = 400,
                    Message = e.Message
                };
            }
        }

        [HttpGet("currentuser")]
        public UserAdditionalDTO getcurrentUser([FromBody]string fullName)
        {
            var user = _eFContext.UserAdditional.FirstOrDefault(x => x.FullName == fullName);
            var userDTO = _mapper.Map<UserAdditionalDTO>(user);

            return userDTO;
        }

        [HttpGet("{id}")]
        public UserAdditionalDTO getCurrentUser(string id)
        {
            var currentUser = _eFContext.Users.FirstOrDefault(x => x.Id == id);
            var user = _eFContext.UserAdditional.FirstOrDefault(x => x.User.Id == id);
            UserAdditionalDTO u = new UserAdditionalDTO()
            {
                FullName = user.FullName,
                Image = user.Image,
                Address = user.Address,
                DataRegister=user.DataRegister,
                UserRole=user.UserRole,
                PublishCount=user.PublishCount
            };
            return u;
        }
        //[Authorize(Roles ="Admin")]
        [HttpGet("getall")]
        public List<UserAdditionalDTO> getAllusers()
        {
            var role = _eFContext.Roles.First(x => x.Name == "Admin");
            var usersId = _eFContext.UserRoles.Where(x => x.RoleId != role.Id);
            var users = new List<UserAdditional>();
            foreach (var item in usersId)
            {
                users.Add(_eFContext.UserAdditional.First(x => x.User.Id == item.UserId));
            }
            var userDto = new List<UserAdditionalDTO>();
            foreach (var item in users)
            {
                userDto.Add(new UserAdditionalDTO()
                {
                    FullName = item.FullName,
                    Image = item.Image,
                    Address = item.Address,
                    DataRegister = item.DataRegister,
                    UserRole = item.UserRole,
                    PublishCount = item.PublishCount
                });
            }
            return userDto;
        }

        //[Authorize(Roles = "User")]
        [HttpGet]
        public List<UserAdditionalDTO> getAllManager()
        {
            var role = _eFContext.Roles.First(x => x.Name == "Manager");
            var usersId = _eFContext.UserRoles.Where(x => x.RoleId == role.Id);
            var users = new List<UserAdditional>();
            foreach(var item in usersId)
            {
                users.Add(_eFContext.UserAdditional.First(x => x.User.Id == item.UserId));
            }
            var userDto = new List<UserAdditionalDTO>();
            foreach(var item in users)
            {
                userDto.Add(new UserAdditionalDTO()
                {
                    FullName = item.FullName,
                    Image = item.Image,
                    Address = item.Address
                });
            }
            return userDto;
        }
        [HttpPost("edituser/{id}")]
        public async Task<ResultDTO> editUser([FromBody]UserAdditionalDTO model,[FromRoute]string id)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return new ResultDTO
                    {
                        Status = 404,
                        Message = "model not valid"
                    };
                }

                var editUser = _eFContext.UserAdditional.FirstOrDefault(x => x.User.Id ==id);
                editUser.FullName = model.FullName;
                editUser.Image = model.Image;
                editUser.Address = model.Address;

              
                _userService.editUser(editUser);


                return new ResultDTO
                {
                    Status = 200,
                    Message = "ok"
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