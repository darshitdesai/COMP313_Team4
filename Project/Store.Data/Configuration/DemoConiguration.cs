using CabBook.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabBook.Data.Configuration
{
    public class DemoConiguration : EntityTypeConfiguration<Demo>
    {
        public DemoConiguration()
        {
            ToTable("Demo");
            Property(c => c.Name).IsRequired().HasMaxLength(50);
        }
    }
}
