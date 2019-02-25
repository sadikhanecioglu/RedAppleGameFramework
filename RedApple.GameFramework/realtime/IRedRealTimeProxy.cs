using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedApple.GameFramework.realtime
{
    public partial interface IRedRealTimeProxy
    {

        void On(string key, Action action);
        void On<T>(string key, Action<T> action);
        void Invoke<T>(string key, T data);
        void Trigger(string key, string data);
    }
}
