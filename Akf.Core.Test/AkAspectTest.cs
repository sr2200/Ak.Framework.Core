using Akf.Core.Aspect;
using Akf.Core.Test.Aspect;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Akf.Core.Test
{
    [TestClass]
    public class AkAspectTest
    {
        [TestInitialize]
        public void Init()
        {
            Console.WriteLine("init");
        }

        [TestMethod]
        public void TestMethod1()
        {
            //var cls = AkProxy<ILogicClass>.Create(new LogicClass());
            var cls = AkAspectUtility.Create<ILogicClass>(new LogicClass());
            Console.WriteLine(cls.Method("�ق��ق�"));

            List<string> logList = GetLogList();
            Assert.AreEqual("Method �����s���܂��B", logList[0]);
            Assert.AreEqual("Method �̎��s���I�����܂����B", logList[1]);
            logList.Clear();
        }

        [TestMethod]
        public void TestMethod2()
        {
            //var cls = AkProxy<ILogicClass>.Create(new LogicClass());
            var cls = AkAspectUtility.Create<ILogicClass>(new LogicClass());
            Console.WriteLine(cls.Method2("�ق��ق�"));

            List<string> logList = GetLogList();
            Assert.AreEqual(0, logList.Count);
            logList.Clear();
        }

        [TestMethod]
        public void TestMethod3()
        {
            //var cls = AkProxy<ILogicClass>.Create(new LogicClass());
            var cls = AkAspectUtility.Create<ILogicClass>(new LogicClass());
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
                //var cls = AkProxy<ILogicClass>.Create(new LogicClass());
                var cls = AkAspectUtility.Create<ILogicClass>(new LogicClass());
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

        [TestMethod]
        public void TestMethod5()
        {

            //AkProxy.SetAspectPartsSettingHandler(new AspectPartsSettingHandler(""));
            //var cls = AkProxy<ILogicClass>.Create(new LogicClass());
            var cls = AkAspectUtility.Create<ILogicClass>(new LogicClass());
            Console.WriteLine(cls.Method("�ق��ق�"));

            List<string> logList = GetLogList();
            Assert.AreEqual("Method �����s���܂��B", logList[0]);
            Assert.AreEqual("Method �̎��s���I�����܂����B", logList[1]);
            logList.Clear();
        }

        private static List<string> GetLogList()
        {
            List<string> logList = (List<string>)LocalContext.GetData("AkLog");
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
