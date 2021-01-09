using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloggingReport.Models;

namespace BloggingReport.Controllers
{
    public class HomeController : Controller
    {
        BloggingReportEntities brdb = new BloggingReportEntities();
        public ActionResult Index()
        {
            var BloggingReportData = (from posts in brdb.posts
                     join users in brdb.users on posts.user_id equals users.id
                     join comments in brdb.comments on posts.id equals comments.post_id
                     
                     select new
                     {
                         Title = posts.title,
                         CreatedBy = users.name,
                         CreatedOn = posts.created_on,
                         CommentsCount = brdb.comments.Where(c => c.post_id == posts.id).ToList().Count(),
                         Comments = brdb.comments.Where(c => c.post_id == posts.id).ToList(),
                         likeCount = comments.like_count,
                         dislikeCount = comments.dislike_count
                    });

            List<ReportModel> data = BloggingReportData.ToList().Select(p => new ReportModel
            {
               Title = p.Title,
               CreatedBy = p.CreatedBy,
               CreatedOn = p.CreatedOn,
               CommentsCount = p.CommentsCount,
               Comments = p.Comments,
               LikeCount = p.likeCount,
               DislikeCount = p.dislikeCount

            }).ToList();

            ViewBag.Report = data;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}