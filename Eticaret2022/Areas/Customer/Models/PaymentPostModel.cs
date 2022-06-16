using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eticaret2022.Models
{
    public class PaymentPostModel
    {
        [Required]
        public int AddressId { get; set; }
        public int PaymentType { get; set; }
        public int IndividualType { get; set; }
        public string TcKimlik { get; set; }
        public string FirmaAdi { get; set; }
        public string VergiNo { get; set; }
        public string VergiDairesi { get; set; }

        public string TaxNumber { get; set; }


        public string CreditCardNo { get; set; }
        public string Cvv { get; set; }
        public string CreditCardYearMonth { get; set; }
        public string NameSurname { get; set; }

    }
}