using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eticaret2022.DataEntities.DataModels;

namespace Eticaret2022.BussinessLayer.EmailHelper
{
    public class EmailHtml
    {
        private SatisDetay _satisDetay;
        public EmailHtml(SatisDetay satisDetay)
        {
            _satisDetay = satisDetay;
        }

        public string GetEmailHtmlContent()//html lang en unutma
        {
            string satisTarihString = _satisDetay.Tarih.ToString();
            string satisTotalFiyatString = _satisDetay.TotalFiyat.ToString();
            string satisAdresString = _satisDetay.Adres.Baslik + " " +
                                        _satisDetay.Adres.Sehir + " " +
                                        _satisDetay.Adres.Ilce + " " +
                                        _satisDetay.Adres.AcikAdres + " " +
                                        _satisDetay.Adres.PostaKodu;
            string satisOdemeTipString = _satisDetay.OdemeTip.Adi;
            List<SatilanUrun> satisSatilanUrunler = _satisDetay.SatilanUrun.ToList();

            string EmailHtmlContent = "<!DOCTYPE html>" +
                                      "<html>" +
                                      "<body>" +
                                      "<div>" +
                                      "<div style = \"display: grid;grid-template-columns: repeat(auto-fit, minmax(300px, 1fr));gap: 1rem;align-items: flex-start;\">" +
                                      "<div style = \"--padding: 1rem; background: white; border: 1px solid #777; border-radius: 0.25rem; overflow: hidden;\">" +
                                      "<div style = \"font-size: 1.2rem; padding: var(--padding); padding-bottom: 0; margin-bottom: 0.5rem;\">" +
                                      $" {satisTarihString} Tarihli Siparişinizin Özeti Aşşağıdadır" +
                                      "</div>" +
                                      "<div style = \"font-size: 0.9rem;padding: 0 var(--padding);\">" +
                                      $"*Total Fiyat: {satisTotalFiyatString}<br>" +
                                      $"*Tarih: {satisTarihString}<br>" +
                                      $"*Sipariş Adresi: {satisAdresString}<br>" +
                                      $"*Ödeme Türü: {satisOdemeTipString}<br>" +
                                      "</div>" +
                                      "<div style = \"margin-top: 1rem; padding: var(--padding); padding-top: 0;\" >" +
                                      "<button type=button style = \"margin-bottom: 1rem;margin-left:1rem;\" >Soru Sormak İçin Tıklayınız</button>" +
                                      "</div>" +
                                      "</div>" +
                                      "</div>" +
                                      "<hr>" +
                                      "<table style = \"width: 100%; font-family: arial, sans-serif; border-collapse: collapse;border: 1px solid black;\">" +
                                      "<thead>" +
                                      "<tr>" +
                                      "<th style = \" padding: 8px; text-align: left;border: 1px solid black;\" > Ürün Adı</th>" +
                                      "<th style = \" padding: 8px; text-align: left;border: 1px solid black;\" > Adet </th>" +
                                      "<th style = \" padding: 8px; text-align: left;border: 1px solid black;\" > Birim Fiyat </th>" +
                                      "</tr>" +
                                      "</thead>" +
                                      "<tbody>" +
                                      GenerateEmailProductsTrHtmlElements(satisSatilanUrunler) +
                                      "</tbody>" +
                                      "</table>" +
                                      "</div>" +
                                      "</body>" +
                                      "</html>";
            return EmailHtmlContent;
        }

        private string GenerateEmailProductsTrHtmlElements(List<SatilanUrun> satisSatilanUrunler)
        {
            string EmailHtmlTrElements = String.Empty;
            foreach (var satisSatilanUrun in satisSatilanUrunler)
            {
                string tempSatilanUrunTr = "<tr>" +
                      $"<td style = \" padding: 8px; text-align: left;border: 1px solid black;\" > {satisSatilanUrun.Urun.Adi} </td>" +
                      $"<td style = \" padding: 8px; text-align: left;border: 1px solid black;\" > {satisSatilanUrun.Adet} </td>" +
                      $"<td style = \" padding: 8px; text-align: left;border: 1px solid black;\" > {satisSatilanUrun.UrunAnlikFiyat} </td>" +
                      " </tr>";
                EmailHtmlTrElements += tempSatilanUrunTr;
            }
            return EmailHtmlTrElements;
        }
    }
}
