using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Entities;

namespace WebAPI.Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı");
            RuleFor(p => p.CategoryId).Must(EqualsBir).WithMessage("Kategori 1 olmalıdır");
        }

        private bool EqualsBir(int arg)
        {
            return arg == 1;
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
