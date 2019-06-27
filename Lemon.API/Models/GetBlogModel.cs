using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lemon.API.Models
{
    /// <summary>
    /// 获取博客接口返回的实体
    /// </summary>
    public class GetBlogModel : BlogModel
    {
        /// <summary>
        /// 评论列表
        /// </summary>
        public List<ReplyAndUser> ReplyList { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 头像地址
        /// </summary>
        public string ImgUrl { get; set; }
    }

    /// <summary>
    /// 评论和用户信息实体
    /// </summary>
    public class ReplyAndUser : ReplyModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 头像地址
        /// </summary>
        public string ImgUrl { get; set; }
    }
}
