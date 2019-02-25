using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedApple.GameFramework.thread
{
    public class ThreadException
    {
        public Exception Exception { get; set; }
        public string Message { get; set; }

        public ThreadException(Exception ex)
        {
            this.Exception = ex;
        }

        public ThreadException(string message,Exception ex)
        {
            this.Message = message;
            this.Exception = ex;
        }
    }
}
