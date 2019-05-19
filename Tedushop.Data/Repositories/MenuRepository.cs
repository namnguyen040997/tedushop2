using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tedushop.Data.Infrastructure;
using Tedushop.Model.Model;

namespace Tedushop.Data.Repositories
{
    public interface IMenuRepository
    {

    }
    public class MenuRepository : RepositoryBase<Menu>, IMenuRepository
    {
        public MenuRepository(DbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
