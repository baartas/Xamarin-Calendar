using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DateModel;
using Newtonsoft.Json;

namespace Calendar.Data_Acces_Layer
{
    public class ConnectionContext
    {
        public async void AddDayEventToDB(DayEvent dayEvent)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://url");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            string group = "TEST";
            DayEventJson dayEventJson = DayEventConverter.DayEventToJson(dayEvent);
            string JsonEvent = JsonConvert.SerializeObject(dayEventJson);

            string json = $"{{\"group\":\"{group}\",\"event\":{JsonEvent} }}";

            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
              
                var httpResponse = await httpClient.PostAsync("http://zadania-cj.herokuapp.com/api/insert", httpContent);
                if (httpResponse.Content != null)
                {
                   
                }
            }
        }
    }
}
