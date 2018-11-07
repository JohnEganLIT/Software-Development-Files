using Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestSecurity {
    [TestClass]
    public class TestBlackList {
        BlackList forbid;

        private void SetUp() {
            Dictionary<string, bool> rules = new Dictionary<string, bool>();
            rules.Add("MyOrg:Delete", true);
            rules.Add("MyOrg/Production:Delete/User", true);
            rules.Add("MyOrg/Production/Worker:Delete/User", true);
            rules.Add("MyOrg/Production/Supervisor:Delete/User", false);
            forbid = new BlackList(rules);
        }

        [TestMethod]
        public void BlackList_IsBlackListed() {
            // Set up
            SetUp();
            forbid.SetUser("MyOrg", new string[] { "Production" }, "Worker", "101");

            // Test
            bool expected = true;
            bool actual = forbid["Delete/User"];
            Assert.AreEqual(expected, actual,
                "[FAIL] BlackList_IsBlackListed expected [{0}], actual [{1}]", expected, actual);

            // No Teardown Required
        }

        [TestMethod]
        public void BlackList_IsWhiteListed() {
            // Set up
            SetUp();
            forbid.SetUser("MyOrg", new string[] { "Production" }, "Supervisor", "101");

            // Test
            bool expected = false;
            bool actual = forbid["Delete/User"];
            Assert.AreEqual(expected, actual,
                "[FAIL] BlackList_IsWhiteListed expected [{0}], actual [{1}]", expected, actual);

            // No Teardown Required
        }

        [TestMethod]
        public void BlackList_NoRulesMeansAllowed() {
            // Set up
            SetUp();
            forbid.SetUser("OtherOrg", new string[] { "OtherRole" }, "OtherClass", "404");

            // Test
            bool expected = false;
            bool actual = forbid["Delete/User"];
            Assert.AreEqual(expected, actual,
                "[FAIL] BlackList_NoRulesMeansAllowed expected [{0}], actual [{1}]", expected, actual);

            // No Teardown Required
        }

        [TestMethod]
        public void BlackList_RulesCannotBeTamperredWith() {
            // Set up
            SetUp();
            forbid.SetUser("OtherOrg", new string[] { "OtherRole" }, "OtherClass", "404");

            // Test that the rule is false
            bool expected = false;
            bool before = forbid["Delete/User"];
            Assert.AreEqual(expected, before,
                "[FAIL] BlackList_RulesCannotBeTamperredWith expected [{0}], actual [{1}]", expected, before);

            // Test that a user cannot override rules
            forbid["Delete/User"] = true;
            bool after = forbid["Delete/User"];
            Assert.AreEqual(before, after,
                "[FAIL] BlackList_RulesCannotBeTamperredWith expected [{0}], actual [{1}]", before, after);

            // No Teardown Required
        }
    }
}
