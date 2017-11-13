using DayModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DateModel;

namespace Calendar.Data_Acces_Layer
{
    public class DayList
    {
        public static async Task<IEnumerable<Day>> GetDayList(int year, int month)
        {
            var x = Enumerable.Range(1, DateTime.DaysInMonth(year, month)).Select(day => new Day(new DateTime(year, month, day))).ToList();
            return x;
        }
    }
}
