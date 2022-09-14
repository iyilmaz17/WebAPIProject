using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductUpdated = "Ürün Güncellendi";
        public static string ProductDeleted = "Ürün Silindi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string ProductsListed = "Ürünler listelendi";
        public static string ProductsListed1 = " cach Ürünler listelendi";

        public static string UserAlreadyExists = "Kullanıcı zaten sisteme kayıtlı";
        public static string UserRegisterOk = "Kullanıcı Eklendi";
        public static string AccessTokenCreated = "Token oluşturuldu";


        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Giriş başarılı";
    }
}
