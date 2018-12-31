using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lemon.API.Models
{
    public class GetBlogModel:BlogModel
    {
        public List<ReplyModel> ReplyList { get; set; }
        public string UserName { get; set; }
        public string UserHeadImageUri { get; set; }
    }
}
