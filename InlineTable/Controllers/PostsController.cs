using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InlineTable.Entities;
using InlineTable.Models;

namespace InlineTable.Controllers
{
    public class PostsController : Controller
    {
        private BookEntities1 db = new BookEntities1();

        // GET: Posts
        public ActionResult Index()
        {
            List<Post> posts = db.Post.ToList();
            return View(posts);
        }
        public ActionResult TryInline()
        {
            List<Post> posts = db.Post.ToList().Select( x => new Post() { 
                Id = x.Id,
                Auher_Name = x.Auher_Name, 
                PostTitle = x.PostTitle,
                PostDesc = x.PostDesc,
                PublishDate = x.PublishDate
            }).ToList();
            //posts.Insert(0, new Post());
            return View(posts);
        }
        [HttpPost]
        public ActionResult UpdatePost(Post post)
        {
            using (BookEntities1 entities = new BookEntities1())
            {
                var updatedpost = (from c in entities.Post
                                   where c.Id == post.Id
                                   select c).FirstOrDefault();
                updatedpost.PostTitle = post.PostTitle;
                updatedpost.PostDesc = post.PostDesc;
                updatedpost.Auher_Name = post.Auher_Name;
                entities.SaveChanges();
            }

            return new EmptyResult();
        }




        [HttpPost]
        public JsonResult InsertPost(Post post)
        {
            using (BookEntities1 entities = new BookEntities1())
            {
                entities.Post.Add(post);
                entities.SaveChanges();
            }

            return Json(post);
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Post.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            ViewBag.Listed = db.Auther.ToList();
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(post.PublishDate))
                {
                    post.PublishDate = DateTime.Now.ToShortDateString();
                }
                db.Post.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(post);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Post.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PostTitle,PostDesc,PublishDate,Auher_Name")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Post.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Post.Find(id);
            db.Post.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
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
