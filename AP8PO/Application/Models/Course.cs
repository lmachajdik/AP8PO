using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AP8PO
{
    public class Course : Model
    {
        private Group group;
        private int? groupID;
        private string name;
        private string abbrevation;

        [Key]
        public int ID { get; set; }

        [ForeignKey("Group")]
        public int? GroupID
        {
            get => groupID;
            set
            {
                groupID = value;
                OnPropertyChanged();
            }
        }
        public Group Group
        {
            get => group;
            set
            {
                group = value;
                OnPropertyChanged();
            }
        }

        public string Name { get => name; set { name = value; OnPropertyChanged(); } }
        public string Abbrevation { get => abbrevation; set { abbrevation = value; OnPropertyChanged(); } }
        public int MaxStudentsPerClass { get; set; }

        public int NumberOfWeeks { get; set; }
        public int HoursOfLectures { get; set; }
        public int HoursOfPractises { get; set; }
        public int HoursOfSeminars { get; set; }

        public CourseCompletionTypes CompletionType { get; set; }
        public Language Language { get; set; }

        public override string ToString()
        {
            return Abbrevation;
        }

    }

}
