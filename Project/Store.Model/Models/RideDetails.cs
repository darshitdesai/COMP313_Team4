using CabBook.Model.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabBook.Model.Models
{
    public class RideDetails
    {
        public Guid Id { get; set; }
        public RideInformation rideInfo { get; set; }
        public CarDetails carDetails { get; set; }
        public AppUser UserDetails {get;set;}
        public string ToEmail { get; set; }
        public string RiderEmail { get; set; }
        public string RiderName { get; set; }
        public string PhoneNumber { get; set; }

    }
}
