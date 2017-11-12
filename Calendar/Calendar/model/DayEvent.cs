using System;
using DayModel;

namespace DateModel
{ 
    public class DayEvent
    {
        public DateTime Time { get; set; }

        public EventType Type { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }

}

