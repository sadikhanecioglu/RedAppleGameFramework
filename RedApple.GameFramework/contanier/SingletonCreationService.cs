﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedApple.GameFramework.contanier
{
    internal class SingletonCreationService
    {
        static SingletonCreationService instance = null;
        static Dictionary<string, object> objectPool = new Dictionary<string, object>();

        static SingletonCreationService()
        {
            instance = new SingletonCreationService();
        }

        private SingletonCreationService()
        { }

        public static SingletonCreationService GetInstance()
        {
            return instance;
        }

        public object GetSingleton(Type t, object[] arguments = null)
        {
            object obj = null;

            try
            {
                if (objectPool.ContainsKey(t.Name) == false)
                {
                    obj = InstanceCreationService.GetInstance().GetNewObject(t, arguments);
                    objectPool.Add(t.Name, obj);
                }
                else
                {
                    obj = objectPool[t.Name];
                }
            }
            catch
            {
                // log it maybe
            }

            return obj;
        }
    }
}
