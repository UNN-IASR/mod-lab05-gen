using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjCharGenerator;

namespace Tests
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestBigram1()
        {
            Generator generator = new Generator("../../../../bigram.txt");
            Assert.IsNotNull(generator);
        }

        [TestMethod]
        public void TestBigram2()
        {
            Generator generator = new Generator("../../../../bigram.txt");
            Assert.AreEqual(generator.getSize(), 694);
        }

        [TestMethod]
        public void TestBigram3()
        {
            Generator generator = new Generator("../../../../bigram.txt");
            Assert.IsTrue(generator.getPartOfText().Length == 2);
        }

        [TestMethod]
        public void TestWords1()
        {
            Generator generator = new Generator("../../../../words.txt");
            Assert.IsNotNull(generator);
        }

        [TestMethod]
        public void TestWords2()
        {
            Generator generator = new Generator("../../../../words.txt");
            Assert.AreEqual(generator.getSize(), 500);
        }

        [TestMethod]
        public void TestWords3()
        {
            Generator generator = new Generator("../../../../words.txt");
            Assert.IsTrue(generator.getPartOfText().Length >= 1);
        }
    }
}
