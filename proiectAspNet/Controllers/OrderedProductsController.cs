using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using proiectAspNet.Models;

namespace proiectAspNet.Controllers
{
    public class OrderedProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OrderedProducts
        [CustomizeAuthorize(Roles = "Admin, Employee")]

        public ActionResult Index()
        {
            var orderedProducts = db.OrderedProducts.Include(o => o.Order).Include(o => o.Product);
            return View(orderedProducts.ToList());
        }

        // GET: OrderedProducts/Details/5
        [CustomizeAuthorize(Roles = "Admin, Employee")]

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderedProduct orderedProduct = db.OrderedProducts.Find(id);
            if (orderedProduct == null)
            {
                return HttpNotFound();
            }
            return View(orderedProduct);
        }

        // GET: OrderedProducts/Create

        [CustomizeAuthorize(Roles = "Employee")]

        public ActionResult Create()
        {
            ViewBag.OrderID = new SelectList(db.Orders, "ID", "ID");
            ViewBag.ProductID = new SelectList(db.Products, "ID", "Name");
            return View();
        }

        // POST: OrderedProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomizeAuthorize(Roles = "Employee")]

        public ActionResult Create([Bind(Include = "ID,OrderID,ProductID,Quantity,TotalPrice")] OrderedProduct orderedProduct)
        {
            if (ModelState.IsValid)
            {
                Product p = db.Products.Find(orderedProduct.ProductID);
                orderedProduct.TotalPrice = p.Price * orderedProduct.Quantity;
                db.OrderedProducts.Add(orderedProduct);
                
                p.Stock = p.Stock - orderedProduct.Quantity;

                Order o = db.Orders.Find(orderedProduct.OrderID);
                o.TotalPrice = o.TotalPrice + orderedProduct.TotalPrice;
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           

            ViewBag.OrderID = new SelectList(db.Orders, "ID", "ID", orderedProduct.OrderID);//din Products, ia ID-ul si afiseaza id-ul
            ViewBag.ProductID = new SelectList(db.Products, "ID", "Name", orderedProduct.ProductID);//din Products, ia ID-urile dar afiseaza numele
            return View(orderedProduct);
        }

       
        // GET: OrderedProducts/Edit/5
        [CustomizeAuthorize(Roles = "Employee")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderedProduct orderedProduct = db.OrderedProducts.Find(id);
            if (orderedProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderID = new SelectList(db.Orders, "ID", "ID", orderedProduct.OrderID);
            ViewBag.ProductID = new SelectList(db.Products, "ID", "Name", orderedProduct.ProductID);
            return View(orderedProduct);
        }

        // POST: OrderedProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomizeAuthorize(Roles = "Employee")]

        public ActionResult Edit([Bind(Include = "ID,OrderID,ProductID,Quantity,TotalPrice")] OrderedProduct orderedProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderedProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrderID = new SelectList(db.Orders, "ID", "ID", orderedProduct.OrderID);
            ViewBag.ProductID = new SelectList(db.Products, "ID", "Name", orderedProduct.ProductID);
            return View(orderedProduct);
        }

        // GET: OrderedProducts/Delete/5
        [CustomizeAuthorize(Roles = "Employee")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderedProduct orderedProduct = db.OrderedProducts.Find(id);
            if (orderedProduct == null)
            {
                return HttpNotFound();
            }
            return View(orderedProduct);
        }

        // POST: OrderedProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [CustomizeAuthorize(Roles = "Employee")]

        public ActionResult DeleteConfirmed(int id)
        {
            OrderedProduct orderedProduct = db.OrderedProducts.Find(id);
            db.OrderedProducts.Remove(orderedProduct);
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
