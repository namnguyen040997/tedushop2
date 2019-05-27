using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tedushop.Data.Infrastructure;
using Tedushop.Model.Model;

namespace Tedushop.Data.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        //Viết thêm phương thức mà RepositoryBase ko có
        IEnumerable<Post> GetAllByTag(string tag, int pageIndex, int pageSize, out int totalRow);
    }
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public IEnumerable<Post> GetAllByTag(string tag, int pageIndex, int pageSize, out int totalRow)
        {
            //Hiển thị danh sách posttag khi click vào link tag
            var query = from p in DbContext.Posts
                        join pt in DbContext.PostTags
                        on p.ID equals pt.PostID
                        where pt.TagID == tag
                        select p;
            totalRow = query.Count();
            //Phân trang: 
            //((pageIndex - 1) * pageSize: lấy từ bản ghi thứ bao nhiêu)
            //Vd: pageSize= 20
            //truyền vào pageIndex =1 thì sẽ lấy 0 bản ghi,Truyền vào pageInđex = 2 thí sẽ lấy 20 bản ghi ,...
            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return query;
        }
    }
}
