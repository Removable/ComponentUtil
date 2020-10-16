using System;

namespace ComponentUtil.Common.Data
{
    public static class TypeParseExtension
    {
        public static int ToInt(this object obj, int defaultVal)
        {
            try
            {
                return Convert.ToInt32(obj);
            }
            catch
            {
                return defaultVal;
            }
        }

        public static decimal ToDecimal(this object obj, decimal defaultVal)
        {
            try
            {
                return Convert.ToDecimal(obj);
            }
            catch
            {
                return defaultVal;
            }
        }
    }
}