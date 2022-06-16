using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret2022.BussinessLayer.Manager
{
    public static class Consts
    {
        public static string ContactSuccessMessage { 
            get
            {
                return "Mesaj Gönderme İşlemi Başarılı.";
            }
        }

        public static  string ContactErrorMessage
        {
            get
            {
                return "Mesaj Gönderme İşlemi Başarısız.";
            }
        }

        public static string CommentSuccessMessage
        {
            get
            {
                return "Yorum Gönderme İşlemi Başarılı.";
            }
        }

        public static string CommentErrorMessage
        {
            get
            {
                return "Yorum Gönderme İşlemi Başarısız.";
            }
        }
    }
}
