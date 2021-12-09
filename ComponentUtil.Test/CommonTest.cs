using System;
using System.Collections.Generic;
using System.Linq;
using ComponentUtil.Common.Crypto;
using ComponentUtil.Common.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComponentUtil.Test
{
    internal enum TestEnum
    {
        [System.ComponentModel.Description("Test1")]
        Test1,

        [System.ComponentModel.Description("Test2")]
        Test2,

        [System.ComponentModel.Description("Test3")]
        Test3,
    }

    [TestClass]
    public class CommonTest
    {
        [TestMethod]
        public void TestMethod()
        {
            var list = EnumHelper.GetEnumAllItemsByReflection("ComponentUtil.Test",
                "ComponentUtil.Test.TestEnum");
            Console.WriteLine(list);
            Assert.IsTrue(list.Count == 3);
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

        [TestMethod]
        public void TestMethod3()
        {
            var test = new TestClass { A = "111", B = 222 };
            var ps = typeof(TestClass).GetProperties();
            Assert.IsTrue(ps[0].GetDescription() == "A属性");
            Assert.IsTrue((string)test.GetPropertyByName("A") == "111");
        }

        [TestMethod]
        public void TestMethod4()
        {
            var text = "TestMethod4";
            var key = "H8IhRIuJQjED/+r2chF0BfiyDu0WhoJfsS5dXL1FqwI=";
            var iv = "bJuwq6Li71HQBd5PJ+g+1Q==";
            var encryption = EncryptionHelper.Aes256Encrypt(text, iv, key);
            var decryption = EncryptionHelper.Aes256Decrypt(encryption, iv, key);
            Assert.AreEqual(text, decryption);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var date = DateTime.Parse("2021-12-01 01:01:01");
            var timeStamp = date.GetTimeStamp();
            Assert.AreEqual(timeStamp, 1638291661);
        }

        [TestMethod]
        public void TestMethod6()
        {
            Assert.IsTrue(TypeParseHelper.Convert<bool>("True"));
        }
    }
}