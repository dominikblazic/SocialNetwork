using MiniFacebook.DataAccess.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniFacebook.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        readonly ApplicationDbContext context = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Search(string searchValue)
        {
            var users = from u in context.Users
                       select u;

            if (!string.IsNullOrEmpty(searchValue))
            {
                users = users.Where(u => u.FirstName.Contains(searchValue));
                if (!users.Any())
                {
                    return View("NoUsersFound");
                }
                else
                {
                    return View(users);
                }
            }
            else
            {
                return View("NoUsersFound");
            }

            
        }
    }
}