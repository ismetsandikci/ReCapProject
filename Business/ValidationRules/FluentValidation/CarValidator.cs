using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.BrandId).NotEmpty().WithMessage("BrandId Değeri Boş Olamaz.");
            RuleFor(c => c.ColorId).NotEmpty().WithMessage("ColorId Değeri Boş Olamaz.");
            RuleFor(c => c.ModelName).NotEmpty().WithMessage("ModelName Değeri Boş Olamaz.");
            RuleFor(c => c.ModelYear).NotEmpty().WithMessage("ModelYear Değeri Boş Olamaz.");
            RuleFor(c => c.DailyPrice).NotEmpty().WithMessage("DailyPrice Değeri Boş Olamaz.");
            RuleFor(c => c.DailyPrice).GreaterThan(0).WithMessage("DailyPrice Değeri 0'dan Büyük Olmalı.");
            RuleFor(c => c.Description).NotEmpty().WithMessage("Description Değeri Boş Olamaz.");
            RuleFor(c => c.Description).MinimumLength(2).WithMessage("Description Değeri 2 Karakterden Büyük Olmalı.");
        }
    }
}