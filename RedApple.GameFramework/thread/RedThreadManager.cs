using RedApple.GameFramework.system;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RedApple.GameFramework.thread
{
    public sealed class RedThreadManager
    {

        private static readonly Lazy<RedThreadManager> lazy =
new Lazy<RedThreadManager>(() => new RedThreadManager());

        public static RedThreadManager Instance { get { return lazy.Value; } }

        public readonly List<RunedThread> RunedThreads;
        public readonly MainThreadQueue mainThreadQueue;
        public UnityMainThreadDispatcher unityMainThreadDispatcher;

        public RedThreadManager()
        {
            RunedThreads = new List<RunedThread>();
            mainThreadQueue = new MainThreadQueue();


        }

        public void SetMainThreadDispacter(UnityMainThreadDispatcher UnityMainThreadDispatcher)
        {
            this.unityMainThreadDispatcher = UnityMainThreadDispatcher;
        }

        public RunedThread AddTherad<T, RT>(string threadName, ParameterizedThreadStart threadStart, T threadParam, Action<RT> onComplateParam)
        {
            Thread thread = new Thread(threadStart);
            thread.Start(new TheradStarter<T, RT>(threadParam, onComplateParam));
            var currentthread = new RunedThread(threadName, thread);
            this.RunedThreads.Add(currentthread);
            return currentthread;
        }


        public RunedThread AddTheradPoll<T, RT>(string threadName, WaitCallback threadStart, T threadParam, Action<RT> onComplateParam)
        {
            ThreadPool.QueueUserWorkItem(threadStart, (new TheradStarter<T, RT>(threadParam, onComplateParam)));
            //Thread thread = new Thread(threadStart);
            //thread.Start(new TheradStarter<T, RT>(threadParam, onComplateParam));
            var currentthread = new RunedThread(threadName, null);
            this.RunedThreads.Add(currentthread);
            return currentthread;
        }


        public RunedThread AddMainTherad<T, RT>(string threadName, WaitCallback threadStart, T threadParam, Action<RT> onComplateParam)
        {



            ThreadPool.QueueUserWorkItem(threadStart, (new TheradStarter<T, RT>(threadParam, onComplateParam)));
            //Thread thread = new Thread(threadStart);
            //thread.Start(new TheradStarter<T, RT>(threadParam, onComplateParam));
            var currentthread = new RunedThread(threadName, null);
            this.RunedThreads.Add(currentthread);
            return currentthread;
        }


        public void Enqueue(Action action)
        {
            unityMainThreadDispatcher.Enqueue(action);
        }

    }
    class ThreadInfo
    {
        public int ThreadId;
        public MainThreadQueue MainThreadQueue;
        public int CreateCount;
    }
}
