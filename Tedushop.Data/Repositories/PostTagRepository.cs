using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tedushop.Data.Infrastructure;
using Tedushop.Model.Model;

namespace Tedushop.Data.Repositories
{
    public interface IPostTagRepository
    {

    }
    public class PostTagRepository : RepositoryBase<PostTag>, IPostTagRepository
    {
        public PostTagRepository(DbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
