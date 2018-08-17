using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Tane.Data.Infastructure;
using Tane.Data.Repositories;
using Tane.Model.Models;
using Tane.Service;

namespace Tane.UnitTest.ServiceTest
{
    [TestClass]
    public class PostCategoryServiceTest
    {
        private Mock<IPostCategoryRepository> _mockReopsitory;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private IPostCategoryService _categoryService;
        private List<PostCategory> _listCategories;
        [TestInitialize]
        public void Initialize()
        {
            _mockReopsitory= new Mock<IPostCategoryRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _categoryService = new PostCategoryService(_mockReopsitory.Object,_mockUnitOfWork.Object);
            _listCategories = new List<PostCategory>()
            {
                new PostCategory(){ID = 1,Name = "DM1", Status = true},
                new PostCategory(){ID = 2,Name = "DM2", Status = true},
                new PostCategory(){ID = 3,Name = "DM3", Status = true}
            };
        }
        [TestMethod]
        public void Postcategory_Service_GetAll()
        {
            _mockReopsitory.Setup(m => m.GetAll(null)).Returns(_listCategories);
            var result = _categoryService.GetAll() as List<PostCategory>;

            Assert.IsNotNull(result);
            Assert.AreEqual(3,result.Count);
        }
        [TestMethod]
        public void Postcategory_Service_Create()
        {
            PostCategory postCategory = new PostCategory();
            int id = 1;
            postCategory.Name = "Test";
            postCategory.Alias = "Test";
            postCategory.Status = true;

            _mockReopsitory.Setup(m => m.Add(postCategory)).Returns((PostCategory p) =>
            {
                p.ID = 1;
                return p;
            });

           var result= _categoryService.Add(postCategory);

            Assert.IsNotNull(result);
            Assert.AreEqual(1,result.ID);
        }

    }
}
