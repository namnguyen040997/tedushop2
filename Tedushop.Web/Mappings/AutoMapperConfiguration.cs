using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tedushop.Model.Model;
using Tedushop.Web.Models;

namespace Tedushop.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Post, PostViewModel>();
                cfg.CreateMap<PostCategory, PostCategoryViewModel>();
                cfg.CreateMap<Tag, TagViewModel>();
                cfg.CreateMap<PostTag, PostTagViewModel>();
            });
        }
    }
}