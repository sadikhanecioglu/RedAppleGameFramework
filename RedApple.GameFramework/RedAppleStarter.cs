using RedApple.ConnectFramework.manager.UserManager;
using RedApple.GameFramework.config;
using RedApple.GameFramework.contanier;
using RedApple.GameFramework.manager.QuestManager;
using RedApple.GameFramework.manager.UserManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedApple.GameFramework
{

    /// <summary>
    /// RedAppleStarter GameFremaworkun ilk başlangıçta ayarlarının set edildiği classdır ve RedAppleStart çalıştırma işlemi başlanır
    /// </summary>
    public class RedAppleStarter
    {
        private string _configPath;


        public RedAppleStarter() : base()
        {

        }


        public void UseAuthentication(Action<auth.AuthenticationSettings> setup = null)
        {
   
            RedContanierManager.Instance.Contanier.RegisterInstanceType<IUserManager, UserManager>();

        }


        /// <summary>
        /// Register Funksiyonu Açılıştı kendi kullanacağı instanceları register yapar ver geriye RedContanierManager döndürür
        /// </summary>
        /// <returns>RedContanierManager</returns>
        public RedApple.GameFramework.contanier.RedContanierManager RedRegister()
        {

            RedContanierManager.Instance.Contanier.RegisterInstanceType<ConnectFramework.socket.IRedSocket, ConnectFramework.socket.RedWebSocket>();
            RedContanierManager.Instance.Contanier.RegisterInstanceType<ConnectFramework.www.IRedWebRequest, ConnectFramework.www.RedWebRequest>();
            RedContanierManager.Instance.Contanier.RegisterInstanceType<IQuestManager, QuestManager>();

            return RedContanierManager.Instance;

        }

        public RedApple.GameFramework.config.RedConfigManager Configure(string configPath = "")
        {
            this._configPath = configPath;
            if (string.IsNullOrEmpty(_configPath))
                _configPath = $"{AppDomain.CurrentDomain.BaseDirectory}redappleconfig.json";

            //config load
            RedConfigManager.Instance.LoadConfig(_configPath);


            return RedApple.GameFramework.config.RedConfigManager.Instance;
        }

        public void RedAppleStart()
        {


            //RedContanierManager.Instance.Contanier.RegisterInstanceType<ConnectFramework.socket.IRedSocket, ConnectFramework.socket.RedWebSocket>();



        }



    }
}
