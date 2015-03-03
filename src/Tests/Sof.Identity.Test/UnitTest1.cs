using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sof.Identity.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var bll = new Services.UserService();
            var user = bll.FindById(1);
        }
    }
}
