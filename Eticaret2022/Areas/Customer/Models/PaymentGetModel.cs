using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eticaret2022.Areas.Customer.Models
{
    public class PaymentGetModel
    {
        public DataEntities.DataModels.AspNetUsers userInfo = new DataEntities.DataModels.AspNetUsers();
        public List<DataEntities.DataModels.Adres> userAddressList = new List<DataEntities.DataModels.Adres>();
        public List<DataEntities.DataModels.OdemeTip> paymentTypeList = new List<DataEntities.DataModels.OdemeTip>();
    }
}