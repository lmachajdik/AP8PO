using AP8PO.Database.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AP8PO
{
    public class Model :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public class Employee
    {
        public const int FullTimeMaxHours = 160;

        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Telephone { get; set; }
        public string WorkEmail { get; set; }
        public string PrivateEmail { get; set; }
        public bool Doctorand { get; set; }

        public int LoadPercent { get; set; } //uvazok - 100% = fullTime
        public int MaxLoad => (int)(FullTimeMaxHours * LoadPercent / 100.0);

        public List<CourseCommit> Commits { get; set; }

        public LoadTypes LoadType
        {
            get
            {
                switch (LoadPercent)
                {
                   // case 0: return LoadTypes.Agreement;
                    case 50: return LoadTypes.HalfTime;
                    case 100: return LoadTypes.FullTime;
                    default: return LoadTypes.Other;
                }
            }
        }

        public DbEmployee ToDbEmployee()
        {
            return new DbEmployee()
            {
                Name = this.Name,
                Surname = this.Surname,
                Telephone = this.Telephone,
                WorkEmail = this.WorkEmail,
                PrivateEmail = this.PrivateEmail,
                Doctorand = this.Doctorand,
                LoadPercent = this.LoadPercent,
                //Commits = this.Commits.ToList()
            };
        }

        public override string ToString()
        {
            return Name + " " + Surname;
        }
    }

}
