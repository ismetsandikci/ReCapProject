﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.CarId).NotEmpty().WithMessage("CarId Değeri Boş Olamaz.");
            RuleFor(r => r.CustomerId).NotEmpty().WithMessage("CustomerId Değeri Boş Olamaz.");
            RuleFor(r => r.RentDate).NotEmpty().WithMessage("RentDate Değeri Boş Olamaz.");
            RuleFor(r => r.AmountPaye).NotEmpty().WithMessage("AmountPaye Değeri Boş Olamaz.");
            RuleFor(r => r.AmountPaye).GreaterThan(1).WithMessage("AmountPaye Değeri 1'den Büyük Olmalı.");
        }
    }
}
