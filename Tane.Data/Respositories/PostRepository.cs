using System.Collections.Generic;
using System.Linq;
using Tane.Data.Infastructure;
using Tane.Model.Models;

namespace Tane.Data.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        IEnumerable<Post> GetAllByTag(string tag, int pageIndex, int pageSize, out int totalRow);
    }

    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Post> GetAllByTag(string tag, int pageIndex, int pageSize, out int totalRow)
        {
            var query = from q in DbContext.Posts
                join q2 in DbContext.PostTags on q.ID equals q2.PostID
                where q2.TagID == tag && q.Status orderby q.CreateBy descending
                select q;
            totalRow = query.Count();
            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return query;
        }
    }
}