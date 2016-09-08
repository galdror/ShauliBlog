using ShauliBlog.DAL;
using ShauliBlog.Models.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShauliBlog.Controllers
{
    public class QueriesController : Controller
    {
        private ShauliBlogContext db = new ShauliBlogContext();

        // GET: Queries
        public ActionResult Index()
        {
            return View();
        }

        // Just To Display The User
        public ActionResult CommentAuthorDisplay()
        {
            return View(new List<CommentPostObject>());
        }

        [HttpPost]
        public ActionResult CommentAuthorDisplay(string searchAuthor)
        {
            var objects = from comment in db.Comments
                          join pst in db.Posts on comment.PostID equals pst.ID
                          where comment.Author.Contains(searchAuthor)
                          select new CommentPostObject { CommentTitle = comment.Title, PostTitle = pst.Title };

            return View(objects);
        }

        public ActionResult Brief()
        {
            var objects = from post in db.Posts
                          join com in db.Comments on post.ID equals com.PostID into commGroup
                          select new PostCommentBriefObject {  PostTitle = post.Title, Comments = commGroup };

            return View(objects);
        }

        public ActionResult PostAuthorAndPosts()
        {
            var results = from p in db.Posts
                          group p.Title by p.Author into g
                          select new PostAuthorPostObject{ Author = g.Key, PostTitles = g.ToList() };

            return View(results);
        }
    }
}