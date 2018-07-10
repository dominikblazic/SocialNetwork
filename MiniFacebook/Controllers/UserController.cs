using Microsoft.AspNet.Identity;
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
using MiniFacebook.Domena.Models;

namespace MiniFacebook.Controllers
{
    public class UserController : Controller
    {
        readonly ApplicationDbContext context = new ApplicationDbContext();
        
        //TODO: route config
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
                    DrzavaNaziv = user.Drzava.Naziv,
                    Posts = user.Posts.OrderByDescending(dt => dt.PostTime)
                };
                return View(vm);
            }
        }

        #region Posts

        [HttpPost]
        public ActionResult CreatePost(PostViewModel model)
        {
            var manager = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            

            if (ModelState.IsValid)
            {
                user.Posts.Add(new Post
                {
                    Text = model.Text,
                    PostTime = DateTime.Now
                });

                manager.Update(user);
                System.Web.HttpContext.Current.GetOwinContext().Get<ApplicationDbContext>().SaveChanges();

            }

            return RedirectToAction("Index", "User", new { username = user.Nickname });
        }

        [HttpPost]
        public ActionResult DeletePost(int id)
        {
            var manager = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            //var post = context.Posts.Where(d => d.Id == user.Posts.Select(j => j.Id).Single() && d.Text == user.Posts.Select(j => j.Text).Single()).Single();

            var post = context.Posts.Find(id);

            context.Posts.Remove(post);
            //System.Web.HttpContext.Current.GetOwinContext().Get<ApplicationDbContext>().SaveChanges();
            context.SaveChanges();
            return RedirectToAction("Index", "User", new { username = user.Nickname });
        }

        [HttpPost]
        public ActionResult LikePost(int id)
        {
            var manager = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            var post = context.Posts.Find(id);

            Like like = new Like();
            like.ApplicationUserId = user.Id;
            like.PostId = post.Id;
            like.LikeTime = DateTime.Now;
            
            post.NrOfLikes++;

            context.Likes.Add(like);
            context.SaveChanges();


            return RedirectToAction("Index", "User", new { username = user.Nickname });
        }


        public ActionResult Fetch(int startIndex, string userName)
        {
            var user = context.Users.Where(p => p.Nickname == userName).FirstOrDefault();
            var modelPost = user.Posts.OrderByDescending(dt => dt.PostTime).Skip(startIndex).Take(5);

            var vm = new UserViewModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Posts = modelPost,
                Nickname = userName
            };
            return PartialView("_Posts", vm);
        }

        #endregion

        #region UserPhoto
        [HttpPost]
        public ActionResult UploadUserPhoto()
        {
            //Getting the current user and manager for the current user
            var manager = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

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

                //Updating user
                user.UserPhoto = imageData;

                //Persisting the user changes in the db
                manager.Update(user);
                System.Web.HttpContext.Current.GetOwinContext().Get<ApplicationDbContext>().SaveChanges();
                

            }

            return RedirectToAction("Index", "User", new { username = user.Nickname });
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

        [HttpPost]
        public ActionResult RemovePhoto()
        {
            var manager = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            user.UserPhoto = null;
            System.Web.HttpContext.Current.GetOwinContext().Get<ApplicationDbContext>().SaveChanges();

            return RedirectToAction("Index", "User", new { username = user.Nickname});
        }
        #endregion
    }
}