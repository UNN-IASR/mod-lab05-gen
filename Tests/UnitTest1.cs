using Microsoft.VisualStudio.TestTools.UnitTesting;
using generator;


namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Generator generator = new Generator(""../../../../bigram_in.txt"");
            Assert.IsTrue(generator.getSum() != 0);
        }
        [TestMethod]
        public void TestMethod2()
        {
            Generator generator = new Generator("bigram_in.txt");
            Assert.IsNotNull(generator);
        }
        [TestMethod]
        public void TestMethod3()
        {
            Generator bigram = new Generator("bigram_in.txt");
            Assert.IsTrue(bigram.getWeight(0) == 8146);
        }
        [TestMethod]
        public void TestMethod4()
        {
            Generator generator = new Generator("bigram_in.txt");
            Assert.IsTrue(generator.getSum() > 0);
        }
        [TestMethod]
        public void TestMethod5()
        {
            Generator words = new Generator("words_in.txt");
            Assert.IsTrue(words.getWord(0) == "и");
        }
        [TestMethod]
        public void TestMethod6()
        {
            Generator bigram = new Generator("bigram_in.txt");
            Assert.IsTrue(bigram.getWeight(1) == 654430);
        }
    }
}
