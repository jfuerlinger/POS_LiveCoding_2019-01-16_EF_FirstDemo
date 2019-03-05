using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfDemo.Core.Entities;


namespace EfDemo.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            
        }

        public DbSet<Pupil> Pupils { get; set; }

        public DbSet<SchoolClass> SchoolClasses { get; set; }
    }
}
