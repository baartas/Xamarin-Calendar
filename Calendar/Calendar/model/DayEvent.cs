using System;
using DayModel;

namespace DateModel
{ 
    public class DayEvent
    {
        public DateTime Time { get; set; }

        public string time
        {
            get { return $"{this.Time.Hour}:{this.Time.Minute}"; }
        }

        public EventType Type { get; set; }

        public string type
        {
            get
            {
                switch (this.Type)
                {
                    case EventType.test: return "#f44147";
                    case EventType.homework: return "#4286f4";
                    case EventType.other: return "#097c0b";
                    default: return "#000000";
                }
            }
        }

        public string Title { get; set; }

        public string Content { get; set; }
    }

}

