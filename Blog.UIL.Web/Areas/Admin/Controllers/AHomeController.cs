using Blog.Entity.Entities;
using Blog.Repository.Repositories.Abstracts;

using Blog.UIL.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Blog.UIL.Web.Areas.Admin.Controllers
{

    
    [Authorize]
    public class AHomeController : BaseController
    {
        public readonly IUserRepo _userRepo;
        public AHomeController(IUnitOfWork unitOfWork,IUserRepo userRepo) : base(unitOfWork)
        {
            _userRepo = userRepo;
        }
       
        // GET: Admin/AHome
        public ActionResult index( )

        {
           
            return View();

        }
   
        public RedirectResult LogOut()
        {
           
            FormsAuthentication.SignOut();

            return Redirect("/home/index/");
        }
    }
}