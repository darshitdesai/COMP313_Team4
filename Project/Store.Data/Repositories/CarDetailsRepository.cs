using CabBook.Data.Infrastructure;
using CabBook.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabBook.Data.Repositories
{
    public class CarDetailsRepository : RepositoryBase<CarDetails>, ICarDetailsRepository
    {
        public CarDetailsRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public CarDetails GetDetailsByDriverId(string driverId)
        {
            return this.GetAll().FirstOrDefault(x=>x.UserId == driverId) ?? null;
        }
    }
}
