using System;
using System.Collections.Generic;
using System.Text;

namespace d8class07Lists.Classes
{
    class Date
    {
        public int DayOfMonth { get; set; }
        public DayOfWeek DayOfWeek { get; set; }

        public Months Month { get; set; }
    }

    enum DayOfWeek : byte
    {
        Sunday = 15,
        Monday = 4,
        Tuesday,
        Wednesday,
        Thursday =11 ,
        Friday,
        Saturday
    }

    enum Months
    {
        Jan,
        Feb,
        March,
        April,
        May,
        June = March + Jan,
        July
    }
}
