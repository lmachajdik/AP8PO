using System.Collections.Generic;

namespace AP8PO
{
    public class Employee
    {
        public const int FullTimeMaxHours = 160;

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Telephone { get; set; }
        public string WorkEmail { get; set; }
        public string PrivateEmail { get; set; }
        public bool Doctorand { get; set; }

        public int LoadPercent { get; set; } //uvazok - 100% = fullTime
        public int MaxLoad => (int)(FullTimeMaxHours * LoadPercent/100.0);

        public List<CourseCommit> Commits { get; set; }

        public LoadTypes LoadType
        {
            get
            {
                switch (LoadPercent)
                {
                    case 0: return LoadTypes.Agreement;
                    case 50: return LoadTypes.HalfTime;
                    case 100: return LoadTypes.FullTime;
                    default: return LoadTypes.Other;
                }
            }
        }
    }

}
