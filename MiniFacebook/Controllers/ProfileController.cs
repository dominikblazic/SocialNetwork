using Microsoft.AspNet.Identity;
using MiniFacebook.DataAccess.Infrastructure;
using MiniFacebook.Domena.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;


namespace MiniFacebook.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadUserPhoto()
        {
            if (ModelState.IsValid)
            {
                //to convert the uploaded photo to byte array before saving to db
                byte[] imageData = null;
                if(Request.Files.Count > 0)
                {
                    HttpPostedFileBase poImgFile = Request.Files["UserPhoto"];

                    using (var binary = new BinaryReader(poImgFile.InputStream))
                    {
                        imageData = binary.ReadBytes(poImgFile.ContentLength);
                    }
                }

                ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

                //Passing the byte array to user context to store in db
                user.UserPhoto = imageData;


            }

            return View("Index");
        }

        //public FileContentResult UserPhoto()
        //{
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        string userId = User.Identity.GetUserId();
        //    }
        //}
    }
}