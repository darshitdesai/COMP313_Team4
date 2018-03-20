using CabBook.Model;
using CabBook.Model.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabBook.Data
{
    public class StoreSeedData : DropCreateDatabaseIfModelChanges<DatabaseEnities>
    {
        protected override void Seed(DatabaseEnities context)
        {
            
            GetData().ForEach(x => context.demo.Add(x));
            var rm = new RoleManager<IdentityRole>(
               new RoleStore<IdentityRole>(new DatabaseEnities()));
            Roles().ForEach(x => rm.Create(new IdentityRole(x.Name)));
            context.SaveChanges();
        }
        
        private static List<Demo> GetData()
        {
            return new List<Demo>
            {
                new Demo {
                    Field2 = "Test1",
                    Id = Guid.NewGuid(),
                    Name = "Test Name 1"
                },
                new Demo {
                    Field2 = "Test2",
                    Id = Guid.NewGuid(),
                    Name = "Test Name 2"
                },
                new Demo {
                    Field2 = "Test3",
                    Id = Guid.NewGuid(),
                    Name = "Test Name 3"
                },
                new Demo {
                    Field2 = "Test4",
                    Id = Guid.NewGuid(),
                    Name = "Test Name 4"
                }
            };
        }

        private static List<Microsoft.AspNet.Identity.EntityFramework.IdentityRole> Roles()
        {
            return new List<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>
            {
                new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
                {
                    Name = "Admin"
                },
                new Microsoft.AspNet.Identity.EntityFramework.IdentityRole(){
                    Name= "Driver"
                },
                new Microsoft.AspNet.Identity.EntityFramework.IdentityRole(){
                    Name= "Rider"
                },
            };

        }


        }
}
