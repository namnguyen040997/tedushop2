using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedushop.Data.Infrastructure
{
    //Pattern UnitOfWord
    //Khi thuc hien cac phuong thuc thi se day vao database
    public class UnitOfWork:IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private TedushopDbContext dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }
        public TedushopDbContext DbContext
        {
            //Lấy đói tượng DbCOntext trong dbFactory
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }
        public void Commit()
        {
            //Nếu gọi hàm Commit , đối tượng DbContext của DbFactory sẽ lưu vào CSDL
            DbContext.SaveChanges();
        }
    }
}
