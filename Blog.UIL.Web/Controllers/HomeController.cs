using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Entity.Entities;
using Blog.Repository.Repositories.Abstracts;

namespace Blog.UIL.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        // GET: Home
        public ActionResult Index()
        {
           
            return View();
        }

       


        public ActionResult ListReview()
        {
            var model = _unitOfWork.GetRepo<Review>().GetAll();           
            return View("_ListReview",model); 
        }
       
        public PartialViewResult _LatestReview()
        {
            var model = _unitOfWork.GetRepo<Review>().Where(x => x.Id != null).OrderByDescending(x => x.AdditionDate).Take(3).ToList();
            return PartialView("_LatestReview", model);
        }
    }
}