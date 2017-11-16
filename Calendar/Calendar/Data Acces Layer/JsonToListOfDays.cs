using System;
using System.Collections.Generic;
using System.Linq;
using DateModel;
using DayModel;
using Newtonsoft.Json;

namespace Calendar.Data_Acces_Layer
{


    public class JsonToListOfDays
    {
        private Day[] Days;
       

        private Dictionary<int, List<DayEventJson>> ParsedJson;

        private List<DayEvent> ParseDayEventJson(List<DayEventJson> ListOfJsonEvents)
        {
            var ToReturn = new List<DayEvent>();
            foreach (DayEventJson i in ListOfJsonEvents)
            {
               ToReturn.Add(DayEventConverter.JsonToDayEvent(i));
            }

            return ToReturn;
        }

        private void FillDays()
        {
            foreach (var elements in ParsedJson)
            {
                Days[elements.Key].Events = ParseDayEventJson(elements.Value);
                Days[elements.Key].Date = Days[elements.Key].Events.First().Time;
            }
        }

        public Day[] RetunAllDays()
        {
            return Days;
        }

        public JsonToListOfDays(string JsonString)
        {
            Days = new Day[32];
            for (int i = 0; i < 32; i++)
            {
                Days[i] = new Day(new DateTime(1000, 1, 1));
            }

            if (JsonString != "\"{}\"" )
            {
                ParsedJson = JsonConvert.DeserializeObject<Dictionary<int, List<DayEventJson>>>(JsonString);
                FillDays();
            }            
        }
    }
}
