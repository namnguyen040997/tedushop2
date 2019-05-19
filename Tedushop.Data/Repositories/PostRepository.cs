using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tedushop.Data.Infrastructure;
using Tedushop.Model.Model;

namespace Tedushop.Data.Repositories
{
    public interface IPostRepository
    {

    }
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(DbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
