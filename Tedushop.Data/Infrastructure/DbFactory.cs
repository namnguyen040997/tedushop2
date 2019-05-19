using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedushop.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private TedushopDbContext dbContext;
        //Neu dbContext null thi khoi tao doi tuong dbContext
        public TedushopDbContext Init()
        {
            return dbContext ?? (dbContext = new TedushopDbContext());
        }
        //Neu chua dong ket noi thi giai phong bo nho
        protected override void DisposeCore()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}
