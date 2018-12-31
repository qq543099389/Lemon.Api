using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lemon.API.Models
{
    public class ReplyModel
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public DateTime Createtime { get; set; }
        public int UserID { get; set; }
    }
}
