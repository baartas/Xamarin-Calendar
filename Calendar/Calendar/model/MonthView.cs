using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calendar.Data_Acces_Layer;
using DateModel;
using DayModel;

namespace Calendar.model
{
    public static class MonthView
    {   
        public static async Task<List<Day>> GetMonthView(int year, int month)
        {          
            var DaysInCurrentMonth = await DayList.GetDayListAsync(year, month);

            Day[]ToReturn=new Day[42];
            
            int StartIndex=new Func<int>(() =>
            {
                switch (DaysInCurrentMonth.First().Date.DayOfWeek)
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

            #region Fill list up start index
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
            #endregion

            #region Fill list with downloaded data

            foreach (var i in DaysInCurrentMonth)
            {
                ToReturn[StartIndex] = i;
                StartIndex++;
            }

            #endregion

            #region Fill up to 41 index
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
            #endregion

            return ToReturn.ToList();
        }
    }
}
