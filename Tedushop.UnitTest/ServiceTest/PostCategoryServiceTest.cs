using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tedushop.Data.Infrastructure;
using Tedushop.Data.Repositories;
using Tedushop.Model.Model;
using Tedushop.Service;

namespace Tedushop.UnitTest.ServiceTest
{
    [TestClass]
    public class PostCategoryServiceTest
    {
        private Mock<IPostCategoryRepository> _mockRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private IPostCategoryService _categoryService;
        private List<PostCategory> _lstPostCategory;

        [TestInitialize] //Chạy đầu tiên khi chạy ứng dụng
        public void Initialize()
        {
            //mock ra repository và unit of work trc rồi sẽ tạo ra 1 đối tượng giả của IRepository
            _mockRepository = new Mock<IPostCategoryRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _categoryService = new PostCategoryService(_mockRepository.Object,_mockUnitOfWork.Object);
            _lstPostCategory = new List<PostCategory>()
            {
                new PostCategory(){ID =1,Name="DM1",Status= true},
                new PostCategory(){ID =1,Name="DM2",Status= true},
                new PostCategory(){ID =1,Name="DM3",Status= true}
            };
        }
        [TestMethod]
        public void PostCategory_Service_GetAll()
        {
            //B1: Setup method: Trả về cái list lúc Initialize()        (Lấy trực tiếp _lstPostCategory)
            //=>Cài đặt đối tượng ảo _mockRepository = đúng cái list đc khởi tạo
            _mockRepository.Setup(n => n.GetAll(null)).Returns(_lstPostCategory);

            //B2: Call action   (Gọi từ repostiry và lấy đc _lstPostCategory thông qua GetAll())
            var result = _categoryService.GetAll() as List<PostCategory>;

            //B3:Compare (So sánh 2 cái list ở B1 và B2)
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void PostCategory_Service_Create()
        {
            PostCategory category = new PostCategory();
            category.Name = "Test";
            category.Alias = "Test";
            category.Status = true;

            //B1:Cài đặt đối tượng ảo _mockRepository có ID=1
            _mockRepository.Setup(n => n.Add(category)).Returns((PostCategory p) =>
            {
                p.ID = 1;
                return p;
            });

            //B2:
            var result =_categoryService.Add(category);

            //B3:
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ID);

        }
    }
}
