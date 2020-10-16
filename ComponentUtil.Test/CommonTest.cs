using System;
using ComponentUtil.Common.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComponentUtil.Test
{
    [TestClass]
    public class CommonTest
    {
        [TestMethod]
        public void TestMethod()
        {
            var list = EnumHelper.GetEnumAllItemsByReflection("ComponentUtil.Common", "ComponentUtil.Common.Data.MyEnum");
            Console.WriteLine(list);
            Assert.IsTrue(list.Count == 2);
        }
    }
}
