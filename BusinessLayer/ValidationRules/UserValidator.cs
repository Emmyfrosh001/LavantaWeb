using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kategory adını boş geçemezsiniz!");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Kategori ismi 3 karakterden az olamaz!");
            RuleFor(x => x.UserName).MaximumLength(50).WithMessage("Kategori ismi 50 karakterden fazla olamaz!");
        }
    }
}
