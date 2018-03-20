using CabBook.Data.Infrastructure;
using CabBook.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabBook.Data.Repositories
{
    public class DemoRepository : RepositoryBase<Demo>, IDemoRepository
    {
        public DemoRepository(IDbFactory dbFactory)
           : base(dbFactory) { }
    }
}
