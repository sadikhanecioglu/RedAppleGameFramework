using RedApple.GameFramework.system;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedApple.GameFramework.realtime
{
    public sealed class RedRealTimeManager
    {

        private static readonly Lazy<RedRealTimeManager> lazy =
new Lazy<RedRealTimeManager>(() => new RedRealTimeManager());

        public static RedRealTimeManager Instance { get { return lazy.Value; } }




    }
}
