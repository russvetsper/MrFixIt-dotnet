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
    public class JobsController : Controller
    {
        private MrFixItContext db = new MrFixItContext();

        // GET: /<controller>/
        public IActionResult Index()
        {
            //if the identity is authenticated it returns list of jobs where workers can claim jobs
            if (User.Identity.IsAuthenticated)
            {

            return View(db.Jobs.Include(i => i.Worker).ToList());
            }else
            {
                //else will redirect to curent jobs in public 
                return RedirectToAction("Public");
            }
        }
        //this will return a list of jobs and there is no ability to claim jobs
        //this is also where you get redirected to if you try to go to index as an unauthenticated user   
        public IActionResult Public()
        {
            return View(db.Jobs.Include(i => i.Worker).ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        //if authenticated  and on create page will allow to add new job and  redirect to index
        [HttpPost]
        public IActionResult Create(Job job)
        {
            db.Jobs.Add(job);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //when in index (job/index) and click "caim this job" button you are direted to a "confirmation" (jobs/claim) page where you actually have the abuility to link a worker to a job in the database
        public IActionResult Claim(int id)
        {
            var thisItem = db.Jobs.FirstOrDefault(items => items.JobId == id);
            return View(thisItem);
        }

        //when on the "confirmation" (jobs/claim) page you can click "Claim This Job" and that will redirect you to the index after updating the WorkerId in the Jobs-table with the id of the user(worker) who clicked the button
        [HttpPost]
        public IActionResult Claim(Job job)
        {
            job.Worker = db.Workers.FirstOrDefault(i => i.UserName == User.Identity.Name);
            db.Entry(job).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
