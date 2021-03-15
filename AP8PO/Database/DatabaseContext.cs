using AP8PO.Database.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP8PO
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base()
        {
            //System.Data.Entity.Database.SetInitializer<DatabaseContext>(new CreateDatabaseIfNotExists<DatabaseContext>());
           System.Data.Entity.Database.SetInitializer<DatabaseContext>(new DropCreateDatabaseIfModelChanges<DatabaseContext>());
        }

        public DbSet<Employee> Employees { get; set; }
        // public DbSet<Group> Groups { get; set; }

        public void Insert(Employee employee)
        {
            Employees.Local.Add(employee);
        }

        public void Delete(Employee employee)
        {
            Employees.Local.Remove(employee);
        }
    }
}
