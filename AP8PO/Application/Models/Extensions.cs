using System;
using System.Collections.Generic;

namespace AP8PO
{
    public static class Extensions
    {
        public static IEnumerable<LoadTypes> GetEnumTypes => (IEnumerable<LoadTypes>)Enum.GetValues(typeof(LoadTypes));
    }

}
