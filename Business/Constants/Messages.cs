using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Car Added";
        public static string CarUpdated = "Car Updated";
        public static string CarDeleted = "Car Deleted";
        public static string CarNotValid= "The car could not be added. Registration conditions;\n" +
                    "-The car description must contain at least two characters\n" +
                    "-The daily price of the car must be greater than zero";

        public static string ColorAdded = "Color Added";
        public static string ColorUpdated = "Color Updated";
        public static string ColorDeleted = "Color Deleted";

        public static string BrandAdded = "Brand Added";
        public static string BrandUpdated = "Brand Updated";
        public static string BrandDeleted = "Brand Deleted";

        public static string UserAdded = "User Added";
        public static string UserUpdated = "User Updated";
        public static string UserDeleted = "User Deleted";
        public static string UsersGetAll = "UsersGetAll"; 
        public static string GetUserByUserId = "GetUserByUserId";

        public static string CustomerAdded = "Customer Added";
        public static string CustomerUpdated = "Customer Updated";
        public static string CustomerDeleted = "Customer Deleted";
        public static string CustomerNotValid = "Company Name Not Valid";
        public static string CustomersGetAll = "CustomersGetAll";
        public static string GetCustomerById = "GetCustomerById";
        public static string GetCustomerByUserId = "GetCustomerByUserId";

        public static string RentalAdded = "Rental Added";
        public static string RentalUpdated = "Rental Updated";
        public static string RentalDeleted = "Rental Deleted";
        public static string RentalReturnDateError = "The car cannot be rented on the requested dates.";
        public static string RentalDateOk = "The car can be delivered on the requested dates.";
        public static string RentalGetAll = "RentalGetAll"; 
        public static string GetRentalByRentalId = "GetRentalByRentalId";

        public static string CarImageLimitExceeded = "Bir arabanın 5'dan fazla resmi olamaz.";
        public static string CarImageAdded = "Araba resmi eklendi";
        public static string CarImageDeleted = "Araba resmi silindi";
        public static string CarImageUpdated = "Araba resmi güncellendi";

        public static string AuthorizationDenied = "Yetkiniz yok";

        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";

        public static string CreditCardAdded = "Kredi Kartı Eklendi";
        public static string CreditCardUpdated = "Kredi Kartı Güncellendi";
        public static string CreditCardDeleted = "Kredi Kartı Silindi";
        public static string CreditCardGetAll = "Kredi Kartları Listelendi";
        public static string GetCreditCardById = "Id Bilgisine Göre Kart Listelendi";
        public static string CreditCardAlreadyExists = "Bu kredi kartı numarası zaten mevcut";

        public static string FindeksNotFound = "Findeks puanınızı arttırmanız gerekmektedir.";
        public static string FindeksNotEnoughForCar = "Findeks puanınız araba için yeterli değil.";
        public static string FindeksIsSufficientForCar = "Findeks puanınız araba için yeterli.";
        public static string FindeksGetByCustomerId = "Müşteriye ait Findeks puanı listelendi.";
        public static string FindeksAdded = "Findeks puanını eklendi.";
        public static string FindeksUpdated = "Findeks puanını güncellendi.";
        public static string FindeksDeleted = "Findeks puanını silindi.";

        public static string PaymentSuccessful = "Ödeme Başarılı";
    }
}
