
using Blog.BLL.Validations;
using Blog.Entity.Entities;
using Blog.Repository.Repositories.Abstracts;
using Blog.UIL.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Blog.UIL.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class GenreController : BaseController
    {
        private readonly IGenreRepo _genreRepo;
        
        public GenreController(IUnitOfWork unitOfWork,IGenreRepo genreRepo) : base(unitOfWork)
        {
            _genreRepo = genreRepo;
        }

        // GET: Admin/Genre
        public ActionResult List()
        {
            var model = _unitOfWork.GetRepo<Genre>().GetAll();
            return View(model);
        }
        public ActionResult Add()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Add(Genre model)
        {
            var validator = new GenreValidator(_unitOfWork).Validate(model);

            if (validator.IsValid)
            {


                _unitOfWork.GetRepo<Genre>().Add(model);
                bool IsSuccess = _unitOfWork.Commit();
              
                if (IsSuccess)
                {
                    return RedirectToAction("List");
                }
                
                ViewBag.IsSuccess = IsSuccess;
                ViewBag.Message = "Tekrar Deneyiniz";
                return View();
                

            }

          
                validator.Errors.ToList().ForEach(a =>
                {
                    ModelState.AddModelError(a.PropertyName, a.ErrorMessage);
                });

            return View();
        }
        public ActionResult Edit(int id)
        {
            var model = _unitOfWork.GetRepo<Genre>().GetObject(x => x.Id == id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Genre guncel)
        {

            
            var validator = new GenreValidator(_unitOfWork).Validate(guncel);
          
            if (validator.IsValid)
            {
                var model = _unitOfWork.GetRepo<Genre>().GetObject(x => x.Id == guncel.Id);
                model.Name = guncel.Name;
              model.Description = guncel.Description;
             _unitOfWork.GetRepo<Genre>().Update(guncel);
            bool IsSuccess = _unitOfWork.Commit();
                if (IsSuccess)
                {
                    return RedirectToAction("List");
                }
                else
                {
                    ViewBag.IsSuccess = IsSuccess;
                    ViewBag.Message = "tekrar deneyin";
                    return View();
                }
            
            }
           
           validator.Errors.ToList().ForEach(a =>
            {
                ModelState.AddModelError(a.PropertyName, a.ErrorMessage);
            });

                return View();
           
           
            
        }
        public ActionResult Delete(int id)
        {
             _unitOfWork.GetRepo<Genre>().Delete(id);
            bool isSuccess = _unitOfWork.Commit(); 

            TempData["Message"] = isSuccess ? "Başarılı" : "Silme işleminin tekrar deneyiniz";

            return RedirectToAction("List");
        }
    }
}