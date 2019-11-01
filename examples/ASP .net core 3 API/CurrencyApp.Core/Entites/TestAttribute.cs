using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyApp.Core
{
    [AttributeUsage(AttributeTargets.Class)]
    public class EntityAuthAttribute : Attribute
    {
        public EntityAuthAttribute(string role)
        {
            Role = role;
        }

        public string Role { get; }
    }
}
