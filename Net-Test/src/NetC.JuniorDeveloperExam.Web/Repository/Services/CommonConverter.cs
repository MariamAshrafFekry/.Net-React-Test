using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NetC.JuniorDeveloperExam.Web.Repository.IServices;
using Newtonsoft.Json;

namespace NetC.JuniorDeveloperExam.Web.Repository.Services
{
    public  static class CommonConverter
    {
        public static  T DeserializeObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
        public static string SerializeObject<T>(T items)
        {
            return JsonConvert.SerializeObject(items, Formatting.Indented);
        }
    }
}