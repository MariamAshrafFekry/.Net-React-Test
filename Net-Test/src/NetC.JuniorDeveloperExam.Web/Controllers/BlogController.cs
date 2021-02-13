using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NetC.JuniorDeveloperExam.Web.Models;
using NetC.JuniorDeveloperExam.Web.Repository.IServices;
using NetC.JuniorDeveloperExam.Web.Repository.Services;
using NetC.JuniorDeveloperExam.Web.ViewModels;
using Newtonsoft.Json;

namespace NetC.JuniorDeveloperExam.Web.Controllers
{
    public class BlogController : Controller
    {
        private IPosts postsService;
        public BlogController()
        {
            postsService = new PostsService();
        }
        [HttpGet]
        [Route("Blog/{id}")]
        [Route("Blog/Index/{id}")]
        public ActionResult Index(int id)
        {
            var post = GetPostById(id);
            var blog = new BlogViewModel()
            {
                Post = post,
                Comment = new CommentViewModel()
                {
                    BlogID = post.ID
                },
                Reply = new ReplyViewModel()
                {
                    BlogID = post.ID
                },
            };
            return View(blog);
        }
        [HttpPost]
        [Route("blog/AddComment")]
        public ActionResult AddComment(BlogViewModel model)
        {
            bool isAdded = false;
            string error = "";
            try
            {
                if (ModelState.IsValid)
                {
                    var posts = GetPostsFromSession();
                    var comment = new Comment()
                    {
                        Name = model.Comment.Name,
                        Email = model.Comment.Email,
                        Date = DateTime.UtcNow,
                        Message = model.Comment.Message
                    };
                    model.Comment.Date = DateTime.UtcNow.ToString("MMMM dd, yyyy HH:mm");
                    var comments = posts.Where(p => p.ID == model.Comment.BlogID).FirstOrDefault().Comments;
                    if (comments == null)
                        comments = new List<Comment>();
                    comments.Add(comment);
                    posts.Where(p => p.ID == model.Comment.BlogID).FirstOrDefault().Comments = comments;
                    isAdded = postsService.SaveAll(posts);
                    if (isAdded)
                    {
                        TempData["blogPosts"] = JsonConvert.SerializeObject(posts);
                    }
                    
                }
            }
            catch(Exception ex)
            {
                error = ex.Message.ToString();
            }
            return Json(new { IsAdded = isAdded, Comment = model.Comment, Exception = error }, JsonRequestBehavior.AllowGet);
        } 
        
        [HttpPost]
        [Route("blog/AddReply")]
        public ActionResult AddReply(BlogViewModel model)
        {
            bool isAdded = false;
            string error = "";
            try
            {
                if (ModelState.IsValid)
                {
                    var posts = GetPostsFromSession();
                    var reply = new Reply()
                    {
                        Name = model.Reply.Name,
                        Email = model.Reply.Email,
                        Date = DateTime.UtcNow,
                        Message = model.Reply.Message
                    };
                    model.Reply.Date = DateTime.UtcNow.ToString("MMMM dd, yyyy HH:mm");
                    var comments = posts.Where(p => p.ID == model.Reply.BlogID).FirstOrDefault().Comments;
                    if (comments == null)
                        comments = new List<Comment>();
                    List<Reply> replies = null;
                    if (comments.Count() >= model.Reply.CommentID)
                    {
                        replies = comments.ElementAtOrDefault(model.Reply.CommentID).Replies;
                    }
                    if (replies == null)
                        replies = new List<Reply>();
                    replies.Add(reply);
                    comments.ElementAtOrDefault(model.Reply.CommentID).Replies = replies;
                    isAdded = postsService.SaveAll(posts);
                    if (isAdded)
                    {
                        TempData["blogPosts"] = JsonConvert.SerializeObject(posts);
                    }
                    
                }
            }
            catch(Exception ex)
            {
                error = ex.Message.ToString();
            }
            return Json(new { IsAdded = isAdded, Reply = model.Reply, Exception = error }, JsonRequestBehavior.AllowGet);
        }
        private List<Post> GetPostsFromSession()
        {
            try
            {
                List<Post> posts = new List<Post>();
                object json;
                TempData.TryGetValue("blogPosts", out json);
                if (json == null || string.IsNullOrEmpty(json.ToString()))
                {
                    posts = postsService.GetAll();
                    TempData["blogPosts"] = (posts == null ? "" : CommonConverter.SerializeObject(posts));
                }
                else
                    posts = CommonConverter.DeserializeObject<List<Post>>(json.ToString());
                if (posts == null)
                    posts = new List<Post>();
                return posts;
            }
            catch(Exception ex)
            {
                return new List<Post>();
            }
        }
        private Post GetPostById(int id)
        {
            try
            {
                List<Post> posts = GetPostsFromSession();
                var post = new Post();
                if (posts != null)
                {
                    post = posts.Where(p => p.ID == id).FirstOrDefault();
                }
                return post;
            }
            catch (Exception ex)
            {
                return new Post();
            }
        }
    }
}