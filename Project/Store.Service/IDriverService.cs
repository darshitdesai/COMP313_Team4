using CabBook.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabBook.Service
{
    public interface IDriverService
    {
        void CreateData(RideInformation rideinformation);
        string DiactiveotherRides(string driveId);
        void SaveData();
    }
}
