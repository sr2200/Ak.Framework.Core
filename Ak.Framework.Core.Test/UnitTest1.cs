using Ak.Framework.Core.Aspect;
using Ak.Framework.Core.Test.Aspect;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Ak.Framework.Core.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void init()
        {
            Console.WriteLine("init");
        }

        [TestMethod]
        public void TestMethod1()
        {
            var cls = AkProxy<ILogicClass>.Create(new LogicClass());
            Console.WriteLine(cls.Method("�ق��ق�"));

            List<string> logList = GetLogList();
            Assert.AreEqual("Method �����s���܂��B", logList[0]);
            Assert.AreEqual("Method �̎��s���I�����܂����B", logList[1]);
            logList.Clear();
        }

        [TestMethod]
        public void TestMethod2()
        {
            var cls = AkProxy<ILogicClass>.Create(new LogicClass());
            Console.WriteLine(cls.Method2("�ق��ق�"));

            List<string> logList = GetLogList();
            Assert.AreEqual(0, logList.Count);
            logList.Clear();
        }

        [TestMethod]
        public void TestMethod3()
        {
            var cls = AkProxy<ILogicClass>.Create(new LogicClass());
            Console.WriteLine(cls.Method3("�ق��ق�"));

            List<string> logList = GetLogList();
            Assert.AreEqual("Method3 �����s���܂��B", logList[0]);
            Assert.AreEqual("Method3 �̎��s���I�����܂����B", logList[1]);
            logList.Clear();
        }

        [TestMethod]
        public void TestMethod4()
        {
            try
            {
                var cls = AkProxy<ILogicClass>.Create(new LogicClass());
                Console.WriteLine(cls.Method4("�ق��ق�"));
                Assert.Fail();
            }
            catch (ApplicationException e)
            {
                Assert.AreEqual("TEST04", e.Message);
            }

            List<string> logList = GetLogList();
            logList.Clear();
        }

        private static List<string> GetLogList()
        {
            List<string> logList = LocalContext.GetData("AkLog") as List<string>;
            if (logList == null)
            {
                logList = new List<string>();
                LocalContext.SetData("AkLog", logList);
            }

            return logList;
        }
    }


    public interface ILogicClass
    {
        [AkAspect(true)]
        string Method(string str);

        [AkAspect(false)]
        string Method2(string str);

        string Method3(string str);

        string Method4(string str);
    }

    public class LogicClass : ILogicClass
    {
        public string Method(string str)
        {
            return "[" + str + "]�����͂���܂����B";
        }

        public string Method2(string str)
        {
            return "[" + str + "]�����͂���܂����B";
        }

        public string Method3(string str)
        {
            return "[" + str + "]�����͂���܂����B";
        }

        public string Method4(string str)
        {
            throw new ApplicationException("TEST04");
        }
    }
}
