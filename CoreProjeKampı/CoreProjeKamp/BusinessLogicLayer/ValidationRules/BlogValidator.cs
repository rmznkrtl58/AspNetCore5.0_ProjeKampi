using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ValidationRules
{
    public class BlogValidator:AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog Başlığını Boş Geçemezsin!");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Kategoriyi Boş Geçemezsin!");
            RuleFor(x => x.BlogThumbnailImage).NotEmpty().WithMessage("Görseli Boş Geçemezsin!");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog İçeriğini Boş Geçemezsin!");
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("Blog Başlık en az 5 karakter girilmelidir!");
            RuleFor(x => x.BlogTitle).MaximumLength(30).WithMessage("Blog Başlık en fazla 30 karakter girilmelidir!");
            RuleFor(x => x.BlogContent).MinimumLength(130).WithMessage("Blog İçeriği en az 130 karakter olmalıdır!");
            RuleFor(x => x.BlogContent).MaximumLength(3000).WithMessage("Blog İçeriği en fazle 3000 karakter olmalıdır!");
        }
    }
}
