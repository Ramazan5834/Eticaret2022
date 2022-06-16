using Eticaret2022.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eticaret2022.DataEntities.DataModels;

namespace Eticaret2022.BussinessLayer.Basket
{
    public class Basket 
    {
        private List<BasketLine> _basketLines = new List<BasketLine>();
        public List<BasketLine> BasketLines
        {
            get
            {
                return _basketLines;
            }
        }


        public void AddProduct(Urun urun, int adet)
        {
            var line = _basketLines.FirstOrDefault(ss => ss.Urun.Id == urun.Id);
            if (line == null)
            {
                _basketLines.Add(new BasketLine
                {
                    Urun = urun,
                    Adet = adet
                });
            }
            else
            {
                line.Adet += adet;
            }
        }

        public void DeleteProduct(Urun urun)
        {
            _basketLines.RemoveAll(i => i.Urun.Id == urun.Id);
        }
        public void DeleteProductSelected(Urun urun)
        {
            var urunSilinecek = _basketLines.FirstOrDefault(i => i.Urun.Id == urun.Id);
            urunSilinecek.Adet = urunSilinecek.Adet-1;
        }
        public double TotalPrice()
        {
            return (double)_basketLines.Sum(i => i.Urun.Fiyat * i.Adet);
        }
        public void ClearBasket()
        {
            _basketLines.Clear();
        }
    }

    public class BasketLine
    {
        public Urun Urun { get; set; }
        public int Adet { get; set; }
    }
}
