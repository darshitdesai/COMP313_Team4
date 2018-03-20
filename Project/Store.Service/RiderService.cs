using CabBook.Data.Infrastructure;
using CabBook.Data.Repositories;
using CabBook.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabBook.Service
{
    public class RiderService : IRiderService
    {
        private readonly IRiderRepository riderRepository;
        private readonly IDriverRepository driverRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly ICarDetailsRepository carDetailsRepository;

        public RiderService(IRiderRepository riderRepository, IUnitOfWork unitOfWork, IDriverRepository driverRepository, ICarDetailsRepository carDetailsRepository)
        {
            this.riderRepository = riderRepository;
            this.driverRepository = driverRepository;
            this.carDetailsRepository = carDetailsRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<RideDetails> GetAllData()
        {
            var data = new List<RideDetails>();

            var allDrivers = riderRepository.GetAll();

            foreach (var driver in riderRepository.Drivers())
            {
                var rideDetail = new RideDetails();
                rideDetail.rideInfo = driverRepository.GetByDriverId(driver.Id);
                rideDetail.carDetails = carDetailsRepository.GetDetailsByDriverId(driver.Id);
                rideDetail.UserDetails = driver;

                data.Add(rideDetail);
                //data.Add(driver.rideInfo)
            }

            return data;
        }

        public List<RideInformation> GetDatabyDriverId(string id)
        {
            var rideDetail = new List<RideInformation>();
            rideDetail = driverRepository.GetAllByDriverId(id).ToList();
            return rideDetail;
        }


        public RideDetails GetData(int id)
        {
            var data = riderRepository.GetById(id);
            return data;
        }

        public void SaveData()
        {
            unitOfWork.Commit();
        }
    }
}
