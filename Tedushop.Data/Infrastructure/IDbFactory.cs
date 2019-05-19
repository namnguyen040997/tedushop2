using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedushop.Data.Infrastructure
{
    //Giao tiếp để khởi tạo đổi tượng Entity (ko khởi tạo trực tiếp mà phải thông qua DbFactory) 
    //(thay vif lucs nao cung new dbContext thi su dung Factory)
    //Áp dụng factory của design pattern
    public interface IDbFactory:IDisposable
    {
        //init thằng dbContact (ỉnterface)
        TedushopDbContext Init();
    }
}
