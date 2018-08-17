using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tane.Data.Infastructure;
using Tane.Model.Models;

namespace Tane.Data.Respositories
{
    public interface IErrorRepository : IRepository<Error>
    {

    }
    public class ErrorRepository:RepositoryBase<Error>,IErrorRepository
    {
        public ErrorRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
