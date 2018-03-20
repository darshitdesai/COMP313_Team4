using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CabBook.Model.Models.Identity
{
    public class AppUser : IdentityUser
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AppUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        //add your custom properties which have not included in IdentityUser before
        //Refrence of RideInformation table
        public ICollection<RideInformation> RideInformation { get; set; }
        public ICollection<CarDetails> CarDetails { get; set; }
    }



    public class AppRole : IdentityRole
    {
        public AppRole() : base() { }
        public AppRole(string name) : base(name) { }
        // extra properties here 
    }

    public class UserLogin : IdentityUserLogin
    {

    }

    public class UserRole : IdentityUserRole
    {

    }
    public class UserClaim : IdentityUserClaim
    {

    }

    
    public class RoleOperation
    {

    }
}
