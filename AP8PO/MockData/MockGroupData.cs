using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP8PO.MockData
{
    public class MockGroupData
    {
        public ObservableCollection<Group> MockData { get; set; }
        public MockGroupData()
        {
            MockData = new ObservableCollection<Group>()
            {
                new Group()
                {
                    Name="Softwarove Inzinierstvo",
                    Abbrevation="SWI",
                    Semester=Semester.Summer,
                    StudentsCount=12,
                    StudyType=Enums.StudyType.Bachelor,
                    StudyForm=StudyForm.Daily,
                    Year=1 
                }
            };
        }

    }
}
