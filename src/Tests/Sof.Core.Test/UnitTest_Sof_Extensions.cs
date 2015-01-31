using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sof.Extensions;
using System.Text;

namespace Sof.Core.Test
{
    [TestClass]
    public class UnitTest_Sof_Extensions
    {
        [TestMethod]
        public void TestAsT()
        {
            object val1 = null;
            var val2 = "2";
            object val3 = 3;
            int val4 = 2;
            var a = val1.As<Int32?>(1).Value;
            var b = val2.As<Int32>();
            var c = val2.As<Int64>();
            var d = val4.As<Int16>();

            var dt = "2011-1-1".As<DateTime>();
            var json = new { a, b, c, d, dt }.ToJson();

            string sn = null;
            var a1 = val1.Is<int>();
            var a2 = val1.Is<Int16?>();
            var a3 = sn.Is<int>();
            var a4 = sn.Is<int?>();
        }

        [TestMethod]
        public void TestStringBuilder()
        {
            var str = "    fdsafdsa,,,,";

            var sb = new StringBuilder();
            sb.Append(str);
            sb.TrimStart();
            sb.TrimEndComma();

            str.TrimStart();
            str.TrimEnd(',');
        }
    }
}
