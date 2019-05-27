using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tedushop.Data.Infrastructure;
using Tedushop.Data.Repositories;
using Tedushop.Model.Model;

namespace Tedushop.UnitTest.RepositoryTest
{
    [TestClass]
    public class PostCategoryRepositoryTest
    {
        //Thiết lập 3 đối tượng để tương tác CSDL
        IDbFactory dbFactory;
        IPostCategoryRepository objRepository;
        IUnitOfWork unitOfWork;
        [TestInitialize] //GIúp chạy đầu tiên khi ứng dụng chạy
        public void Initialize()
        {
            //Khi ứng dụng chạy thì khởi tạo 3 đối tượng
            dbFactory = new DbFactory();
            objRepository = new PostCategoryRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);
        }
        [TestMethod]
        public void PostCategory_Repository_GetAll()
        {
            var lstPostCategory = objRepository.GetAll().ToList();
            Assert.AreEqual(3, lstPostCategory.Count);
        }

        [TestMethod]
        public void PostCategory_Repository_Create()
        {
            PostCategory postcate = new PostCategory();
            postcate.Name = "Nam";
            postcate.Alias = "Test Category";
            postcate.Status = true;

            var result = objRepository.Add(postcate);
            unitOfWork.Commit();

            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.ID);
        }
    }
}
