﻿using AP8PO.Database.Models;
using AP8PO.Enums;
using System.Collections.Generic;

namespace AP8PO
{

    public class Employee : Model
    {

        public const int FullTimeMaxHours = 160;

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Telephone { get; set; }
        public string WorkEmail { get; set; }
        public string PrivateEmail { get; set; }
        public bool Doctorand { get; set; }

        private int _loadPercent;
        public int LoadPercent //uvazok - 100% = fullTime
        {
            get
            {
                return _loadPercent;
            }
            set
            {            
                var val = GetLoadType(value);
                if (val != LoadType)
                {
                    LoadType = val;
                    OnPropertyChanged(nameof(LoadType));
                }
                _loadPercent = value;
                OnPropertyChanged();

            }

        } 
        public int MaxLoad => (int)(FullTimeMaxHours * LoadPercent / 100.0);

        //public LoadTypes LT { get; set; }
        private LoadTypes _loadType;
        public LoadTypes LoadType 
        { 
            get
            {
                return _loadType;
            }
            set
            {
                _loadType = value;
                int val = (int)value;
                
                if (LoadPercent != val)
                {
                    LoadPercent = val;
                    OnPropertyChanged(nameof(LoadPercent));
                }
                OnPropertyChanged();
            }
        }

        public LoadTypes GetLoadType(int percent)
        {
                switch (percent)
                {
                    case 50: return LoadTypes.HalfTime;
                    case 100: return LoadTypes.FullTime;
                    default: return LoadTypes.Agreement;
                }
        }
        public List<CourseCommit> Commits { get; set; }

        public DbEmployee ToDbEmployee()
        {
            return new DbEmployee()
            {
                Name = this.FirstName,
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
            return FirstName + " " + Surname;
        }
    }

}
