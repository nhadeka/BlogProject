using Blog.Entity.Entities;
using Blog.Repository.Repositories.Abstracts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.Validations
{
   public class ReviewValidator:AbstractValidator<Review>
    {
        public readonly IUnitOfWork _unitOfWork;


        public ReviewValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            InitConfig();
        }

        public virtual void InitConfig()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("50 karakterden fazla yazamazsınız");
            RuleFor(x => x.Content).MaximumLength(200).WithMessage("200 karakter sınırı vardır");
            RuleFor(x => x.Title).Must(UniqeNameCheck).WithMessage("aynı başlık mevcuttur.");
        }
        public bool UniqeNameCheck(Review model, string name)
        {

            var data = _unitOfWork.GetRepo<Review>().Where(x => x.Title == name && x.Id != model.Id).FirstOrDefault();

            if (data == null)
            {
                return true;
            }

            return false;
        }
    }
}
