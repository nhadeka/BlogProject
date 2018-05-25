
using Blog.BLL.Validations;
using Blog.Entity.Entities;
using Blog.Repository.Repositories.Abstracts;
using Blog.UIL.Web.App_Class;
using Blog.UIL.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.UIL.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class ReviewController : BaseController
    {
        private readonly IReviewRepo _reviewRepo;
      
        public ReviewController(IUnitOfWork unitOfWork,IReviewRepo reviewRepo) : base(unitOfWork)
        {
            _reviewRepo = reviewRepo;
           
        }

        // GET: Admin/Review
        public ActionResult List()
        {
            var model = _unitOfWork.GetRepo<Review>().GetAll();
            return View(model);
        }
      
        public ActionResult Add()
        {
           ViewBag.Genres =_unitOfWork.GetRepo<Genre>().GetAll();
          
            return View();
        }
        [HttpPost]
       
        public ActionResult Add(Review model,HttpPostedFileBase image) 
        {

            var validator = new ReviewValidator(_unitOfWork).Validate(model);

            if (validator.IsValid)
            {
                if (image != null)
                {

                    Image img = Image.FromStream(image.InputStream);

                    string name = Guid.NewGuid() + Path.GetExtension(image.FileName);

                    string smPath = "/content/site/style/images/reviewimg/sm/" + name;
                    string mdPath = "/content/site/style/images/reviewimg/md/" + name;
                    string lgPath = "/content/site/style/images/reviewimg/lg/" + name;

                    Bitmap smImage = new Bitmap(img, MySettings.SmallPicSize);
                    Bitmap mdImage = new Bitmap(img, MySettings.MediumPicSize);
                    Bitmap lgImage = new Bitmap(img, MySettings.LargePicSize);


                    smImage.Save(Server.MapPath(smPath));
                    mdImage.Save(Server.MapPath(mdPath));
                    lgImage.Save(Server.MapPath(lgPath));

                    Picture pic = new Picture();
                    pic.SmPic = smPath;
                    pic.MdPic = mdPath;
                    pic.LgPic = lgPath;



                    _unitOfWork.GetRepo<Picture>().Add(pic);
                    _unitOfWork.Commit();

                    model.PictureId = pic.Id;
                    _unitOfWork.GetRepo<Review>().Add(model);

                    bool IsSuccess = _unitOfWork.Commit();
                    if (IsSuccess)
                    {
                        return RedirectToAction("list");
                    }
                    else
                    {
                        ViewBag.IsSuccess = IsSuccess;
                    ViewBag.Message = "tekrar deneyin";
                    return View();
                    }
                }
              
             
                }
          
            
            validator.Errors.ToList().ForEach(a =>
            {
                ModelState.AddModelError(a.PropertyName, a.ErrorMessage);
            });

            return View();


        }

        public ActionResult Edit(int id)
        {
            ViewBag.Genres = _unitOfWork.GetRepo<Genre>().GetAll();
          
            var model = _unitOfWork.GetRepo<Review>().GetObject(x => x.Id == id);
            ViewBag.Pictures = _unitOfWork.GetRepo<Picture>().GetObject(x => x.Id ==model.PictureId);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Review guncel, HttpPostedFileBase image)
        {
           
            var validator = new ReviewValidator(_unitOfWork).Validate(guncel);

            if (validator.IsValid)
            {

                var model = _unitOfWork.GetRepo<Review>().GetObject(x => x.Id == guncel.Id);

                model.Title = guncel.Title;
                model.Content = guncel.Content;
                model.GenreId = guncel.GenreId;


                _unitOfWork.GetRepo<Review>().Update(model);

                bool IsSuccess = _unitOfWork.Commit();
                if (IsSuccess)
                {
                    return RedirectToAction("list");
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
            _unitOfWork.GetRepo<Review>().Delete(id);
            bool isSuccess = _unitOfWork.Commit();

            TempData["Message"] = isSuccess ? "Başarılı" : "Silme işleminin tekrar deneyiniz";

            return RedirectToAction("list");
        }


       

    }
}