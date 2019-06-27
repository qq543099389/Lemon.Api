using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lemon.API.Data;
using Lemon.API.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using AutoMapper;

namespace Lemon.API.Controllers
{
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly CoreDbContext _context;
        private readonly IMapper _mapper;

        public BlogController(CoreDbContext context ,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// 获取所有博客及评论
        /// </summary>
        /// <returns></returns>
        [HttpGet("getblog")]
        public IEnumerable<GetBlogModel> GetBlogModel()
        {
            var BlogList = _context.BlogModel.ToList();
            var RepliesList = _context.ReplyModel.ToList();
            var ResultList = new List<GetBlogModel>();
            var UserList = _context.userModels.ToList();

            //博客列表映射
            foreach (var blog in BlogList)
            {
                ResultList.Add(_mapper.Map<GetBlogModel>(blog));
            }
            //评论列表
            foreach (var blog in ResultList)
            {
                blog.ReplyList = new List<ReplyAndUser>();
                var ReplyList = RepliesList.Where(t => t.BlogID == blog.ID).ToList();
                foreach (var reply in ReplyList)
                {
                    var replyAndUser = _mapper.Map<ReplyAndUser>(reply);
                    replyAndUser.Name = UserList.Find(t => t.ID == reply.UserID).Name;
                    replyAndUser.ImgUrl = UserList.Find(t => t.ID == reply.UserID).UserHeadImageUri;
                    blog.ReplyList.Add(replyAndUser);
                }

                blog.Name = UserList.Find(t => t.ID == blog.UserID).Name;
                blog.ImgUrl = UserList.Find(t => t.ID == blog.UserID).UserHeadImageUri;
            }
            return ResultList;
        }

        /// <summary>
        /// 编辑博客
        /// </summary>
        /// <param name="blogModel"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("editblog")]
        public async Task<IActionResult> EditBlog([FromBody] BlogModel blogModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            _context.Entry(blogModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogModelExists(blogModel.ID))
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

        /// <summary>
        /// 添加博客
        /// </summary>
        /// <param name="blogModel"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("addblog")]
        public async Task<IActionResult> AddBlog([FromBody] BlogModel blogModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            blogModel.Createtime = DateTime.Now;
            blogModel.UserID = Convert.ToInt32(User.Claims.Where(t => t.Type == ClaimTypes.Sid).First().Value);

            _context.BlogModel.Add(blogModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBlogModel", new { id = blogModel.ID }, blogModel);
        }

        /// <summary>
        /// 删除博客
        /// </summary>
        /// <param name="id">博客ID</param>
        /// <returns></returns>
        [HttpPost("deleteblog/{id}")]
        public async Task<IActionResult> DeleteBlogModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var blogModel = await _context.BlogModel.FindAsync(id);
            if (blogModel == null)
            {
                return NotFound();
            }

            _context.BlogModel.Remove(blogModel);
            await _context.SaveChangesAsync();

            return Ok(blogModel);
        }

        private bool BlogModelExists(int id)
        {
            return _context.BlogModel.Any(e => e.ID == id);
        }
    }
}