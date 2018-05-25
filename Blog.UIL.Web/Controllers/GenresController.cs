using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Entity.Entities;
using Blog.Repository.Repositories.Abstracts;

namespace Blog.UIL.Web.Controllers
{
    public class GenresController : BaseController
    {
        public GenresController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        // GET: Genre
        public ActionResult Index(int id) 
        {
            return View(id);
        }
        public PartialViewResult _ListGenre()
        {
            var model = _unitOfWork.GetRepo<Genre>().GetAll().ToList();
            return PartialView(model);
        }
        public ActionResult ListReview(int id) 
        {
            var model = _unitOfWork.GetRepo<Review>().Where(x => x.GenreId == id).ToList();
            return View("_ListReview",model);
        }
    }

}