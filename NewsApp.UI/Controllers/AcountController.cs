using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class AcountController : ControllerBase
    {
        private readonly EFContext _eFContext;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJWTTokenService _jwtTokenService;

        public AcountController(EFContext eFContext,
         UserManager<User> userManager,
         SignInManager<User> signInManager,
         IJWTTokenService jwtTokenService)
        {
            _eFContext = eFContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtTokenService = jwtTokenService;
        }
        [HttpPost("register")]
        public async Task<ResultDTO> Register([FromBody]UserRegisterDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return new ResultErrorDTO
                    {
                        Status = 403,
                        Message = "error",
                        Errors = CustomValidator.GetErrorsByModel(ModelState)
                    };
                }
                var user = new User()
                {
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.Phone
                };

                var userProFile = new UserAdditional()
                {
                    Address = model.Address,
                    Image = "default.jpg",
                    DataRegister = DateTime.Now.ToShortDateString(),
                    PublishCount="0",
                    FullName = model.FullName,
                    Id = user.Id
                };

                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                
                if (!result.Succeeded)
                {
                    return new ResultErrorDTO
                    {
                        Message = "error",
                        Status = 500,
                        Errors = CustomValidator.GetErrorByIdentityResult(result)
                    };
                }
                else
                {
                    result = _userManager.AddToRoleAsync(user, "User").Result;
                    userProFile.UserRole = "User";
                    _eFContext.UserAdditional.Add(userProFile);

                    _eFContext.SaveChanges();
                }


                return new ResultDTO
                {
                    Status = 200,
                    Message = "OK"
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


        [HttpPost("login")]
        public async Task<ResultDTO> Login([FromBody]UserLoginDTO model)
        {
            if (!ModelState.IsValid)
            {
                return new ResultErrorDTO
                {
                    Status = 403,
                    Message = "invalid data for login",
                    Errors = CustomValidator.GetErrorsByModel(ModelState)
                };

            }
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (!result.Succeeded)
            {
                return new ResultErrorDTO
                {
                    Status = 401,
                    Message = "Error",
                    Errors = new List<string>()
                    {
                        "incorrect login or password"
                    }

                };
            }
            else
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                await _signInManager.SignInAsync(user, false);

                return new ResultLoginDTO
                {
                    Status = 200,
                    Message = "Ok",
                    Token = _jwtTokenService.CreateToken(user)
                };
            }
        }
    }
}