using CabBook.Model.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabBook.Model.Models
{
    public class CarDetails
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Please Enter Car Name")]
        public string CarName { get; set; }
        [Required(ErrorMessage = "Please Enter License Number")]
        public string LicenseNumber { get; set; }
        public string LicenseType { get; set; }
        [Required(ErrorMessage = "Please Enter Car Number")]
        public string CarNumer { get; set; }
        public bool BabySeat { get; set; }
        [ForeignKey("UserId")]
        public AppUser User { get; set; }
        public string UserId { get; set; }
    }
}
