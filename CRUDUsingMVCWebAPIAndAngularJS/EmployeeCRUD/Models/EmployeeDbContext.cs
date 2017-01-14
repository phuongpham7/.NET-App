using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmployeeCRUD.Models
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(): base()
        {
            Database.SetInitializer<EmployeeDbContext>(new EmployeeDbContextInitializer());
        }

        public DbSet<Employee> Employees { get; set; }
    }
}