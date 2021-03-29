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
        public DbSet<Group> Groups { get; set; }
        public DbSet<Course> Courses { get; set; }

        public void Insert(Group group)
        {
            Groups.Local.Add(group);
        }

        public void Delete(Group group)
        {
            Groups.Local.Remove(group);
        }

        public void Insert(Course course)
        {
            Courses.Local.Add(course);
        }

        public void Delete(Course course)
        {
            Courses.Local.Remove(course);
        }

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
