using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedApple.GameFramework.contanier
{

    /// <summary>
    /// Custom Contanier İnterface referance : https://www.codeproject.com/Articles/1075189/Lets-write-a-Tiny-IoC-Container-to-learn-and-for-f?msg=5194025
    /// </summary>
    public interface IContainer
    {
        void RegisterInstanceType<I, C>()
            where I : class
            where C : class;

        void RegisterSingletonType<I, C>()
            where I : class
            where C : class;

        T Resolve<T>();
    }
}
