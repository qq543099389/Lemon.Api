using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lemon.API.Data;
using Lemon.API.Models;
using Newtonsoft.Json;
using Lemon.API.Helper;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace Lemon.API.Controllers
{

    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly CoreDbContext _context;

        public UserController(CoreDbContext context)
        {
            _context = context;
        }

        [HttpGet("getuserinfo/{id}")]
        public IActionResult GetUserModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var UserList = _context.userModels.ToList().Find(t => t.ID==id);
            if (UserList == null)
            {
                return BadRequest("用户不存在");
            }
            UserList.Password = null;

            
            return Ok(UserList);
        }

        [HttpPost("edituserinfo")]
        public async Task<IActionResult> PutUserModel([FromRoute] int id, [FromBody] UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userModel.ID)
            {
                return BadRequest();
            }
            string invalidPasswordKey = string.Format("lemon_{0}", userModel.Password);
            userModel.Password = EncryptHelper.MD5(invalidPasswordKey);

            _context.Entry(userModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost("register")]
        public async Task<IActionResult> PostUserModel([FromBody] UserModel userModel)
        {
            string message;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userList = _context.userModels.Select(t => t.UserName == userModel.UserName).Count();
            if(userList != 0)
            {
                message = "用户名已存在";
                return BadRequest(message);
            }
            string invalidPasswordKey = string.Format("lemon_{0}", userModel.Password);
            userModel.Password = EncryptHelper.MD5(invalidPasswordKey);
            userModel.Createtime = DateTime.Now;
            userModel.LastLoginTime = DateTime.Now;
            userModel.UserHeadImageUri = "image/s5.jpg";
            userModel.RoleId = 2;

            _context.userModels.Add(userModel);
            await _context.SaveChangesAsync();
            message = "注册成功";

            return Ok(message);
        }

        [HttpDelete("deleteuser/{id}")]
        public async Task<IActionResult> DeleteUserModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userModel = await _context.userModels.FindAsync(id);
            if (userModel == null)
            {
                return NotFound();
            }

            _context.userModels.Remove(userModel);
            await _context.SaveChangesAsync();

            return Ok(userModel);
        }

        private bool UserModelExists(int id)
        {
            return _context.userModels.Any(e => e.ID == id);
        }
    }
}