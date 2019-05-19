using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedushop.Data.Infrastructure
{
    //Pattern UnitOfWord
    //Khi thuc hien cac phuong thuc thi se day vao database
    public class UnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private TedushopDbContext dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }
        public TedushopDbContext DbContext
        {
            get{ return dbContext ?? (dbContext = dbFactory.Init()); }
        }
        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}
