using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adı Boş Geçilemez!");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori Açıklaması Boş Geçilemez!");
            RuleFor(x => x.CategoryDescription).MinimumLength(40).WithMessage("Kategori Açıklaması En Az 40 Karakter Olmalı!");
            RuleFor(x => x.CategoryDescription).MaximumLength(200).WithMessage("Kategori Açıklaması En Fazla 200 Karakter Olmalı!");
        }
    }
}
