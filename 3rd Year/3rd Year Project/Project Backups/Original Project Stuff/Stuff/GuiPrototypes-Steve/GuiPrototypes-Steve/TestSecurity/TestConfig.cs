using Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestSecurity {
    [TestClass]
    public class TestConfig {
        Config config;
        Logger logger;

        private void SetUp(string path) {
            logger = new Logger();
            logger.Open("TestConfig.log");

            config = new Config(@path);
            config.Load();
        }

        private void TearDown() {
        }

        [TestMethod]
        public void Config_LoadIsOk() {
            // Set up
            SetUp(@"test.json");

            // Test
            string expected = "MyValue";
            string actual = config["MyName"];
            Assert.AreEqual(expected, actual,
                "[FAIL] Config_LoadIsOk - expected [{0}], actual [{1}]", expected, actual);

            // Teardown Required
            TearDown();
        }

        [TestMethod]
        public void Config_SaveIsOk() {
            // Set up
            SetUp(@"test.json");
            config["MyName"] = "MyValue"; // hard coded config entry
            config.Save();

            Config saved = new Config(@"test.json");
            saved.Load();

            // Test
            string expected = "MyValue";
            string actual = saved["MyName"];
            Assert.AreEqual(expected, actual,
                "[FAIL] Config_SaveIsOk - expected [{0}], actual [{1}]", expected, actual);

            // Teardown Required
            TearDown();
        }

        [TestMethod]
        public void Config_LoadNoPathFails() {
            // Set up
            SetUp(@"");

            // Test
            bool expected = false;
            bool actual = config.Load();
            Assert.AreEqual(expected, actual,
                "[FAIL] Config_LoadNoPathFails - expected [{0}], actual [{1}]'", expected, actual);

            // Teardown Required
            TearDown();
        }

        [TestMethod]
        public void Config_SaveNoPathFails() {
            // Set up
            SetUp(@"");

            // Test
            bool expected = false;
            bool actual = config.Save();
            Assert.AreEqual(expected, actual,
                "[FAIL] Config_SaveNoPathFails - expected [{0}], actual [{1}]'", expected, actual);

            // Teardown Required
            TearDown();
        }

        [TestMethod]
        public void Config_NullNameIsNullValue() {
            // Set up
            SetUp(@"");
            config[null] = "Testing";

            // Test
            string expected = null;
            string actual = config[null];
            Assert.AreEqual(expected, actual,
                "[FAIL] Config_NullNameIsNullValue - expected [{0}], actual [{1}]'", expected, actual);

            // Teardown Required
            TearDown();
        }

        [TestMethod]
        public void Config_NullValueRemovesName() {
            // Set up
            SetUp(@"");
            config["Test"] = "Testing";

            // Test
            config["Test"] = null;
            string expected = null;
            string actual = config["Test"];
            Assert.AreEqual(expected, actual,
                "[FAIL] Config_NullValueRemovesName - expected [{0}], actual [{1}]'", expected, actual);

            // Teardown Required
            TearDown();
        }
    }
}
