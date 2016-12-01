using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CaesarCipher;

namespace CipherTests
{
    [TestClass]
    public class UnitTest1
    {
       /* [TestMethod]
        public void ZeroOffset()
        {
            Cipher c = new Cipher("ABC");
            c.offset = 0;
            Assert.AreEqual("ABC", c.OffsetBy(0));
        }

        [TestMethod]
        public void NonZeroOffset()
        {
            Cipher c = new Cipher("ABC");
            Assert.AreEqual(c.OffsetBy(2), c.OffsetBy(5));
            Assert.AreEqual("CAB", c.OffsetBy(5));
        }

        [TestMethod]
        public void NegativeOffset()
        {
            Cipher c = new Cipher("ABC");
            Assert.AreEqual(c.OffsetBy(2), c.OffsetBy(-1));
            Assert.AreEqual("CAB", c.OffsetBy(-1));
        }
        */

        [TestMethod]
        public void EncryptZeroOffset()
        {
            Cipher c = new Cipher("ABC");
            c.offset = 0;
            Assert.AreEqual("BABAC",c.Encrypt("BABAC"));
        }
        [TestMethod]
        public void EncryptPositiveOffset()
        {
            Cipher c = new Cipher("ABC");
            c.offset = 1;
            Assert.AreEqual("CBCBA", c.Encrypt("BABAC"));
        }

        [TestMethod]
        public void EncryptNegativeOffset()
        {
            Cipher c = new Cipher("ABC");
            c.offset = -1;
            Assert.AreEqual("ACACB", c.Encrypt("BABAC"));
        }

        [TestMethod]
        public void DecryptZeroOffset()
        {
            Cipher c = new Cipher("ABC");
            c.offset = 0;
            Assert.AreEqual("ACACB", c.Decrypt("ACACB"));
        }
        [TestMethod]
        public void DecryptPositiveOffset()// works in console test with 1... why failing test?
        {
            Cipher c = new Cipher("ABC");
            c.offset = 1;
            Assert.AreEqual("CBCBD", c.Decrypt("BABAC")); 
        }

        [TestMethod]
        public void DecryptNegativeOffset()
        {
            Cipher c = new Cipher("ABC");
            c.offset = -1;
            Assert.AreEqual("BABAC", c.Decrypt("ACACB")); 
        }
    }
}
