using System;
using System.Collections.Generic;
using System.Linq;
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
            var list = EnumHelper.GetEnumAllItemsByReflection("ComponentUtil.Common",
                "ComponentUtil.Common.Data.MyEnum");
            Console.WriteLine(list);
            Assert.IsTrue(list.Count == 2);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var list = new List<int>();
            for (var i = 0; i < 14; i++)
            {
                list.Add(i);
            }

            var paged = new PageData<int>(list, 2, 5);
            Assert.IsTrue(paged.PagedData.FirstOrDefault() == 5);
        }
    }
}