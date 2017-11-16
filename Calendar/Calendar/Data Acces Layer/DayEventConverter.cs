using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DateModel;
using DayModel;

namespace Calendar.Data_Acces_Layer
{
    public static class DayEventConverter
    {
        public static DayEvent JsonToDayEvent(DayEventJson i)
        {
            var dayevent = new DayEvent();
            dayevent.Title = i.ev_name;
            dayevent.Content = i.ev_content;
            dayevent.Type = new Func<EventType>(() =>
            {
                if (i.ev_type == "homework")
                    return EventType.homework;
                else if (i.ev_type == "test")
                    return EventType.test;
                else
                    return EventType.other;
            }).Invoke();
            dayevent.Time = new Func<DateTime>(() =>
            {

                string y = i.ev_date[0].ToString() + i.ev_date[1].ToString() + i.ev_date[2].ToString() +
                           i.ev_date[3].ToString();
                int year = int.Parse(y);

                string m = i.ev_date[4].ToString() + i.ev_date[5].ToString();
                int month = int.Parse(m);

                string d = i.ev_date[6].ToString() + i.ev_date[7].ToString();
                int day = int.Parse(d);

                string hh = i.ev_date[8].ToString() + i.ev_date[9].ToString();
                int hour = int.Parse(hh);

                string mm = i.ev_date[10].ToString() + i.ev_date[11].ToString();
                int min = int.Parse(mm);

                return new DateTime(year, month, day, hour, min, 0);

            }).Invoke();

            return dayevent;
        }

        public static DayEventJson DayEventToJson(DayEvent dayEvent)
        {
            DayEventJson ToReturn= new DayEventJson();

            ToReturn.ev_content = dayEvent.Content;
            ToReturn.ev_name = dayEvent.Title;
            ToReturn.ev_type = dayEvent.Type.ToString();
            ToReturn.ev_date= new Func<string>(() =>
            {
                string d = dayEvent.Time.Year.ToString();

                if (dayEvent.Time.Month < 10)
                    d += 0;
                d += dayEvent.Time.Month;
                if (dayEvent.Time.Day < 10)
                    d += 0;
                d += dayEvent.Time.Day;
                if (dayEvent.Time.Hour < 10)
                    d += 0;
                d += dayEvent.Time.Hour;
                if (dayEvent.Time.Minute < 10)
                    d += 0;
                d += dayEvent.Time.Minute;

                return d;

            }).Invoke();

            return ToReturn;

        }
    }
}
