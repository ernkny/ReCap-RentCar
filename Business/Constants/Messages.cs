using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Arabanız Eklendi  ";
        public static string CarNameInvalid = "Araba ismi geçersiz";
        internal static string MaintanceTime="Sistem Şuanda Bakımda";
        internal static string CarsListed = "Arabalar Listelendi";
        public static string CarImageAdded = "Araba resimleriniz yüklendi";
        public static string CarImageDeleted = "Arabanın resmi silindi";
        internal static string TotalPictureMoreThanFive="5 Adetten fazla resim yükleyemezsiniz";
        internal static string EmptyCarPhoto="Arabaya ait fotoğraf bulunamadı";
    }
}
