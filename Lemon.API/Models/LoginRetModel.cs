﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lemon.API.Models
{
    public class LoginRetModel
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleId { get; set; }
    }
}
