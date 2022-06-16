using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Eticaret2022.DataEntities.DataModels;

namespace Eticaret2022.BussinessLayer.EmailHelper
{
    public class EmailHelper
    {
        public static bool SendEmailConfirmOrder(SatisDetay satisDetay)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(new MailAddress(satisDetay.AspNetUsers.Email));//Buraya müşterinin emaili gelecek
            mailMessage.Subject = "Sivkoop Sipariş Onayı";
            mailMessage.IsBodyHtml = true;
            EmailHtml emailHtmlClass = new EmailHtml(satisDetay);
            string body = emailHtmlClass.GetEmailHtmlContent();
            mailMessage.Body = body;

            SmtpClient smtpClient = new SmtpClient();
            try
            {
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public static bool SendEmailUserLockout(string email)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(new MailAddress(email));//Buraya müşterinin emaili gelecek
            mailMessage.Subject = "Sivkoop Hesabınız 10dk İçin Bloke Oldu";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = "Hesabınızla çok fazla deneme yapıldı.Bu sebepten ötürü hesabınız 10dk süre ile geçici olarak bloke edilmiştir.Eğer bu giriş denemelerini siz yapmadıysanız güvenliğiniz açısından.Lütfen site yetkililerine durumu bildiriniz.";

            SmtpClient smtpClient = new SmtpClient();
            try
            {
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public static bool SendEmailCargoCode(SatisDetay satisDetay)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(new MailAddress(satisDetay.AspNetUsers.Email));//Buraya müşterinin emaili gelecek
            mailMessage.Subject = "Sivkoop Siparişiniz Kargoya Verildi";
            mailMessage.IsBodyHtml = true;
            string callbackUrl = "http://suratkargo.com.tr/KargoTakip/?kargotakipno=" + satisDetay.KargoNumarasi;
            mailMessage.Body = "<!DOCTYPE html>" + "<html>" + "<body>" +
                               $"{satisDetay.Tarih} tarihli ve {satisDetay.TotalFiyat} TL tutarlı siparişiniz kargoya verilmiştir \n" +
                               "Kargo Takibi İçin Tıklayınız <a href=\"" + callbackUrl + "\">Buraya Tıklayın</a>" +
                               "</body>" + "</html>"; 
            SmtpClient smtpClient = new SmtpClient();
            try
            {
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public static bool SendEmailCreateOrder(SatisDetay satisDetay)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(new MailAddress(satisDetay.AspNetUsers.Email));//Buraya müşterinin emaili gelecek
            mailMessage.Subject = "Sivkoop Siparişiniz Oluşturuldu";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = $"Vermiş olduğunuz {satisDetay.Tarih} tarihli ve {satisDetay.TotalFiyat} TL tutarındaki siparişiniz oluşturuldu.Bizi tercih Ettiğiniz için teşekkür ederiz.";

            SmtpClient smtpClient = new SmtpClient();
            try
            {
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public static bool SendEmailToAdminAfterCreateOrder(SatisDetay satisDetay,string adminEmail)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(new MailAddress(adminEmail));//Buraya müşterinin emaili gelecek
            mailMessage.Subject = "Sivkoop Yeni Sipariş";
            mailMessage.IsBodyHtml = true;
            EmailHtml emailHtmlClass = new EmailHtml(satisDetay);
            string body = emailHtmlClass.GetEmailHtmlContent();
            mailMessage.Body = body;

            SmtpClient smtpClient = new SmtpClient();
            try
            {
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

    }
}
