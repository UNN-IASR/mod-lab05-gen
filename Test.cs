using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace generator
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCharGenerator()
        {
            CharGenerator generator = new CharGenerator();
            char symbol = generator.getSym();
            Assert.IsTrue("абвгдеёжзийклмнопрстуфхцчшщъыьэюя".Contains(symbol.ToString()));
        }

        [TestMethod]
        public void TestCharGenerator2()
        {
            CharGenerator generator = new CharGenerator();
            char symbol = generator.getSym();
            Assert.IsFalse("abcdefghijklmnopqrstuvwxyz".Contains(symbol.ToString()));
        }

        [TestMethod]
        public void TestConstructingFromFile()
        {
            TextGenerator generator = new TextGenerator();
            generator.FileLoading("DataForGenerator2.txt");
            Assert.IsNotNull(generator);
        }

        [TestMethod]
        public void TestConstructingFromInnerData()
        {
            string[] words = { "car", "bicycle", "motorcycle", "airplane" };
            double[] values = { 0.1, 0.4, 0.7, 1.0 };
            TextGenerator generator = new TextGenerator(words, values);
            Assert.IsNotNull(generator);
        }

        [TestMethod]
        public void TestGetSymMethod()
        {
            string[] words = { "a", "b", "c", "d", "e", "f" };
            double[] values = { 0.1, 0.2, 0.3, 0.6, 0.8, 1.0 };
            TextGenerator generator = new TextGenerator(words, values);

            string sym = generator.getSym();
            Assert.IsTrue(sym == "a" || sym == "b" || sym == "c" || sym == "d" || sym == "e" || sym == "f");
        }
    }
}
