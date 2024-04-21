using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjCharGenerator;

namespace UnitTests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Generator generator = new Generator("bigram.txt");
            Assert.IsNotNull(generator);
        }
    }
}
