using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using proiectAspNet.Models;
using proiectAspNet.Services;

namespace proiectAspNet.Controllers
{
    public class OrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //toate comenzile cu o suma mai mare decat o suma data de admin
        [CustomizeAuthorize(Roles="Admin")]
        public ActionResult EditExport(float sum, string tip)
        {
            ExporterFactory e = new ExporterFactory();
            IExporter export = e.GetExport(tip);
            List<Order> orders = new List<Order>();
            
            foreach(Order o in db.Orders)
            {
                if (o.TotalPrice > sum)
                {
                    orders.Add(o);
                }
            }

            MemoryStream memstream = new MemoryStream();
            TextWriter tw = new StreamWriter(memstream);
            tw.Flush();
            tw.Close();
            return File(export.export2(orders.ToList()), "text/plain", "file.txt");

        }

        // GET: Orders
        [CustomizeAuthorize(Roles = "Admin, Employee")]

        public ActionResult Index()
        {
            return View(db.Orders.ToList());
        }

        // GET: Orders/Details/5
        [CustomizeAuthorize(Roles = "Admin, Employee")]

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create

        [CustomizeAuthorize(Roles = "Employee")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomizeAuthorize(Roles = "Employee")]
        public ActionResult Create([Bind(Include = "ID,OrderDate,TotalPrice")] Order order)
        {
            if (ModelState.IsValid)
            {
                
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(order);
        }

        // GET: Orders/Edit/5
        [CustomizeAuthorize(Roles = "Employee")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomizeAuthorize(Roles = "Employee")]
        public ActionResult Edit([Bind(Include = "ID,OrderDate,TotalPrice")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET: Orders/Delete/5
        [CustomizeAuthorize(Roles = "Employee")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [CustomizeAuthorize(Roles = "Employee")]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
