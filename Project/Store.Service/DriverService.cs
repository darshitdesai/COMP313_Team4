using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabBook.Model.Models;
using CabBook.Data.Repositories;
using CabBook.Data.Infrastructure;

namespace CabBook.Service
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository driverRepository;
        private readonly IUnitOfWork unitOfWork;

        public DriverService(IDriverRepository driverRepository, IUnitOfWork unitOfWork)
        {
            this.driverRepository = driverRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateData(RideInformation rideinformation)
        {
            driverRepository.Add(rideinformation);
        }

        public IEnumerable<RideInformation> GeData()
        {
            var data = driverRepository.GetAll();
            return data;
        }

        public string DiactiveotherRides(string driveId)
        {
            var rideinfo = driverRepository.GetByDriverId(driveId);
            if (rideinfo != null)
            {
                rideinfo.Active = false;
                driverRepository.Update(rideinfo);
            }
            return "success";
        }

        public RideInformation GetData(int id)
        {
            var data = driverRepository.GetById(id);
            return data;
        }

        public void SaveData()
        {
            unitOfWork.Commit();
        }
    }
}
