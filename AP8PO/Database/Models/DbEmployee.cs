using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP8PO.Database.Models
{
    public class DbEmployee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Telephone { get; set; }
        public string WorkEmail { get; set; }
        public string PrivateEmail { get; set; }
        public bool Doctorand { get; set; }
        public int LoadPercent { get; set; } //uvazok - 100% = fullTime

        public ICollection<DbCourseCommit> Commits { get; set; }

        public Employee ToEmployee()
        {
            return new Employee()
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
    }
}
