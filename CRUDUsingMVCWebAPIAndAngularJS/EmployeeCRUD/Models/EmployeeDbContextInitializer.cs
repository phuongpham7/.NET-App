using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmployeeCRUD.Models
{
    public class EmployeeDbContextInitializer : DropCreateDatabaseIfModelChanges<EmployeeDbContext>
    {
        protected override void Seed(EmployeeDbContext context)
        {
            var list = new List<Employee>
            {
                new Employee
                {
                    FirstName = "Alan", LastName = "Walker", Description = "Alan Walker", DateOfBirth = DateTime.Now.AddYears(-30), Country = "US", State = "IL", Salary = 130000, IsActive = true
                },
                new Employee
                {
                    FirstName = "Tom", LastName = "Cruises", Description = "Tom Cruises", DateOfBirth = DateTime.Now.AddYears(-50), Country = "US", State = "CA", Salary = 200000, IsActive = true
                },
                new Employee
                {
                    FirstName = "Nicole", LastName = "Kidman", Description = "Nicole Kidman", DateOfBirth = DateTime.Now.AddYears(-39), Country = "US", State = "NV", Salary = 150000, IsActive = true
                }
            };
            list.ForEach(e =>
            {
                context.Employees.Add(e);
            });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}