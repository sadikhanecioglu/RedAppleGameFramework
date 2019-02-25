using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedApple.DomainNet35.Dto.request
{
    public class LoginResultModel
    {
        public string token { get; set; }
        public DateTime expiredDate { get; set; }
        public string message { get; set; }
        public int uType { get; set; }
        public decimal UserBlance { get; set; }
        public GeneralResultType result { get; set; }
        public UserSessionModel UserInfo { get; set; }
        public bool IsSettingAllow { get; set; }




    }
    public class UserSessionModel
    {

        public long Id { get; set; }
        public string UserName { get; set; }
        public decimal RealBlanced { get; set; }
        public decimal BonusBlanced { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public int OpenBetCounts { get; set; }
    }
    public enum GeneralResultType : int
    {
        OK = 1,
        Error = 2,
        Warning = 3
    }
}
