using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()//hangi nesne için validator yazacaksam const.içine yazılır
        {
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            //mesela içecek kategorsinin ürünlerinin fiyatı min 10 tl olmalı demek istersemaşağıdaki gibi yazılır
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);
            //Olmayan bir metod yazmak istersek.ürünler A ile başlamalı mesela.StartWithA kendi metodumuz.
            //Ampüle generate metod de.aşağı ekleyecek
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı");
            //özel bir hata mesajı ile gelsin istersek yukarıdaki gibi withmessages ile eklenir


        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");//Ürünler A ile başlarsa True dönecek
        }
    }
}
