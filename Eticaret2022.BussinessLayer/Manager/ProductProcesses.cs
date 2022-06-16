using Eticaret2022.DataEntities;
using Eticaret2022.DataEntities.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Eticaret2022.BussinessLayer.Manager
{
    public class ProductProcesses
    {
        public static bool IsCommentProduct(string productId,string customerId)
        {
            var connect = new UnitOfWork(new Eticaret2022Context());
            /*sessiondaki müsterinin satis detay bilgileri.*/
            var satisDetayBilgileri = connect.SatisDetayDal.GetAll().Where(ss => ss.MusteriId == customerId).ToList();
            if (satisDetayBilgileri != null)
            {
                if (satisDetayBilgileri.Count > 0)
                {
                    List<string> satisDetayIdler = new List<string>();
                    List<string> urunIdler = new List<string>();
                    foreach (var item in satisDetayBilgileri)
                    {
                        satisDetayIdler.Add(item.Id.ToString());

                    }
                    if(satisDetayIdler.Count>0)
                    {
                        foreach (var item in satisDetayIdler)
                        {
                            var satilanUrunler = connect.SatilanUrunDal.GetAll().Where(ss => ss.SatisDetayId == Convert.ToInt32(item)).ToList();
                            foreach (var itemUrun in satilanUrunler)
                            {
                                urunIdler.Add(itemUrun.UrunId.ToString());
                            }
                        }
                        if(urunIdler.Contains(productId))
                        {
                            return true; 
                        }
                        else
                        {
                            return false;
                        }
                    }
                   
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        public static bool CheckPrice(string stringFiyat)
        {
            for (int i = 0; i < stringFiyat.Length; i++)
            {
                string characterFiyat = stringFiyat[i].ToString();
                if (i == 0 || i == stringFiyat.Length - 1)
                {
                    if (
                        characterFiyat == "0" ||
                        characterFiyat == "1" ||
                        characterFiyat == "2" ||
                        characterFiyat == "3" ||
                        characterFiyat == "4" ||
                        characterFiyat == "5" ||
                        characterFiyat == "6" ||
                        characterFiyat == "7" ||
                        characterFiyat == "8" ||
                        characterFiyat == "9"
                    ) { }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (
                        characterFiyat == "0" ||
                        characterFiyat == "1" ||
                        characterFiyat == "2" ||
                        characterFiyat == "3" ||
                        characterFiyat == "4" ||
                        characterFiyat == "5" ||
                        characterFiyat == "6" ||
                        characterFiyat == "7" ||
                        characterFiyat == "8" ||
                        characterFiyat == "9" ||
                        characterFiyat == ","
                    ) { }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
