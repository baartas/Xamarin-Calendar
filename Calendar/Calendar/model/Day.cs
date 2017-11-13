using DateModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DayModel
{
    public enum EventType
    {
        empty, homework, other, test
    }
    public class Day
    {
        public DateTime Date { get; set; }

        public EventType DayValue
        {
            get
            {   
                if(Events.Any())
                    return Events.OrderByDescending(s => s.Type).First().Type;
                else return EventType.empty;
            }
            set { }
        }



        public List<DayEvent> Events { get; set; }

        public Day(DateTime Date)
        {
            this.Date = Date;
            this.Events=new List<DayEvent>();
        }
        
    }

}

