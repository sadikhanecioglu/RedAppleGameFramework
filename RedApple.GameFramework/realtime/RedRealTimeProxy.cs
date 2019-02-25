using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedApple.GameFramework.realtime
{
    public class RedRealTimeProxy : IRedRealTimeProxy
    {
        protected readonly RedRealTimeConnection RedRealTimeConnection;
        Dictionary<string, RegisterMethod> actions = new Dictionary<string, RegisterMethod>();
        public RedRealTimeProxy(RedRealTimeConnection RedRealTimeConnection)
        {
            this.RedRealTimeConnection = RedRealTimeConnection;
        }



        public void Invoke<T>(string key, T data)
        {
            this.RedRealTimeConnection.SendMessage<T>(new ActionDataClass<T>(key, data));
        }

        public void On<T>(string key, Action<T> action)
        {
            this.actions.Add(key, new RegisterMethod(action, typeof(T)));
        }

        public void On(string key, Action action)
        {
            this.actions.Add(key, new RegisterMethod(action));
        }

        public void Trigger(string key, string data)
        {
            RegisterMethod register;

            if (this.actions.TryGetValue(key, out register))
            {
                if (register.registerType == 0)
                {
                    var action = (Action)register.method;
                    action.Invoke();
                }
                else if (register.registerType == 1)
                {
                    var _type = register.type;
                    var action_data = JsonConvert.DeserializeObject(data, register.type);
                    var actionWithType = register.method;
                    actionWithType.DynamicInvoke(action_data);
                }

            }

        }

    }

    class RegisterMethod
    {
        public Delegate method;
        public Type type;
        public int registerType;
        public RegisterMethod(Delegate Method)
        {
            method = Method;
            registerType = 0;
        }

        public RegisterMethod(Delegate Method, Type type)
        {
            method = Method;
            this.type = type;
            registerType = 1;
        }
    }
}
