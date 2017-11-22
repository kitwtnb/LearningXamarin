using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningXamarin.Models
{
    public class QiitaContent
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string URL { get; set; }
    }
}
