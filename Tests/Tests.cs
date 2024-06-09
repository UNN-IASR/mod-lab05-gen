using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace lab5
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestConstructing()
        {
            string[] letters = { "audi", "mazda", "bmw", "lada" };
            double[] val = { 0.05, 0.04, 0.07, 0.01 };
            TextGenerator generator = new TextGenerator(letters, val);
            Assert.IsNotNull(generator);
        }

        [TestMethod]
        public void TestChar()
        {
            CharGenerator gen = new CharGenerator();
            char s = gen.getSum();
            Assert.IsTrue("абвгдеёжзийклмнопрстуфхцчшщъыьэюя".Contains(s.ToString()));
        }

        [TestMethod]
        public void TestChar2()
        {
            CharGenerator gen = new CharGenerator();
            char s = gen.getSum();
            Assert.IsFalse("abcdefghijklmnopqrstuvwxyz".Contains(s.ToString()));
        }

        [TestMethod]
        public void TestFromFile()
        {
            TextGenerator gen = new TextGenerator();
            gen.FileLoading("../../../../Data1.txt");
            Assert.IsNotNull(gen);
        }

        [TestMethod]
        public void Test()
        {
            TextGenerator gen = new TextGenerator();
            gen.FileLoading("../../../../Data2.txt");
            Assert.IsNotNull(gen);
        }

        [TestMethod]
        public void LastTest()
        {
            string[] letters = { "a", "b", "c" };
            double[] val = { 0.02, 0.05, 0.05 };
            TextGenerator gen = new TextGenerator(letters, val);
            Assert.IsNotNull(gen);
        }
    }
}

