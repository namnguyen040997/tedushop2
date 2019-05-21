using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tedushop.Data.Infrastructure;
using Tedushop.Model.Model;


namespace Tedushop.Data.Repositories
{
    //Viết thêm interface cho class trong trường hợp các class đó có các phương thức có sự khác biệt cần phải viết mà trong RepositoryBase ko có.
    //VD trong ProductCategory , chúng ta có thêm phương thức để lấy các Alias
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        //Dinh nghia phuong thuc ko co trong RepositoryBase
        IEnumerable<ProductCategory> GetByAlias(string alias);
    }
    public class ProductCategoryRepository:RepositoryBase<ProductCategory>,IProductCategoryRepository
    {
        //Vì trong contructor RepositoryBase có constructor có dbFactory là tham số truyền vào:   (nên ở đây cũng phải viết constructor cho ProductCategoryRepository)
        //protected RepositoryBase(IDbFactory dbFactory)
        //{
        //    DbFactory = dbFactory;
        //    dbSet = DbContext.Set<T>();
        //}
        public ProductCategoryRepository(DbFactory dbFactory):base(dbFactory)
        {

        }

        public IEnumerable<ProductCategory> GetByAlias(string alias)
        {
            return this.DbContext.ProductCategories.Where(n => n.Alias == alias);
        }
    }
}
