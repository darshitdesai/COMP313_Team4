using CabBook.Model.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabBook.Model.Models
{
    public class RiderInromation
    {

    }

    public class DiverInromation
    {
        public AppUser User { get; set; }
        public string UserId { get; set; }
        public RideInformation RideInformation {get;set;}
    }

    public class DiverCarInromation
    {
        public Guid Id { get; set; }
        //public AppUser
    }

    public class RideInformation
    {
        public Guid Id { get; set; }
        public string FirstStreet { get; set; }
        public string SecondStret { get; set; }
        public string StartTime { get; set; }
        public string Destination { get; set; }
        public string Landmark { get; set; }
        [ForeignKey("UserId")]
        public AppUser User { get; set; }
        public string UserId { get; set; }
        public bool Active { get; set; }
    }
}