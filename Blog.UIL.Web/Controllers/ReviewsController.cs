using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Entity.Entities;
using Blog.Repository.Repositories.Abstracts;

namespace Blog.UIL.Web.Controllers
{
    public class ReviewsController : BaseController
    {
        public ReviewsController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        // GET: Review
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail(int id)
        {
            var model = _unitOfWork.GetRepo<Review>().Where(x => x.Id == id).FirstOrDefault();
            return View(model);
        }
        //[Authorize]
        
        //public string LikeReview(int id) 
        //{
        //    var model = _unitOfWork.GetRepo<Review>().Where(x => x.Id == id).FirstOrDefault();
        //    model.Like++;
        //    _unitOfWork.Commit();
        //    return model.Like.ToString();
        //}

        //public string Viewed(int id) 
        //{
        //    var model = _unitOfWork.GetRepo<Review>().Where(x => x.Id == id).FirstOrDefault();
        //    model.View++;
        //    _unitOfWork.Commit();
        //    return model.View.ToString();
        //}

    }
}