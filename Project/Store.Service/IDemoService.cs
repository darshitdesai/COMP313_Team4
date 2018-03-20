using CabBook.Data.Infrastructure;
using CabBook.Model;
using CabBook.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CabBook.Service
{
    public interface IDemoService
    {
        IEnumerable<Demo> GeData();
        Demo GetData(int id);
        void CreateData(Demo gadget);
        void SaveData();
    }
}
