using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MrFixIt.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860
namespace MrFixIt.Controllers
{
    public class WorkersController : Controller
    {
        //This instantiates a private instance of our MrfixitContext class named db
        private MrFixItContext db = new MrFixItContext();
        // GET: /<controller>/
        public IActionResult Index()
        {
            //this is varification for worker, it checks that user identity and a user name match
            var thisWorker = db.Workers.Include(i =>i.Jobs).FirstOrDefault(i => i.UserName == User.Identity.Name);
            if (thisWorker != null)
            {
                return View(thisWorker);
            }
            //if not redirects to create 
            else
            {
                return RedirectToAction("Create");
            }
        }

        //this action will is redirect  to create view worker
        public IActionResult Create()
        {
            return View();
        }

        //this post will add worker to DB and link to the user who is logged in (Authenticated)
        [HttpPost]
        public IActionResult Create(Worker worker)
        {
            worker.UserName = User.Identity.Name;
            db.Workers.Add(worker); 
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
