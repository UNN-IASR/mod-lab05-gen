using generator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var gen = new BigrammGenerator(".//TableProbability//Bigramm.txt", ".//res1.txt");
            var str = gen.GetText(100);
            Assert.IsTrue(str.Length == 100);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var gen = new BigrammGenerator(".//TableProbability//Bigramm.txt", ".//res1.txt");
            var str = gen.GetText(400);
            Assert.IsTrue(str.Length == 400);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var gen = new GeneratorByFrequency(".//TableProbability//Frequency.txt", ".//res2.txt");
            var str = gen.GetText(100);
            Assert.IsTrue(str.Length > 100);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var gen = new GeneratorByFrequency(".//TableProbability//Frequency.txt", ".//res2.txt");
            var str = gen.GetText(400);
            Assert.IsTrue(str.Length > 400);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var gen = new GeneratorByFrequency2(".//TableProbability//Frequency2.txt", ".//res3.txt");
            var str = gen.GetText(500);
            Assert.IsTrue(str.Length > 500);
        }

        [TestMethod]
        public void TestMethod6()
        {
            var gen = new GeneratorByFrequency2(".//TableProbability//Frequency2.txt", ".//res3.txt");
            var str = gen.GetText(1000);
            Assert.IsTrue(str.Length > 1000);
        }
    }
}
