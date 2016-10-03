using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using AutomatedTellerMachine.Models;
using Microsoft.AspNet.Identity.Owin;

namespace AutomatedTellerMachine.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET /home/index        
        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var checkingAccountId = db.CheckingAccounts.Where(c => c.ApplicationUserId == userId).First().Id;
            ViewBag.CheckingAccountId = checkingAccountId;
            
            var manager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(userId);
            ViewBag.Pin = user.Pin;
            return View();
        }

        // GET /home/about        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
                
        public ActionResult Contact()
        {
            ViewBag.TheMessage = "Having trouble? Send us a message.";            

            return View();
        }

        [HttpPost]
        public ActionResult Contact(string message)
        {
            // TODO: send the message to HQ
            ViewBag.TheMessage = "Thanks, we got your message!";

            return PartialView("_ContactThanks");
        }

        public ActionResult Foo()
        {            
            return View("About");
        }

        public ActionResult Serial(string letterCase)
        {
            var serial = "ASP.NET MVC5 ONLINE ATM";
            if (letterCase == "lower")
            {
                return Content(serial.ToLower());
            }
            return RedirectToAction("Index");
        }
    }
}