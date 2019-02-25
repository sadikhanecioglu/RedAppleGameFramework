using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedApple.DomainNet35.User
{
    public partial interface IRedUser
    {
        long RedId { get; set; }
        string RedUserName { get; set; }
        string RedToken { get; set; }

    }
}
