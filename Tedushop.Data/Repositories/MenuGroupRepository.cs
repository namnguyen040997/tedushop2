using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tedushop.Data.Infrastructure;
using Tedushop.Model.Model;

namespace Tedushop.Data.Repositories
{
    public interface IMenuGroupRepository
    {

    }
    public class MenuGroupRepository:RepositoryBase<MenuGroup>, IMenuGroupRepository
    {
        public MenuGroupRepository(DbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
