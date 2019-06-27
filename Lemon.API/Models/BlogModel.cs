using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lemon.API.Models
{
    public class BlogModel
    {
        /// <summary>
        /// 博客
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 发表时间
        /// </summary>
        public DateTime Createtime { get; set; }
        /// <summary>
        /// 发布者ID
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 博客图片（暂未使用）
        /// </summary>
        public string BlogImgUri { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
    }

    
}
