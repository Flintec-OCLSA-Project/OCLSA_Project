using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCLSA_Project_Version_01.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<LoadCell> LoadCells { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public ApplicationDbContext() : base("name=DefaultConnection")
        {

        }
    }
}
