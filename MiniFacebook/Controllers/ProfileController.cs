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
using Microsoft.AspNet.Identity.EntityFramework;

namespace MiniFacebook.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }


        #region UserPhoto
        [HttpPost]
        public ActionResult UploadUserPhoto()
        {
            //var context = new ApplicationDbContext();

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

                //Getting the current user and manager for the current user
                var manager = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var user = manager.FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

                //Updating user
                user.UserPhoto = imageData;

                //Persisting the user changes in the db
                manager.Update(user);
                System.Web.HttpContext.Current.GetOwinContext().Get<ApplicationDbContext>().SaveChanges();


            }

            return RedirectToAction("Index");
        }

        //Getting userphoto from db
        public FileContentResult UserPhoto()
        {
           
            string userId = User.Identity.GetUserId();

            var context = HttpContext.GetOwinContext().Get<ApplicationDbContext>();
            var user = context.Users.Where(x => x.Id == userId).FirstOrDefault();

            return new FileContentResult(user.UserPhoto, "image/jpeg");
            
        }

        #endregion
    }
}