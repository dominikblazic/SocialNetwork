﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MiniFacebook.DataAccess.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiniFacebook.Domena.Helpers;
using MiniFacebook.Models;

namespace MiniFacebook.Controllers
{
    public class UserController : Controller
    {
        readonly ApplicationDbContext context = new ApplicationDbContext();
        
        // GET: User
        public ActionResult Index(string username)
        {
            var user = context.Users.Where(p => p.Nickname == username).FirstOrDefault();

            if (user == null)
            {
                return View("Error");
            }
            else
            {
                var vm = new UserViewModel()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Nickname = user.Nickname,
                    UserPhoto = user.UserPhoto,
                    DrzavaNaziv = user.Drzava.Naziv
                };
                return View(vm);
            }
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
                if (Request.Files.Count == 1)
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

            return RedirectToAction("Index", "Home");
        }

        //Getting userphoto from db
        public FileContentResult UserPhoto(string username)
        {

            //string userId = User.Identity.GetUserId();
            //string nickname = User.Identity.GetNickname();

            var context = HttpContext.GetOwinContext().Get<ApplicationDbContext>();
            var user = context.Users.Where(x => x.Nickname == username).FirstOrDefault();
            if (user.UserPhoto == null)
            {
                return null;
            }
            else
            {
                return new FileContentResult(user.UserPhoto, "image/jpeg");
            }
        }

        #endregion
    }
}