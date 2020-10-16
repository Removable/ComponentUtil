using System;
using System.Collections.Generic;
using System.Text;

namespace ComponentUtil.Common.Data
{
    public static class ReflectionHelper
    {
        public static Type GetClassByName(string name)
        {
            return Type.GetType(name);
        }
    }
}
