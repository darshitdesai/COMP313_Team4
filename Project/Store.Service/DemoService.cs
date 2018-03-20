using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabBook.Data;
using CabBook.Data.Infrastructure;
using CabBook.Model.Models;

namespace CabBook.Service
{
    public class DemoService : IDemoService
    {

        private readonly IDemoRepository demoRepository;
        private readonly IUnitOfWork unitOfWork;

        public DemoService(IDemoRepository demoRepository, IUnitOfWork unitOfWork)
        {
            this.demoRepository = demoRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateData(Demo demo)
        {
            demoRepository.Add(demo);
        }

        public void UpdateData(Demo demo)
        {
            demoRepository.Update(demo);
        }

        public IEnumerable<Demo> GeData()
        {
            var data = demoRepository.GetAll();
            return data;
        }

        public Demo GetData(int id)
        {
            var data = demoRepository.GetById(id);
            return data;
        }

        public void SaveData()
        {
            unitOfWork.Commit();
        }
    }
}
