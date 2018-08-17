using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tane.Data.Infastructure;
using Tane.Model.Models;

namespace Tane.Data.Respositories
{
    public interface IProductCategoryRepository:IRepository<ProductCategory>
    {
        IEnumerable<ProductCategory> GetByAlias(string alias);
    }
    public class ProductCategoryRepository:RepositoryBase<ProductCategory>,IProductCategoryRepository
    {
        public ProductCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public IEnumerable<ProductCategory> GetByAlias(string alias)
        {
           return this.DbContext.ProductCategories.Where(w => w.Alias == alias);
        }
    }
}
