using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lemon.API.Data;
using Lemon.API.Models;
using Lemon.API.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using AutoMapper;

namespace Lemon.API.Controllers
{
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly CoreDbContext _context;
        private readonly IMapper _mapper;
        public AuthenticateController(CoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("/login")]
        public IActionResult login([FromBody]LoginModel loginModel)
        {
            string message;
            string invalidPasswordKey = string.Format("lemon_{0}", loginModel.Password);
            loginModel.Password = EncryptHelper.MD5 (invalidPasswordKey);
            var userModel = _context.userModels.Where(t => t.UserName == loginModel.UserName && t.Password == loginModel.Password).FirstOrDefault();
            if(userModel == null)
            {
                message = "用户名或密码错误";
                return BadRequest(message);
            }

            userModel.LastLoginTime = DateTime.Now;
            var claims = new List<Claim>{
                new Claim(ClaimTypes.Name,userModel.Name),
                new Claim(ClaimTypes.Role,userModel.RoleId.ToString()),
                new Claim(ClaimTypes.Sid,userModel.ID.ToString())
            };
            var claimidentity = new ClaimsIdentity(claims, "CookieAuth");
            HttpContext.SignInAsync("CookieAuth", new ClaimsPrincipal(claimidentity), 
            new AuthenticationProperties
            {
                ExpiresUtc = DateTime.UtcNow.AddDays(3)
            });

            var LoginReq = _mapper.Map<LoginRetModel>(userModel);

            return Ok(LoginReq);
        }
    }
}