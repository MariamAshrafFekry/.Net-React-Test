using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NetC.JuniorDeveloperExam.Web.Models;
using NetC.JuniorDeveloperExam.Web.Repository.IServices;
using NetC.JuniorDeveloperExam.Web.Repository.Services;
using Newtonsoft.Json;

namespace NetC.JuniorDeveloperExam.Web.Controllers
{
    public class PostsController : Controller
    {
        private IPosts postService;
        public PostsController()
        {
            postService = new PostsService();
        }
        public PostsController(IPosts postService)
        {
            this.postService = postService;
        }
        [HttpGet]
        public ActionResult Index()
        {
            object json = null;
            TempData.TryGetValue("blogPosts",out json);
            var posts = new List<Post>(); 
            if (json == null || string.IsNullOrEmpty(json.ToString()))
                posts = postService.GetAll();
            else
                posts = CommonConverter.DeserializeObject<List<Post>>(json.ToString());
            TempData["blogPosts"] = (posts == null ? "" : CommonConverter.SerializeObject(posts));

            return View(posts);
        }
    }
}
