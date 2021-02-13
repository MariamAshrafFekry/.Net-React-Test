using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace NetC.JuniorDeveloperExam.Web.Models
{
    public class Reply
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "date")]
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "emailAddress")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
    }
}