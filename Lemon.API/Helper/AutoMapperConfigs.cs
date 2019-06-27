using AutoMapper;
using Lemon.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lemon.API.Helper
{
    public class AutoMapperConfigs : Profile
    {
        //添加你的实体映射关系.
        public AutoMapperConfigs()
        {
            //GoodsEntity转GoodsDto.
            CreateMap<BlogModel, GetBlogModel>()
                //映射发生之前
                .BeforeMap((source, dto) =>
                {
                    //可以较为精确的控制输出数据格式
                    //dto.CreateTime = Convert.ToDateTime(source.CreateTime).ToString("yyyy-MM-dd");
                })
                //映射发生之后
                .AfterMap((source, dto) =>
                {
                    //code ...
                });
            CreateMap<ReplyModel, ReplyAndUser>();
            CreateMap<UserModel,LoginRetModel>();
        }
    }
}