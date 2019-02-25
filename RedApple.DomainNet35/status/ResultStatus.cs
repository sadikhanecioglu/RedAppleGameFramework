using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedApple.DomainNet35.status
{
    public enum ResultStatus : int
    {
        Null,
        Ok = 200,
        InValid = 1,
        Error = 500,
        Unauthorized = 401,
        Forbidden = 403
    }
}
