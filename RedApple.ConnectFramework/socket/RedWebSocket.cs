using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebSocketSharp;

namespace RedApple.ConnectFramework.socket
{
    /// <summary>
    /// RedWebSocket WebSocketSharp kullanarak post ve get methodlarında web istekleri yapmamızı sağlar
    /// ref:https://github.com/sta/websocket-sharp
    /// </summary>
    public class RedWebSocket : IRedSocket
    {
        public event EventHandler OnOpen;
        public event EventHandler<RedWebSocketMessageEventArgs> OnMessage;
        public event EventHandler<RedWebSocketErrorEventArgs> OnError;
        public event EventHandler<RedWebSocketCloseEventArgs> Onclose;
        public WebSocket WebSocket;
        public RedSocketStatus RedSocketStatus;

        public string SocketUrl { get; set; }

        public RedWebSocket()
        {

        }
        public RedWebSocket(string socketUrl)
        {
            this.SocketUrl = socketUrl;


        }

        public void Close()
        {
            if (WebSocket != null && WebSocket.ReadyState == WebSocketState.Open)
                WebSocket.Close();
        }

        public void Connect()
        {
            this.RedSocketStatus = RedSocketStatus.Opening;
            WebSocket = new WebSocket(this.SocketUrl);

            if (OnOpen != null)
                WebSocket.OnOpen += OnOpenIn;
            if (OnMessage != null)
                WebSocket.OnMessage += OnMessageIn;

            if (Onclose != null)
                WebSocket.OnClose += OncloseIn;

            if (OnError != null)
                WebSocket.OnError += OnErrorIn;

            WebSocket.Connect();

        }

        private void OnMessageIn(object sender, MessageEventArgs e)
        {
            if (OnMessage != null)
                OnMessage(sender, new RedWebSocketMessageEventArgs(e.Data,e.IsBinary,e.IsPing,e.IsText,e.RawData));

        }

        private void OnErrorIn(object sender, ErrorEventArgs e)
        {
            if (OnError != null)
                OnError(sender,new RedWebSocketErrorEventArgs(e.Exception,e.Message));
        }

        private void OncloseIn(object sender, CloseEventArgs e)
        {
            this.RedSocketStatus = RedSocketStatus.Closing;
            if (Onclose != null)
                Onclose(sender, new RedWebSocketCloseEventArgs(e.Code,e.Reason,e.WasClean));

            this.RedSocketStatus = RedSocketStatus.Closed;
        }

        private void OnOpenIn(object sender, EventArgs e)
        {
            this.RedSocketStatus = RedSocketStatus.Opened;
            if (OnOpen != null)
                OnOpen(sender, e);
        }

        public void Dispose()
        {
            if (WebSocket is IDisposable)
                ((IDisposable)WebSocket).Dispose();
        }

        public void SendMessage(string message)
        {
            if (this.RedSocketStatus == RedSocketStatus.Opened)
                WebSocket.Send(message);

        }
    }

    public class SocketSetting
    {

    }
    public enum RedSocketStatus
    {
        Null,
        Opened,
        Opening,
        Closing,
        Closed
    }

    public class RedWebSocketMessageEventArgs:EventArgs
    {
        public string Data { get; set; }
        public RedWebSocketMessageEventArgs(string Data,bool IsBinary,bool IsPing,bool IsText,byte[] RawData)
        {
            this.Data = Data;
        }
    }
    public class RedWebSocketErrorEventArgs:EventArgs
    {
        public Exception Exception { get; set; }
        public string Message { get; set; }

        public RedWebSocketErrorEventArgs(Exception Exception, string Message)
        {
            this.Exception = Exception;
            this.Message = Message;
        }
    }
    public class RedWebSocketCloseEventArgs:EventArgs
    {

        public RedWebSocketCloseEventArgs(ushort Code,string Reason,bool WasClean)
        {

        }
    }


}
