using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace NetC.JuniorDeveloperExam.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Assets/Scripts/jquery-3.3.1.min.js")
                .Include("~/Assets/Scripts/jquery.unobtrusive-ajax.js")
                .Include("~/Assets/Scripts/jquery.validate.min.js")
                .Include("~/Assets/Scripts/jquery.validate.unobtrusive.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                .Include("~/Assets/Scripts/unobtrusive-bootstrap.js")
                .Include("~/Assets/Scripts/bootstrap.bundle.min.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/blog")
                .Include("~/Assets/Scripts/BlogManager.js"));

            bundles.Add(new StyleBundle("~/content/posts")
                .Include("~/Assets/Styles/Posts.css"));
            bundles.Add(new StyleBundle("~/content/blog")
                .Include("~/Assets/Styles/blog.css")); 
            bundles.Add(new StyleBundle("~/content/bootstrap")
                .Include("~/Assets/Styles/bootstrap.min.css"));
             bundles.Add(new StyleBundle("~/content/custom")
                .Include("~/Assets/Styles/custom.css"));

        }
    }
}