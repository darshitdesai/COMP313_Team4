using CabBook.Data.Infrastructure;
using CabBook.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabBook.Data.Repositories
{
    public interface ICarDetailsRepository : IRepository<CarDetails>
    {
        CarDetails GetDetailsByDriverId(string driverId);
    }
}
