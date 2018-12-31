using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lemon.API.Models
{
    public class BlogModel
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public DateTime Createtime { get; set; }
        public int UserID { get; set; }
        public string BlogImgUri { get; set; }
        [NotMapped]
        public List<int> ReplyID { get; set; }
    }

    
}
