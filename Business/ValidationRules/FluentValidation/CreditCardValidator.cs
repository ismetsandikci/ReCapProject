using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CreditCardValidator : AbstractValidator<CreditCard>
    {
        public CreditCardValidator()
        {
            RuleFor(c => c.CustomerId).NotEmpty().WithMessage("Kredi Kartı için CustomerId Değeri Boş Olamaz.");
            RuleFor(c => c.CardNameSurname).NotEmpty().WithMessage("Kredi Kartı için NameSurname Değeri Boş Olamaz.");
            RuleFor(c => c.CardNameSurname).MinimumLength(5).WithMessage("Kredi Kartı için NameSurname Değeri 5 Karakterden Büyük Olmalı.");
            RuleFor(c => c.CardNumber).NotEmpty().WithMessage("Kredi Kartı için CardNumber Değeri Boş Olamaz.");
            RuleFor(c => c.CardNumber).Length(16).WithMessage("Kredi Kartı için CardNumber Değeri 16 karakter olmalı");
            RuleFor(c => c.CardExpiryDateMonth).NotEmpty().WithMessage("Kredi Kartı için CardExpiryDateMonth Değeri Boş Olamaz.");
            RuleFor(c => c.CardExpiryDateMonth.ToString()).Length(2).WithMessage("Kredi Kartı için CardExpiryDateMonth Değeri 2 Karakter Olmalı.");
            RuleFor(c => c.CardExpiryDateYear).NotEmpty().WithMessage("Kredi Kartı için CardExpiryDateYear Değeri Boş Olamaz.");
            RuleFor(c => c.CardExpiryDateYear.ToString()).Length(4).WithMessage("Kredi Kartı için CardExpiryDateYear Değeri 4 Karakter Olmalı.");
            RuleFor(c => c.CardCvv).NotEmpty().WithMessage("Kredi Kartı için Cvv Değeri Boş Olamaz.");
            RuleFor(c => c.CardCvv).Length(3).WithMessage("Kredi Kartı için Cvv Değeri 3 karakter olmalı.");
        }
    }
}
