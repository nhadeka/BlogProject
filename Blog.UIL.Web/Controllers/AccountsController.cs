using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Blog.BLL.Validations;
using Blog.Entity.Entities;
using Blog.Repository.Repositories.Abstracts;
using Blog.Repository.Repositories.Concretes;
using Blog.UIL.Web.Models;

namespace Blog.UIL.Web.Controllers
{
    public class AccountsController : BaseController
    {
       

        private readonly IUserRepo _userRepo;
        public AccountsController(UnitOfWork unitofWork, IUserRepo userRepo) : base(unitofWork)
        {

            _userRepo = userRepo;
        }

        public ActionResult Login()
        {

            return View();
        }
        public RedirectResult Logout()
        {
           
            FormsAuthentication.SignOut();

            return Redirect("/home/index");
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model)
        {

            if (ModelState.IsValid)
            {
              
                    var user =_unitOfWork.GetRepo<User>().Where(x => x.UserName == model.UserName && x.Password == model.Password).FirstOrDefault();

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName,model.RememberMe);

                    if (user.Role.Name=="admin")
                    {
                        ViewBag.UserName = user.UserName;
                        return Redirect("/Admin/AHome/Index");

                    }
                 

                    //else if (user.Role.Name == "üye")
                    //{
                    //    ViewBag.UserName = user.UserName;
                    //    return Redirect("/Home/Index");
                    //}


                }
             
               
            }
            ViewBag.FormResult = "Kullanıcı adı veya şifre hatalı";
            return View();
        }

        






















    }
}