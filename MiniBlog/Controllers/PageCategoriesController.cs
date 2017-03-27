using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MiniBlog.DAL;
using MiniBlog.Models;

namespace MiniBlog.Controllers
{
    public class PageCategoriesController : Controller
    {
        private BlogContext db = new BlogContext();

        // GET: PageCategories
        public ActionResult Index()
        {
            var pageCategories = db.PageCategories.Include(p => p.Category).Include(p => p.Page);
            return View(pageCategories.ToList());
        }

        // GET: PageCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageCategory pageCategory = db.PageCategories.Find(id);
            if (pageCategory == null)
            {
                return HttpNotFound();
            }
            return View(pageCategory);
        }

        // GET: PageCategories/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name");
            ViewBag.PageID = new SelectList(db.Pages, "ID", "Title");
            return View();
        }

        // POST: PageCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PageID,CategoryID")] PageCategory pageCategory)
        {
            if (ModelState.IsValid)
            {
                db.PageCategories.Add(pageCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", pageCategory.CategoryID);
            ViewBag.PageID = new SelectList(db.Pages, "ID", "Title", pageCategory.PageID);
            return View(pageCategory);
        }

        // GET: PageCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageCategory pageCategory = db.PageCategories.Find(id);
            if (pageCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", pageCategory.CategoryID);
            ViewBag.PageID = new SelectList(db.Pages, "ID", "Title", pageCategory.PageID);
            return View(pageCategory);
        }

        // POST: PageCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PageID,CategoryID")] PageCategory pageCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pageCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", pageCategory.CategoryID);
            ViewBag.PageID = new SelectList(db.Pages, "ID", "Title", pageCategory.PageID);
            return View(pageCategory);
        }

        // GET: PageCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageCategory pageCategory = db.PageCategories.Find(id);
            if (pageCategory == null)
            {
                return HttpNotFound();
            }
            return View(pageCategory);
        }

        // POST: PageCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PageCategory pageCategory = db.PageCategories.Find(id);
            db.PageCategories.Remove(pageCategory);
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
