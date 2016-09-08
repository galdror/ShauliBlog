using ShauliBlog.DAL;
using ShauliBlog.Models;
using ShauliBlog.Models.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ShauliBlog.Controllers
{
    public class BlogController : Controller
    {
        private ShauliBlogContext db = new ShauliBlogContext();

        //
        // GET: /Blog/
        public ActionResult Index()
        {
            return View(db.Posts.ToList());
            //return View();
        }

        [HttpPost]
        public ActionResult Index(int postID, string title, string author, string website, string comment)
        {
            Comment commentObj = new Comment() { PostID = postID, Title = title, Author = author, Website = website, Content = comment };
            db.Comments.Add(commentObj);
            db.SaveChanges();

            return View(db.Posts.ToList());
        }

        public ActionResult Manage()
        {
            return View(db.Posts.ToList());
        }

        [HttpPost]
        public ActionResult Manage(string searchTitle, string searchAuthor, bool? hasImage, bool? hasVideo)
        {
            var posts = from p in db.Posts select p;
            if (!String.IsNullOrEmpty(searchTitle))
            {
                posts = posts.Where(s => s.Title.Contains(searchTitle));
            }
            if (!String.IsNullOrEmpty(searchAuthor))
            {
                posts = posts.Where(s => s.Author.Contains(searchAuthor));
            }

            posts = posts.Where(s => s.Image.Equals("None") == !hasImage && s.Video.Equals("None") == !hasVideo);
            return View(posts);
        }

        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: /FanClub/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost([Bind(Include = "ID,Title,Author,Website,Content,Image,Video")] Post post)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    post.PostDate = DateTime.Now;               // Setting That The Post Was Updated
                    db.Entry(post).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Manage");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(post);
        }

        // GET: /FanClub/Create
        public ActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost([Bind(Include = "ID,Title,Author,Website,Content,Image,Video")] Post post, bool checkImg = false, bool checkVid = false)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (checkImg == false)
                    {
                        post.Image = "None";
                    }
                    if (checkVid == false)
                    {
                        post.Video = "None";
                    }

                    post.PostDate = DateTime.Now;

                    db.Posts.Add(post);
                    db.SaveChanges();
                    return RedirectToAction("Manage");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(post);
        }

        public ActionResult PostDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }

            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Post fan = db.Posts.Find(id);
                db.Posts.Remove(fan);
                db.SaveChanges();
            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Manage");
        }

        public ActionResult ManageComments(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post.Comments);
        }

        [HttpPost]
        public ActionResult ManageComments(int? id, string searchTitle, string searchAuthor, string searchWebsite)
        {
            var comments = from c in db.Comments
                        where c.PostID == id
                        select c;

            if (!String.IsNullOrEmpty(searchTitle))
            {
                comments = comments.Where(s => s.Title.Contains(searchTitle));
            }
            if (!String.IsNullOrEmpty(searchAuthor))
            {
                comments = comments.Where(s => s.Author.Contains(searchAuthor));
            }
            if (!String.IsNullOrEmpty(searchWebsite))
            {
                comments = comments.Where(s => s.Website.Contains(searchWebsite));
            }
            return View(comments);
        }

        public ActionResult DeleteComment(int? id)
        {
            try
            {
                Comment fan = db.Comments.Find(id);
                db.Comments.Remove(fan);
                db.SaveChanges();
            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to remove Comment. Try again, and if the problem persists see your system administrator.");
            }
            return RedirectToAction("Manage");
        }

        public ActionResult EditComment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: /FanClub/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditComment([Bind(Include = "ID,PostID, Title,Author,Website,Content")] Comment comment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(comment).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Manage");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(comment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}