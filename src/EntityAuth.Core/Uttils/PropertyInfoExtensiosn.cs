using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EntityAuth.Core.Uttils
{
    public static class PropertyInfoExtensiosn
    {
        public static IEnumerable<PropertyInfo> GetPropertiesWithAttribute(this Type instanceType, Type attributeType)
        {
            return instanceType.GetProperties()
                .Where(prop => Attribute.IsDefined(prop, attributeType));
        }
    }
}
