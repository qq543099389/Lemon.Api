using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lemon.API.Models
{
    /// <summary>
    /// 评论
    /// </summary>
    public class ReplyModel
    {
        /// <summary>
        /// 评论ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 评论内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 评论时间
        /// </summary>
        public DateTime Createtime { get; set; }
        /// <summary>
        /// 评论用户ID
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 所属博客ID
        /// </summary>
        public int BlogID { get; set; }
    }
}
