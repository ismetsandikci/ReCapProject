using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).MinimumLength(2).WithMessage("FirstName Değeri 2 Karakterden Büyük Olmalı.");
            RuleFor(u => u.LastName).MinimumLength(2).WithMessage("LastName Değeri 2 Karakterden Büyük Olmalı.");
            RuleFor(u => u.Email).MinimumLength(2).WithMessage("Email Değeri 2 Karakterden Büyük Olmalı.");
            RuleFor(u => u.Password).MinimumLength(2).WithMessage("Password Değeri 2 Karakterden Büyük Olmalı.");
        }
    }
}
