﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tedushop.Data.Infrastructure;
using Tedushop.Model.Model;

namespace Tedushop.Data.Repositories
{
    public interface ITagRepository
    {

    }
    public class TagRepository : RepositoryBase<Tag>, ITagRepository
    {
        public TagRepository(DbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
