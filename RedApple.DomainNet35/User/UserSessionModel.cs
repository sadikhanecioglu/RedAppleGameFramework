using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedApple.DomainNet35.User
{
    public class UserSessionModel
    {

        public long Id { get; set; }
        public string UserName { get; set; }
        public decimal RealBlanced { get; set; }
        public decimal BonusBlanced { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public int OpenBetCounts { get; set; }

    }
}
