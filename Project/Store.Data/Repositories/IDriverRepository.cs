using CabBook.Data.Infrastructure;
using CabBook.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabBook.Data.Repositories
{
    public interface IDriverRepository : IRepository<RideInformation>
    {

        RideInformation GetByDriverId(string driverId);
        IEnumerable<RideInformation> GetAllByDriverId(string driverId);
    }
}
