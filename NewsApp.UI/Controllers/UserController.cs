using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsApp.DAL;
using NewsApp.DAL.Entity;
using NewsApp.Domain.Interfaces;
using NewsApp.DTO.Models;
using NewsApp.DTO.Models.Results;

namespace NewsApp.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly EFContext _eFContext;
        private readonly IUserService _userService;
        public UserController(EFContext eFContext,IUserService userService)
        {
            _eFContext = eFContext;
            _userService = userService;
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
                Address = user.Address
            };
            return u;
        }
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