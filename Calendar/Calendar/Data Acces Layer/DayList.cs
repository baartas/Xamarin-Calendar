using DayModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DateModel;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;

namespace Calendar.Data_Acces_Layer
{
    public class DayList
    {
        public static async Task<IEnumerable<Day>> GetDayListAsync(int year, int month)
        {
            var x = Enumerable.Range(1, DateTime.DaysInMonth(year, month)).Select(day => new Day(new DateTime(year, month, day))).ToList();

            var Days=new Day[33];
            for (int i = 0; i < 33; i++)
            {
                Days[i]=new Day(new DateTime(1000,1,1));
            }

            using (var connection = new HttpClient())
            {
                string url=string.Format("http://zadania-cj.herokuapp.com/api/month?group=TEST&year={0}&month={1}",year,month);
                var jsonstr = await connection.GetStringAsync(url);
                var Parser = new JsonToListOfDays(jsonstr);
                Days = Parser.RetunAllDays();

            }

            for (int i = 1; i <= DateTime.DaysInMonth(year, month); i++)
            {
                if (Days[i].Date.Year > 1002)
                    x[i-1] = Days[i];
            }
            return x;
        }
    }
}
