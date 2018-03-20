using CabBook.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabBook.Service
{
    public interface IRiderService
    {
        IEnumerable<RideDetails> GetAllData();
        List<RideInformation> GetDatabyDriverId(string id);
        RideDetails GetData(int id);
        void SaveData();
    }
}
