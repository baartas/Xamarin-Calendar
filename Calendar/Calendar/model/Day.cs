using DateModel;
using System;
using System.Collections.Generic;

namespace DayModel
{
    public enum EventType
    {
        empty,homework,test,other
    }
    public class Day
    {
        public DateTime Date { get; set; }

        public EventType DayValue;

        public List<DayEvent> Events { get; set; }

        public Day(DateTime Date)
        {
            this.Date = Date;
            this.Events=new List<DayEvent>();
            DayValue = EventType.empty;
        }
        
    }

}

