using System.ComponentModel;

namespace ComponentUtil.Test
{
    public class TestClass
    {
        [Description("A属性")] public string A { get; set; }
        [Description("B属性")] public int B { get; set; }
    }
}