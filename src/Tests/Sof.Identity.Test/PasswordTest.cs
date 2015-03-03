using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Sof.Identity.Test
{
    [TestClass]
    public class PasswordTest
    {
        [TestMethod]
        public void HashPasswordTest()
        {
            var passwrod = "1234567890";
            var hasher = new Core.PasswordHasher();
            var hashed = hasher.HashPassword(passwrod);
            var len = hashed.Length;
            var result = hasher.VerifyHashedPassword(hashed, passwrod);
        }
    }
}
