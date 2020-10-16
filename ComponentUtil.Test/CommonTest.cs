using System;
using System.Collections.Generic;
using System.Text;
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
            var a = ReflectionHelper.GetClassByName("MyEnum");
            Assert.IsTrue(a == typeof(MyEnum));
        }

        enum MyEnum
        {
            /// <summary>
            /// A
            /// </summary>
            AAA = 1,
            /// <summary>
            /// A
            /// </summary>
            BBB = 2,
        }
    }
}
