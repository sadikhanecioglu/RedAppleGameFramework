using RedApple.GameFramework.system;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedApple.GameFramework.contanier
{

    /// <summary>
    /// RedContanierManager ReddappleGameFremawork içinde kullandığımız contanier nesnesi daha kolay yönetebilmek içindir
    /// </summary>
    public sealed class RedContanierManager
    {

        private static readonly Lazy<RedContanierManager> lazy =
new Lazy<RedContanierManager>(() => new RedContanierManager());

        public static RedContanierManager Instance { get { return lazy.Value; } }


        public Container Contanier;

        public RedContanierManager()
        {
            Contanier = new Container();
        }


    }
}
