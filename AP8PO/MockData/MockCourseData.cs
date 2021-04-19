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
                    MaxStudentsPerClass=24,
                    HoursOfLectures=2,
                    HoursOfPractises=2,
                    HoursOfSeminars=0
                }
            };
        }

    }
}
