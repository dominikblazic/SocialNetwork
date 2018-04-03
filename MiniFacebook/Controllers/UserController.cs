using Microsoft.AspNet.Identity;
using MiniFacebook.DataAccess.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniFacebook.Controllers
{
    public class UserController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        
        // GET: User
        public ActionResult Index(string username)
        {
            var user = context.Users.Where(p => p.Nickname == username.ToLower()).FirstOrDefault();

            if (user == null)
            {
                return View("Error");
            }
            else
            {
                return View(user);
            }
        }
    }
}