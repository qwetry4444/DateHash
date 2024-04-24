using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateHash
{
    public class Date
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public Date() { }

        public Date(int day, int mounth, int year)
        {
            Day = day;
            Month = mounth;
            Year = year;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(Year);
            stringBuilder.Append("Y : "); 

            stringBuilder.Append(Month);
            stringBuilder.Append("M : "); 

            stringBuilder.Append(Day);
            stringBuilder.Append("D : ");

            return stringBuilder.ToString();
        }
    }

    
}
