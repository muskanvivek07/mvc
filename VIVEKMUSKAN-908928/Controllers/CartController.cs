using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TruYumMVC.Models;

namespace TruYumMVC.Controllers
{
    public class CartController : Controller
    {
        private TruYumContext db = new TruYumContext();

        // GET: Cart
        public ActionResult Index()
        {
            var carts = db.Carts.Include(c => c.MenuItem);
            return View(carts.ToList());
        }
        public ActionResult AddToCart(int menuItemId)
        {
            Cart c = new Cart
            {
                MenuItemId = menuItemId
            };
            db.Carts.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }


        public ActionResult Create()
        {
            ViewBag.MenuItemId = new SelectList(db.MenuItems, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MenuItemId")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                db.Carts.Add(cart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MenuItemId = new SelectList(db.MenuItems, "Id", "Name", cart.MenuItemId);
            return View(cart);
        }

 
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            ViewBag.MenuItemId = new SelectList(db.MenuItems, "Id", "Name", cart.MenuItemId);
            return View(cart);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MenuItemId")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MenuItemId = new SelectList(db.MenuItems, "Id", "Name", cart.MenuItemId);
            return View(cart);
        }

 
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cart cart = db.Carts.Find(id);
            db.Carts.Remove(cart);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}