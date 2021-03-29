using System.Collections.ObjectModel;

namespace AP8PO.MockData
{
    public class MockCourseData
    {
        public ObservableCollection<Course> MockData { get; set; }
        public MockCourseData()
        {
            MockData = new ObservableCollection<Course>()
            {
                new Course()
                {
                    Abbrevation="FG",
                    Name="First Group",
                    CompletionType = CourseCompletionTypes.Examination,
                    Language=Language.Czech,
                    MaxStudents=24,
                    HoursOfLectures=2,
                    HoursOfClasses=2,
                    HoursOfSeminars=0
                }
            };
        }

    }

    public class MockEmployeeData
    {
        public ObservableCollection<Employee> MockData { get; set; }
        public MockEmployeeData()
        {
            MockData = new ObservableCollection<Employee>()
            {
                new Employee()
                {
                    FirstName = "Erik",
                    Surname = "Kral",
                    LoadPercent = 100,
                    WorkEmail = "ekral@utb.cz",
                    PrivateEmail = "kral@gmail.com",
                    Doctorand=false,
                    Telephone="+42012345678"
                },
                new Employee()
                {
                    FirstName = "Tomas",
                    Surname = "Juřena",
                    LoadPercent = 100,
                    WorkEmail = "jurena@utb.cz",
                    Doctorand=true,
                    Telephone="+42087654321"
                },
            };
        }
        
    }
}
