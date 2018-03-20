using CabBook.Data.Infrastructure;
using CabBook.Model.Models;
using CabBook.Model.Models.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabBook.Data.Repositories
{
    public class RiderRepository : RepositoryBase<RideDetails>, IRiderRepository
    {
        public RiderRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public List<AppUser> Drivers()
        {
            var context = new DatabaseEnities();

            var role = context.Roles.Where(r => r.Name == "Driver").FirstOrDefault().Id;
            var Drivers = context.Users.Where(x=>x.Roles.Any(y=>y.RoleId == role)).ToList();
            return Drivers.Select(x=> new AppUser() {
                Id = x.Id,
                Email = x.Email
                //FirstName = x.F
            }).ToList();
        }
    }
}
