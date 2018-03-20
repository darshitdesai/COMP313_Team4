using CabBook.Data.Infrastructure;
using CabBook.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabBook.Data.Repositories
{
    public class DriverRepository : RepositoryBase<RideInformation>, IDriverRepository
    {
        public DriverRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public RideInformation GetByDriverId(string driverId)
        {
            return this.GetAll().FirstOrDefault(x => x.Active && x.UserId == driverId);
        }

        public IEnumerable<RideInformation> GetAllByDriverId(string driverId)
        {
            return this.GetAll().Where(x=> x.UserId == driverId).ToList();
        }

    }
}
