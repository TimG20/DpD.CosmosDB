using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DpD.CosmosDB
{
    using Newtonsoft.Json;
    public class Lesson
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "dayOfYear")]
        public string DayOfYear { get; set; }

        [JsonProperty(PropertyName = "numDayOfYear")]
        public int NumDayOfYear { get; set; }

        [JsonProperty(PropertyName = "monthDay")]
        public string MonthDay { get; set; }

        [JsonProperty(PropertyName = "lessonTitle")]
        public string LessonTitle { get; set; }

        [JsonProperty(PropertyName = "quote")]
        public string Quote { get; set; }

        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }

        [JsonProperty(PropertyName = "actionPoint")]
        public string ActionPoint { get; set; }

        [JsonProperty(PropertyName = "book")]
        public string Book { get; set; }
    }
}