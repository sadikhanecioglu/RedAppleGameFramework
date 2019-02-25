using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;


namespace RedApple.ConnectFramework.www.exception
{
    public class RedAppleRequestException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public RedAppleRequestException(string message, HttpStatusCode httpStatusCode) : base(message)
        {
            this.StatusCode = httpStatusCode;
        }
    }
}
