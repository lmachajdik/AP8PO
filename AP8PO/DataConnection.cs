using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP8PO
{
    public class DataConnection
    {
        private static DataConnection _instance;
        public static DataConnection Instance 
        {
            get {
                if (_instance == null)
                    _instance = new DataConnection();

                return _instance;
            }
        }

        private static DatabaseContext _dbContext;
        public static DatabaseContext DbContext
        {
            get
            {
                if (_dbContext == null)
                    _dbContext = new DatabaseContext();

                return _dbContext;
            }
        }

        public DataConnection()
        {
            _dbContext = new DatabaseContext();
        }

        public static void CreateNewContext()
        {  
            _dbContext.CourseCommits.Local.Clear();
            _dbContext.Courses.Local.Clear();
            _dbContext.Groups.Local.Clear();
            _dbContext.Employees.Local.Clear();
            _dbContext.SaveChanges();
        }
    }
}
