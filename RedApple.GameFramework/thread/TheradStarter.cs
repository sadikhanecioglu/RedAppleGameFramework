using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RedApple.GameFramework.thread
{

    internal class TheradStarter<T, RT>
    {
        Action<RT> OnComplate;
        Action<ThreadException> OnException;
        T RequestData;
        public T DATA
        {
            get
            {
                return RequestData;
            }
        }
        public Action<RT> Complate
        {
            get
            {
                return OnComplate;
            }
        }

        public Action<ThreadException> Error
        {
            get
            {
                return OnException;
            }
        }
        public TheradStarter(T RequestData, Action<RT> OnComplate)
        {
            this.OnComplate = OnComplate;
            this.RequestData = RequestData;

        }






    }



    public class RunedThread
    {
        public string Name { get; set; }
        public string ThreadUniqId { get; set; }
        public Thread CurrentThread { get; set; }


        public RunedThread(string threadName, Thread runThread)
        {
            this.Name = threadName;
            this.ThreadUniqId = Guid.NewGuid().ToString();
            this.CurrentThread = runThread;
        }

    }
}
