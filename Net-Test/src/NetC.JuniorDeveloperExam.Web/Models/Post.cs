using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace NetC.JuniorDeveloperExam.Web.Models
{
    public class Post
    {
        [JsonProperty(PropertyName ="id")]
        public int ID { get; set; }

        [JsonProperty(PropertyName = "date")]
        public DateTime Date { get; set; }
        
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        
        [JsonProperty(PropertyName = "image")]
        public string ImageUrl { get; set; } 
        
        [JsonProperty(PropertyName = "htmlContent")]
        public string HtmlContent { get; set; }  
        
        [JsonProperty(PropertyName = "comments")]
        public List<Comment> Comments { get; set; }
    }
}