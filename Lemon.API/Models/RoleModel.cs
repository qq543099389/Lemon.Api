using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lemon.API.Models
{
    public class RoleModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public RoleType roleType { get; set; }
        public enum RoleType
        {
            /// <summary>
            /// 管理员
            /// </summary>
            Administrator = 1,
            /// <summary>
            /// 普通用户
            /// </summary>
            User = 2
        }
    }
}
