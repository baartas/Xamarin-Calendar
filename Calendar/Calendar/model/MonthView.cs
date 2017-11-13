using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayModel;

namespace Calendar.model
{
    public static class MonthView
    {
        private static IEnumerable<Day>GetDayList(int year, int month)
        {
            return Enumerable.Range(1, DateTime.DaysInMonth(year, month)).Select(day => new Day(new DateTime(year,month,day))).ToList();
        }

      
        public static IEnumerable<Day> GetMonthView(int year, int month)
        {
            //0  1  2  3  4  5  6
            //7  8  9  10 11 12 13
            //14 15 16 17 18 19 20
            //21 22 23 24 25 26 27
            //28 29 30 31 32 33 34
            //35 36 37 38 39 40 41

            Day[]ToReturn=new Day[42];
            
            int StartIndex=new Func<int>(() =>
            {
                switch (GetDayList(year,month).First().Date.DayOfWeek)
                {
                    case DayOfWeek.Monday: return 0;
                    case DayOfWeek.Tuesday: return 1;
                    case DayOfWeek.Wednesday: return 2;
                    case DayOfWeek.Thursday: return 3;
                    case DayOfWeek.Friday: return 4;
                    case DayOfWeek.Saturday: return 5;
                    default: return 6;
                }

            }).Invoke();


            if (StartIndex == 0)
                StartIndex = 7;

            if (StartIndex != 0)
            {
                int temp_year = year;
                int temp_month = month - 1;

                if (month == 1)
                {
                    temp_year = temp_year - 1;
                    temp_month = 12;
                }

                for (int i = 0; i < StartIndex; i++)
                {

                    int day = DateTime.DaysInMonth(temp_year, temp_month) - StartIndex + i + 1;

                    ToReturn[i] = new Day(new DateTime(temp_year, temp_month, day));
                }
            }

            foreach (var i in GetDayList(year,month))
            {
                ToReturn[StartIndex] = i;
                StartIndex++;
            }
            int tday = 1;
            for (int i = StartIndex; i < 42; i++)
            {
                int temp_year = year;
                int temp_month = month +1;

                if (month == 12)
                {
                    temp_year = temp_year+1;
                    temp_month = 1;
                }

                
                ToReturn[i]=new Day(new DateTime(temp_year,temp_month,tday)){DayValue = EventType.empty};
                tday++;
            }

            return ToReturn;
        }
    }
}
