using CabBook.Data.Infrastructure;
using CabBook.Model.Models;
using CabBook.Model.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabBook.Data.Repositories
{
    public interface IRiderRepository : IRepository<RideDetails>
    {

        List<AppUser> Drivers();

    }
}
