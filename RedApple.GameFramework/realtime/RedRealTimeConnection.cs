using Newtonsoft.Json;
using RedApple.ConnectFramework.socket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedApple.GameFramework.realtime
{
    public class RedRealTimeConnection : IRedRealTimeConnection
    {
        public string _socketBaseUrl { get; set; }
        protected RedWebSocket redWebSocket;
        Dictionary<string, IRedRealTimeProxy> _proxys = new Dictionary<string, IRedRealTimeProxy>();
        protected IRedRealTimeProxy CurrentProxy { get
            {
                //TODO:her bir proxy ayrı soket bağlanabilir
                return _proxys.Select(x => x.Value).FirstOrDefault();
            } }
        public RedRealTimeConnection(string url)
        {
            this._socketBaseUrl = url;
        }

        public void Start()
        {

            redWebSocket = new RedWebSocket(this._socketBaseUrl);
            redWebSocket.OnOpen += RedWebSocket_OnOpen;
            redWebSocket.OnMessage += RedWebSocket_OnMessage;
            redWebSocket.Connect();
            //throw new NotImplementedException();
        }

        private void RedWebSocket_OnMessage(object sender, RedWebSocketMessageEventArgs e)
        {
            var red_message  = JsonConvert.DeserializeObject<ActionDataClass<string>>(e.Data);
            CurrentProxy.Trigger(red_message.Decription, red_message.Data);

           // throw new NotImplementedException();
        }

        private void RedWebSocket_OnOpen(object sender, EventArgs e)
        {
            //registerları yapabiliriz

        }

        public void SendMessage<T>(ActionDataClass<T> actionData)
        {
            if (redWebSocket.RedSocketStatus == RedSocketStatus.Opened)
                redWebSocket.SendMessage(actionData.ToString());
        }

        public IRedRealTimeProxy CreateProxy(string hubName)
        {
            RedRealTimeProxy _proxy = new RedRealTimeProxy(this);
            _proxys.Add(hubName, _proxy);
            return _proxy;
        }


    }

    public class ActionDataClass<T> : ActionDataBase
    {
        public ActionDataClass()
        {

        }
        public ActionDataClass(string description, T data)
        {
            this.Decription = description;
            this.Data = data;
        }
        public T Data { get; set; }
        // and more ....
    }

    public abstract class ActionDataBase
    {

        public string Decription { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
