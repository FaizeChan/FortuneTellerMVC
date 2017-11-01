using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FortuneTellerMVC.Models;

namespace FortuneTellerMVC.Controllers
{
    public class CustomersController : Controller
    {
        private FortuneTellerEntities db = new FortuneTellerEntities();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);

            //Age

            if (customer.Age % 2 == 0)
            {
                ViewBag.Even = "You will retire in 20 years pretty decent.";
            }
            else
            {
                ViewBag.Odd = "You will retire in 15 years Nice!";
            }

            //Birth Month

            if (customer.BirthMonth == 1)
            {
                ViewBag.MonthOne = "Ooooo, you will also have a staggering amount of $10,000,000.00 in the bank";
            }
            else if (customer.BirthMonth == 2)
            {
                ViewBag.MonthTwo = "Ooooo, you will also have a staggering amount of $10,000,000.00 in the bank,";
            }
            else if (customer.BirthMonth == 3)
            {
                ViewBag.MonthThree = "Ooooo, you will also have a staggering amount of $10,000,000.00 in the bank,";
            }
            else if (customer.BirthMonth == 4)
            {
                ViewBag.MonthFour = "Ooooo, you will also have a staggering amount of $10,000,000.00 in the bank,";
            }
            else if (customer.BirthMonth == 5)
            {
                ViewBag.MonthFive = "Pretty nice, you will also have a wopping amount of $500,000.00 in the bank,";
            }
            else if (customer.BirthMonth == 6)
            {
                ViewBag.MonthSix = "Pretty nice, you will also have a wopping amount of $500,000.00 in the bank,";
            }
            else if (customer.BirthMonth == 7)
            {
                ViewBag.MonthSeven = "Pretty nice, you will also have a wopping amount of $500,000.00 in the bank,";
            }
            else if (customer.BirthMonth == 8)
            {
                ViewBag.MonthEight = "Pretty nice, you will also have a wopping amount of $500,000.00 in the bank,";
            }
            else if (customer.BirthMonth == 9)
            {
                ViewBag.MonthNine = "You will also have a deceant amount of $20,000.00 in the bank,";
            }
            else if (customer.BirthMonth == 10)
            {
                ViewBag.MonthTen = "You will also have a deceant amount of $20,000.00 in the bank,";
            }
            else if (customer.BirthMonth == 11)
            {
                ViewBag.MonthEleven = "You will also have a deceant amount of $20,000.00 in the bank,";
            }
            else if (customer.BirthMonth == 12)
            {
                ViewBag.MonthTwelve = "You will also have a deceant amount of $20,000.00 in the bank,";
            }
            else
            {
                ViewBag.MonthNo = "tsk tsk... but sadly you will have $0.00 in the bank,";
            }

            //Colors

            if (customer.FavoriteColor == "Red")
            {
                ViewBag.ColorRed = "Oh yeah! You'll also be riding in a luxury Escalade. Living the fancy life I see.";
            }
            else if (customer.FavoriteColor == "Orange")
            {
                ViewBag.ColorOrange = "Also you'll be riding in a soccor mom van. Hey, I don't come up with the fortunes. I just tell them to you.";
            }
            else if (customer.FavoriteColor == "Yellow")
            {
                ViewBag.ColorYellow = "Wow... \n \nThis is a big one. You'll be cruising in an actual cruise ship, and it's all yours. Congrats!!";
            }
            else if (customer.FavoriteColor == "Green")
            {
                ViewBag.ColorGreen = "Hold up... \n \nOMG... \n \nYou will own your own airline!!! It will be called Takes Flight! Congrats!!";
            }
            else if (customer.FavoriteColor == "Blue")
            {
                ViewBag.ColorBlue = "You'll also be riding a motorcycle, pretty cool";
            }
            else if (customer.FavoriteColor == "Indigo")
            {
                ViewBag.ColorIndigo = "You'll also have a Hummer Limo. Aye I see you flexing, pretty slick.";
            }
            else if (customer.FavoriteColor == "Violet")
            {
                ViewBag.ColorViolet = "You'll also be riding in a Audi R8. You better drive safe!";
            }
            else
            {
                ViewBag.NoColor = "hmm... i don't see any types of transportation in your future. Its ok though. Your legs will work just fine!";
            }

            //Siblings

            if (customer.NumberOfSiblings == 0)
            {
                ViewBag.One = "a vacation home in Hawaii, you're so lucky";
            }
            else if (customer.NumberOfSiblings == 1)
            {
                ViewBag.Two = "a vacation home in California pretty cool";
            }
            else if (customer.NumberOfSiblings == 2)
            {
                ViewBag.Three = "a vacation home in Orlando Florida, wait a minute... Isn't that Disney World? Oh wow you're lucky";
            }
            else if (customer.NumberOfSiblings == 3)
            {
                ViewBag.Four = "a vacation home in Tokeyo! I want to go! Take me with you!!";
            }
            else
            {
                ViewBag.Whatever = "uhmm yeah, sorry to say but your vacation home is going to be in your mothers basement" + "BAD vacation home indeed";
            }

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,FirstName,LastName,Age,BirthMonth,FavoriteColor,NumberOfSiblings")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,FirstName,LastName,Age,BirthMonth,FavoriteColor,NumberOfSiblings")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
