using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using NetC.JuniorDeveloperExam.Web.Repository.IServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetC.JuniorDeveloperExam.Web.Repository.Services
{
    public class PostsService : IPosts
    {
        public bool Add(Models.Post post)
        {
            try
            {
                var path = HttpContext.Current.Server.MapPath("~/App_Data/blog-Posts.json");
                if (!File.Exists(path))
                    File.Create(path);
                List<Models.Post> posts = GetAll();
                if (posts == null)
                    posts = new List<Models.Post>();
                post.ID = posts.Max(p => p.ID) + 1;
                posts.Add(post);
                File.WriteAllText(path, CommonConverter.SerializeObject(new { blogPosts = posts.ToArray() }));
                return true;

            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public List<Models.Post> GetAll()
        {
            try
            {
                var path = HttpContext.Current.Server.MapPath("~/App_Data/blog-Posts.json");
                if (!File.Exists(path))
                    return null;
                
               string data = File.ReadAllText(path);
                if (string.IsNullOrEmpty(data))
                    return null;

                var posts = CommonConverter.DeserializeObject<JObject>(data);
                if (posts == null)
                    return null;
                var postsList = CommonConverter.DeserializeObject<List<Models.Post>>(posts["blogPosts"].ToString());
                return postsList;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public bool SaveAll(List<Models.Post> posts)
        {
            try
            {
                var path = HttpContext.Current.Server.MapPath("~/App_Data/blog-Posts.json");
                if (!File.Exists(path))
                    File.Create(path);
                File.WriteAllText(path, CommonConverter.SerializeObject(new { blogPosts = posts.ToArray() }));
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}