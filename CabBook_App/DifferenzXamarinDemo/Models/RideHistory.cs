/*Author: Mittal Patel
Date: March 16, 2018
Purpose: Ride Information Getter Setter*/

using System;
using SQLite;

namespace CabBook
{
	public class RideInformation
    {
		public RideInformation()
		{
		}
        public Guid Id { get; set; }
        public string FirstStreet { get; set; }
        public string SecondStret { get; set; }
        public string StartTime { get; set; }
        public string Destination { get; set; }
        public string Landmark { get; set; }
        public string UserId { get; set; }
        public bool Active { get; set; }
    }
}

