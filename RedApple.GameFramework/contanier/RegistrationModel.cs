using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedApple.GameFramework.contanier
{
    internal enum REG_TYPE
    {
        INSTANCE,
        SINGLETON
    };

    internal class RegistrationModel
    {
        internal Type ObjectType { get; set; }
        internal REG_TYPE RegType { get; set; }
    }
}
