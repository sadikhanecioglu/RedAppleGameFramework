using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebSocketSharp;

namespace RedApple.ConnectFramework.socket
{
    public partial interface IRedSocket:IDisposable
    {
        event EventHandler OnOpen;
        event EventHandler<RedWebSocketMessageEventArgs> OnMessage;
        event EventHandler<RedWebSocketErrorEventArgs> OnError;
        event EventHandler<RedWebSocketCloseEventArgs> Onclose;
        string SocketUrl { get; set; }
        void Connect();
        void Close();
        void SendMessage(string message);

    }
}
