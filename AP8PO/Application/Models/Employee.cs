using AP8PO.Converters;
using AP8PO.Database.Models;
using AP8PO.Enums;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace AP8PO
{

    public class Employee : Model
    {

        public const int FullTimeMaxHours = 160;

        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Telephone { get; set; }
        public string WorkEmail { get; set; }
        public string PrivateEmail { get; set; }
        public bool Doctorand { get; set; }

        private int _allocationPercent;
        private int _currentLoad;

        public int AllocationPercent //uvazok - 100% = fullTime
        {
            get
            {
                return _allocationPercent;
            }
            set
            {            
                var val = GetLoadType(value);
                if (val != LoadType)
                {
                    LoadType = val;
                    OnPropertyChanged(nameof(LoadType));
                }
                _allocationPercent = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(MaxLoad));
                OnPropertyChanged(nameof(ActualLoadPercent));
                OnPropertyChanged(nameof(CurrentLoad));
            }

        }

        [NotMapped]
        public int ActualLoadPercent 
        {
            get
            {
                if (MaxLoad == 0)
                    return 0;
                return (int)(CurrentLoad / (double)MaxLoad * 100.0);

            }
        }
        public int CurrentLoad 
        {
            get => _currentLoad;
            set
            {
                _currentLoad = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ActualLoadPercent));
            }
        }
        public int MaxLoad => (int)(FullTimeMaxHours * AllocationPercent / 100.0);

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
                
                if (AllocationPercent != val)
                {
                    AllocationPercent = val;
                    OnPropertyChanged(nameof(AllocationPercent));
                    OnPropertyChanged(nameof(ActualLoadPercent));
                }
                OnPropertyChanged();
                OnPropertyChanged(nameof(CurrentLoad));

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

        [JsonConverter(typeof(IDArrayToStringConverter<CourseCommit>))]
        public ObservableCollection<CourseCommit> Commits { get; set; } = new ObservableCollection<CourseCommit>();

        public override string ToString()
        {
            return FirstName + " " + Surname;
        }
    }

}
