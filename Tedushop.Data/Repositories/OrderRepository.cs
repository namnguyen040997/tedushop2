using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tedushop.Data.Infrastructure;
using Tedushop.Model.Model;

namespace Tedushop.Data.Repositories
{
    public interface IOrder : IRepository<Order>
    {

    }
    public class OrderRepository : RepositoryBase<Order>, IOrder
    {
        public OrderRepository(DbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
