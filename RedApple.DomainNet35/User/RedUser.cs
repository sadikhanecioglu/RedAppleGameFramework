using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedApple.DomainNet35.User
{
    public abstract class RedUser : IRedUser
    {
        public long RedId { get; set; }
        public string RedUserName { get; set; }
        public string RedToken { get; set; }
    }
}
