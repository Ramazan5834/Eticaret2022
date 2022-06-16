using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret2022.BussinessLayer.Manager
{
    public class ResponseResult<T>  where T : class // generic T Class olmalı şartı.. by mirza
    {
        public Boolean IsSuccess { get; set; }
        public T Result { get; set; }

        public String Message { get; set; }

    }
}
