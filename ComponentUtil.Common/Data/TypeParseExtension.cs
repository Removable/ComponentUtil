namespace ComponentUtil.Common.Data
{
    public static class TypeParseExtension
    {
        public static int ToInt(this object obj, int defaultVal)
        {
            return int.TryParse(obj.ToString(), out var result) ? result : defaultVal;
        }
        
        public static decimal ToDecimal(this object obj, decimal defaultVal)
        {
            return decimal.TryParse(obj.ToString(), out var result) ? result : defaultVal;
        }
    }
}