using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tedushop.Data.Infrastructure;
using Tedushop.Model.Model;

namespace Tedushop.Data.Repositories
{
    public interface IProductTagRepository
    {

    }
    public class ProductTagRepository : RepositoryBase<ProductTag>, IProductTagRepository
    {
        public ProductTagRepository(DbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
