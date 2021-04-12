using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP8PO.MockData
{
    public class LocalData
    {
        public ObservableCollection<Course> AllCourses => DataConnection.DbContext.Courses.Local;
    }
}
