using System.Collections.ObjectModel;

namespace AP8PO.UserControls
{
    public class MockEmployeeData
    {
        public ObservableCollection<Employee> MyListBoxItems { get; set; }
        public MockEmployeeData()
        {
            MyListBoxItems = new ObservableCollection<Employee>()
            {
                new Employee()
                {
                    Name = "Erik",
                    Surname = "Kral",
                    LoadPercent = 100,
                    WorkEmail = "ekral@utb.cz",
                    Doctorand=false,
                    Telephone="+42012345678"
                }
            };
        }
        
    }
}
