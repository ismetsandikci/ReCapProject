using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.UserId).NotEmpty().WithMessage("UserId Değeri Boş Olamaz.");
            RuleFor(c => c.CompanyName).MinimumLength(2).WithMessage("CompanyName Değeri 2 Karakterden Büyük Olmalı.");
        }
    }
}
