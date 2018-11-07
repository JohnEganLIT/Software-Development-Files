using Microsoft.VisualStudio.TestTools.UnitTesting;
using Security;
using System;

namespace TestSecurity {
    [TestClass]
    public class TestSecureHash {
        [TestMethod]
        public void SecureHash_DefaultIsMD5() {
            // Set up
            SecureHash hasher = new SecureHash();
            string plainText = "testing";

            // Test
            string expected = "ae2b1fca515949e5d54fb22b8ed95575";
            string actual = hasher.Compute(plainText);
            Assert.AreEqual(expected, actual,
                "[FAIL] SecureHash_DefaultIsMD5 expected [{0}], actual [{1}]", expected, actual);

            // No Teardown Required
        }

        [TestMethod]
        public void SecureHash_MD5() {
            // Set up
            SecureHash hasher = new SecureHash(SecureHash.HashType.MD5);
            string plainText = "testing";

            // Test
            string expected = "ae2b1fca515949e5d54fb22b8ed95575";
            string actual = hasher.Compute(plainText);
            Assert.AreEqual(expected, actual,
                "[FAIL] SecureHash_MD5 expected [{0}], actual [{1}]", expected, actual);

            // No Teardown Required
        }

        [TestMethod]
        public void SecureHash_Sha1() {
            // Set up
            SecureHash hasher = new SecureHash(SecureHash.HashType.SHA1);
            string plainText = "testing";

            // Test
            string expected = "dc724af18fbdd4e59189f5fe768a5f8311527050";
            string actual = hasher.Compute(plainText);
            Assert.AreEqual(expected, actual,
                "[FAIL] SecureHash_SHA1 expected [{0}], actual [{1}]", expected, actual);

            // No Teardown Required
        }

        [TestMethod]
        public void SecureHash_Sha256() {
            // Set up
            SecureHash hasher = new SecureHash(SecureHash.HashType.SHA256);
            string plainText = "testing";

            // Test
            string expected = "cf80cd8aed482d5d1527d7dc72fceff84e6326592848447d2dc0b0e87dfc9a90";
            string actual = hasher.Compute(plainText);
            Assert.AreEqual(expected, actual,
                "[FAIL] SecureHash_Sha256 expected [{0}], actual [{1}]", expected, actual);

            // No Teardown Required
        }

        [TestMethod]
        public void SecureHash_Sha512() {
            // Set up
            SecureHash hasher = new SecureHash(SecureHash.HashType.SHA512);
            string plainText = "testing";

            // Test
            string expected = "521b9ccefbcd14d179e7a1bb877752870a6d620938b28a66a107eac6e6805b9d"
                            + "0989f45b5730508041aa5e710847d439ea74cd312c9355f1f2dae08d40e41d50";
            string actual = hasher.Compute(plainText);
            Assert.AreEqual(expected, actual,
                "[FAIL] SecureHash_Sha512 expected [{0}], actual [{1}]", expected, actual);

            // No Teardown Required
        }
    }
}
