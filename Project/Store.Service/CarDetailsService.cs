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
    public class CarDetailsService : ICarDeatilsService
    {
        private readonly ICarDetailsRepository carDetailsRepository;
        private readonly IUnitOfWork unitOfWork;

        public CarDetailsService(ICarDetailsRepository carDetailsRepository, IUnitOfWork unitOfWork)
        {
            this.carDetailsRepository = carDetailsRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateData(CarDetails CarDetails)
        {
            carDetailsRepository.Add(CarDetails);
        }

        public CarDetails GetCarDetailsByDriverId(string driverId)
        {
            return carDetailsRepository.GetDetailsByDriverId(driverId);
        }

        public void SaveData()
        {
            unitOfWork.Commit();
        }
    }
}
