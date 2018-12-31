using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lemon.API.Models
{
    public class UserModel
    {
        public int ID { get; set; }
        [Required]
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public RoleModel Role { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string UserHeadImageUri { get; set; }
        public DateTime Createtime { get; set; }
        public DateTime LastLoginTime { get; set; }
    }
}
