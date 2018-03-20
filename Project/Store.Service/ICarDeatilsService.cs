using CabBook.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabBook.Service
{
    public interface ICarDeatilsService
    {
        void CreateData(CarDetails CarDetails);
        CarDetails GetCarDetailsByDriverId(string driverId);
        void SaveData();
    }
}
