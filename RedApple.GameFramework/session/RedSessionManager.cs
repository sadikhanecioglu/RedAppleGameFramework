using RedApple.DomainNet35.Dto.request;
using RedApple.DomainNet35.User;
using RedApple.GameFramework.system;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedApple.GameFramework.session
{
    public sealed class RedSessionManager
    {

        private static readonly Lazy<RedSessionManager> lazy =
new Lazy<RedSessionManager>(() => new RedSessionManager());

        public static RedSessionManager Instance { get { return lazy.Value; } }

        bool _isAut = false;
        public bool IsAuthenticated { get {

                if (ExpiredDate < DateTime.Now)
                    return false;
                else
                    return _isAut;

            } }

        public RedGameUser SessionUser { get; set; }

        public DateTime ExpiredDate { get; set; }


        public RedGameUser OpenRedSession(long redUserId, string userName, string token, decimal coin, DateTime expiredDate)
        {

            this._isAut = true;
            this.SessionUser = new RedGameUser() { RedId = redUserId, RedToken = token, RedUserName = userName, Coin = coin };
            this.ExpiredDate = expiredDate;
            
            return this.SessionUser;
        }

        public void LogOut()
        {
            this._isAut = false;
            this.SessionUser = null;
        }
    }
}
