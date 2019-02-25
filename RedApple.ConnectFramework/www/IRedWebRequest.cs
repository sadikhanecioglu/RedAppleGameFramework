using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedApple.ConnectFramework.www
{
    public partial interface IRedWebRequest : IDisposable
    {

        string PostContentJson(string url, string jsonContent);
        T PostContentJson<T>(string url, string jsonContent);
        string Get(string url);
        T Get<T>(string url);
        void SetAuthorizedHeader(string authorizeKey, string authorizedValue);

    }
}
