﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tane.Data.Infastructure;
using Tane.Data.Repositories;
using Tane.Model.Models;

namespace Tane.Service
{
    public interface IPostService
    {
        void Add(Post post);
        void Update(Post post);
        void Delete(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetAllPaging(int page, int pageSize,out int totalRow);
        IEnumerable<Post> GetAllByCategoryPaging(int categoryId,int page, int pageSize, out int totalRow);
        Post GetById(int id);
        IEnumerable<Post> GetAllTagPaging(string tag,int page, int pageSize, out int totalRow);
        void SaveChanges();

    }
    public class PostService : IPostService
    {
        private IPostRepository _postRepository;
        private IUnitOfWork _unitOfWork;
        public PostService(IPostRepository postRepository,IUnitOfWork unitOfWork)
        {
            this._postRepository = postRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(Post post)
        {
           _postRepository.Add(post);
        }

        public void Delete(int id)
        {
            _postRepository.Delete(id);
        }

        public IEnumerable<Post> GetAll()
        {
           return _postRepository.GetAll(new []{"PostCategory"});
        }

        public IEnumerable<Post> GetAllByCategoryPaging(int categoryId, int page, int pageSize, out int totalRow)
        {
            return _postRepository.GetMultiPaging(x => x.Status && x.CategoryID==categoryId, out totalRow, page, pageSize,new string[]{"PostCategory"});
        }

        public IEnumerable<Post> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            
            return _postRepository.GetMultiPaging(x => x.Status, out totalRow, page,pageSize);
        }

        public IEnumerable<Post> GetAllTagPaging(string tag, int page, int pageSize, out int totalRow)
        {
            //TODO:Select all posst by tag
            return _postRepository.GetAllByTag(tag,page,pageSize,out totalRow);
        }

        public Post GetById(int id)
        {
            return _postRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Post post)
        {
          _postRepository.Update(post);
        }
    }
}
