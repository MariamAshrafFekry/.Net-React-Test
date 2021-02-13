using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using NetC.JuniorDeveloperExam.Web.Models;

namespace NetC.JuniorDeveloperExam.Web.ViewModels
{
    public class BlogViewModel
    {
        public Post Post { get; set; }
        public CommentViewModel Comment { get; set; }
        public ReplyViewModel Reply { get; set; }
    }
    public class CommentViewModel
    {
        public int BlogID { get; set; }

        [Required(AllowEmptyStrings = false , ErrorMessage ="Name is required")]
        [Display(Name ="Name" )]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Address is required")]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Please enter valid email address")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Message is required")]
        [Display(Name = "Message")]
        public string Message { get; set; }
        public string Date { get; set; }
    }
    public class ReplyViewModel:CommentViewModel
    {
        public int CommentID { get; set; }
    }
}