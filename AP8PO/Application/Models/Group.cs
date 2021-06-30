using AP8PO.Converters;
using AP8PO.Enums;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace AP8PO
{
    public class Group : Model
    {
        private ObservableCollection<Course> courses;

        public string Name { get; set; }
        public string Abbrevation { get; set; }

        public Semester Semester { get; set; }
        public StudyForm StudyForm { get; set; }
        public StudyType StudyType { get; set; }

        public int StudentsCount { get; set; }
        public int Year { get; set; }

        [JsonConverter(typeof(IDArrayToStringConverter<Course>))]
        public ObservableCollection<Course> Courses 
        { 
            get => courses;
            set
            {
                courses = value;
                OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return Abbrevation;
        }
    }
}
