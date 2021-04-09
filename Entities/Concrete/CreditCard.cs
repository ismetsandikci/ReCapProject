using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CreditCard : IEntity
    {
        public int CreditCardId { get; set; }
        public int CustomerId { get; set; }
        public string CardNameSurname { get; set; }
        public string CardNumber { get; set; }
        public string CardExpiryDateMonth { get; set; }
        public string CardExpiryDateYear { get; set; }
        public string CardCvv { get; set; }

    }
}
