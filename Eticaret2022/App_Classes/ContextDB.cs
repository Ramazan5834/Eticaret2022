using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eticaret2022.DataEntities;
using Eticaret2022.DataEntities.DataModels;

namespace Eticaret2022.App_Classes
{
    public class ContextDB
    {
        private static UnitOfWork connect;

        public static UnitOfWork Connect
        {
            get
            {
                if (connect == null)
                {
                    connect = new UnitOfWork(new Eticaret2022Context());
                }

                return connect;
            }
        }
    }
}