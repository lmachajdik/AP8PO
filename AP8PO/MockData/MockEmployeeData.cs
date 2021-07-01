using System.Collections.ObjectModel;

namespace AP8PO.MockData
{
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
                    AllocationPercent = 100,
                    WorkEmail = "ekral@utb.cz",
                    PrivateEmail = "kral@gmail.com",
                    Doctorand=false,
                    Telephone="+42012345678"
                },
                new Employee()
                {
                    FirstName = "Tomas",
                    Surname = "Juřena",
                    AllocationPercent = 100,
                    WorkEmail = "jurena@utb.cz",
                    Doctorand=true,
                    Telephone="+42087654321"
                },
            };
        }
        
    }
}
