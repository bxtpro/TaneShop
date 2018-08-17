using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tane.Data.Infastructure;

namespace Tane.Data.Respositories
{
    public interface IProductRepository
    {

    }
    public class ProductRepository:RepositoryBase<ProductRepository>,IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
