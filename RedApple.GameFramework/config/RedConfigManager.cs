using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RedApple.GameFramework.system;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RedApple.GameFramework.config
{

    /// <summary>
    /// RedConfigManager Redapple Start esnasında belirten config dosyalarını içinde saklar ve erişmemizi kolaylaştırır
    /// </summary>
    public sealed class RedConfigManager
    {

        private static readonly Lazy<RedConfigManager> lazy =
 new Lazy<RedConfigManager>(() => new RedConfigManager());

        public static RedConfigManager Instance { get { return lazy.Value; } }
        private Dictionary<string, object> _store;
        public RedConfigManager()
        {
            _store = new Dictionary<string, object>();
        }


        public object GetConfigValue(string key)
        {
            return _store.SingleOrDefault(x => x.Key == key).Value;
        }
        public T GetConfigValue<T>(string key)
        {
            return (T)_store.SingleOrDefault(x => x.Key == key).Value;
        }
        public T GetConfig<T>(string key)
        {
            var jobject = GetConfigValue<JObject>(key);
            return jobject.ToObject<T>();
        }
        public void LoadConfig(string file)
        {
            string json = File.ReadAllText(file);
            _store = new Dictionary<string, object>(JsonConvert.DeserializeObject<Dictionary<string, object>>(json));


        }



    }
}
