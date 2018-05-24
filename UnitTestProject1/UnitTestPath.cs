using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PathVerifier {
    [TestClass]
    public class UnitTestPath {
        [TestMethod]
        public void TestEmptyPath() {
            string path = "";
            InputFile file = new InputFile(path);
            string result = file.GetPathWithoutFileName();
            string expectations = "";
            Assert.AreEqual(expectations, result);
        }
        [TestMethod]
        public void TestNullPath() {
            string path = null;
            InputFile file = new InputFile(path);
            string result = file.GetPathWithoutFileName();
            string expectations = "";
            Assert.AreEqual(expectations, result);
        }
    }
}
