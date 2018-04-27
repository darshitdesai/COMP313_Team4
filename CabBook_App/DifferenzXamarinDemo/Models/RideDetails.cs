/*Author: Darshit Desai
Date: March 11, 2018
Purpose: Model Class*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabBook.Models
{

    public class AppUser
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    public class RideInformation
    {
        public string Id { get; set; }
        public string FirstStreet { get; set; }
        public string SecondStret { get; set; }
        public string StartTime { get; set; }
        public string Destination { get; set; }
        public string Landmark { get; set; }
        public string UserId { get; set; }
        public bool Active { get; set; }
    }

    public class CarDetails
    {
        public string Id { get; set; }
        public string CarName { get; set; }
        public string LicenseNumber { get; set; }
        public string LicenseType { get; set; }
        public string CarNumer { get; set; }
        public bool BabySeat { get; set; }
        public AppUser User { get; set; }
        public string UserId { get; set; }
    }

    public class RideDetails
    {
        public string Id { get; set; }
        public RideInformation rideInfo { get; set; }
        public CarDetails carDetails { get; set; }
        public AppUser UserDetails { get; set; }
        public string ToEmail { get; set; }
        public string RiderEmail { get; set; }
        public string RiderName { get; set; }
        public string PhoneNumber { get; set; }
        public string UserId { get; set; }
    }
}
