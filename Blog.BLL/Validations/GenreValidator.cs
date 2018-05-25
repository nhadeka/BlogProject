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
    public class GenreValidator : AbstractValidator<Genre>
    {


        public readonly IUnitOfWork _unitOfWork;


        public GenreValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            InitConfig();
        }

        public virtual void InitConfig()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.Name).MaximumLength(80).WithMessage("80 karakterden fazla yazamazsınız");
           
            RuleFor(x => x.Name).Must(UniqeNameCheck).WithMessage("aynı isimde tür mevcuttur.");
        }

        public bool UniqeNameCheck(Genre model, string name)
        {

            var data = _unitOfWork.GetRepo<Genre>().Where(x => x.Name == name && x.Id != model.Id).FirstOrDefault();

            if (data == null)
            {
                return true;
            }

            return false;
        }
    }
}
