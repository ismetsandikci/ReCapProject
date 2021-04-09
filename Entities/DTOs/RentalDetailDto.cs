using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalDetailDto : IDto
    {
        public int RentalId { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string UserName { get; set; }
        public string CompanyName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int AmountPaye { get; set; }
        public string CardNameSurname { get; set; }
        public string CardNumber { get; set; }
        public string CardExpiryDateMonth { get; set; }
        public string CardExpiryDateYear { get; set; }
        public string CardCvv { get; set; }
    }
}
