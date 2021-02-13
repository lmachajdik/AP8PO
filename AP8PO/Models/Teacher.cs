namespace AP8PO
{
    internal class Teacher
    {
        public static int FullTimeMaxHours = 80;

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }

        public int Load { get; set; }
        public int MaxLoad => (int)(FullTimeMaxHours * Load/100.0);

        public LoadTypes LoadType
        {
            get
            {
                switch (Load)
                {
                    case 50: return LoadTypes.HalfTime;
                    case 100: return LoadTypes.FullTime;
                    default: return LoadTypes.Other;
                }
            }
        }
    }

}
