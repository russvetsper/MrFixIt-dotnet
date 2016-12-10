using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MrFixIt.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

    //cotroller folder contains actions.

namespace MrFixIt.Controllers
{
    public class HomeController : Controller
    {
        // defines conection to this page
        private MrFixItContext db = new MrFixItContext();

        // GET: /<controller>/
        //IActionResult- takes many forms, including a view

        public IActionResult Index()
        {
            // checks for authentication of worker, if authenticated routs to loggedin views page
            if (User.Identity.IsAuthenticated)
            {
                var thisWorker = db.Workers.FirstOrDefault(item => item.UserName == User.Identity.Name);
                return View(thisWorker);

                // else statement, if not authenticated will return to same view page
            } else
            {
                return View();
            }
        }
    }
}
