﻿using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tane.Data.Infastructure;
using Tane.Data.Repositories;
using Tane.Model.Models;

namespace Tane.UnitTest.ResposirotyTest
{
    [TestClass]
    public class PostCategoryRepositoryTest
    {
        private IDbFactory dbFactory;
        private IPostCategoryRepository objRepository;
        private IUnitOfWork unitOfWork;
        [TestInitialize]
        public void Initialize()
        {
            dbFactory= new DbFactory();
            objRepository= new PostCategoryRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);
        }

        [TestMethod]
        public void PostCategory_Repository_GetAll()
        {
            var list = objRepository.GetAll();
            Assert.AreEqual(1,list.Count());
        }
        [TestMethod]
        public void PostCategory_Repository_Create()
        {
            PostCategory category = new PostCategory();
            category.Name = "Test category";
            category.Alias = "Test-category";
            category.Status = true;
            var result = objRepository.Add(category);
            unitOfWork.Commit();

            Assert.IsNotNull(result);
            Assert.AreEqual(1,result.ID);
        }
    }
}
