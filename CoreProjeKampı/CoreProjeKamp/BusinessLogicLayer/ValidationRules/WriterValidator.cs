using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>//Buradan kalıtım almamız şart
    {   
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Ad ve Soyad boş bırakılamaz.");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("En az 2 karakter giriniz.");
            RuleFor(x => x.WriterName).MaximumLength(40).WithMessage("En fazla 40 karakter giriniz");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail Adresi boş bırakılamaz.");
            RuleFor(x => x.WriterMail).MinimumLength(10).WithMessage("En az 10 karakter giriniz. not=@gmail.com dahil");
            RuleFor(x => x.WriterMail).MaximumLength(40).WithMessage("En fazla 40 karakter giriniz. not=@gmail.com dahil");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre boş Geçilemez.");
            RuleFor(x => x.WriterPassword).MinimumLength(8).WithMessage("En az 8 karakter giriniz. not:Şifre önemlidir.");
            RuleFor(x => x.WriterPassword).MaximumLength(10).WithMessage("En fazla 10 karakter giriniz. not:Şifre önemlidir.");
        }
    }
}
