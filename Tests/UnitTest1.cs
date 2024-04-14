using generator;

namespace Tests;

[TestClass]
public class UnitTest1
{
    public class TextGeneratorTests
    {
        [TestMethod]
        public void TestCharGenerator()
        {
            CharGenerator generator = new CharGenerator();
            char symbol = generator.getSym();
            Assert.IsTrue("абвгдеёжзийклмнопрстуфхцчшщьыъэюя".Contains(symbol.ToString()));
        }

        [TestMethod]
        public void TestConstructorWithFile()
        {
            TextGenerator generator = new TextGenerator();
            generator.LoadDataFromFile("Data1.txt");
            Assert.IsNotNull(generator);
        }

        [TestMethod]
        public void TestConstructorWithArrays()
        {
            string[] words = { "apple", "banana", "cherry" };
            double[] values = { 0.1, 0.3, 0.6 };
            TextGenerator generator = new TextGenerator(words, values);
            Assert.IsNotNull(generator);
        }

        [TestMethod]
        public void TestGetSym()
        {
            string[] words = { "a", "b", "c", "d" };
            double[] values = { 0.1, 0.3, 0.6, 1.0 };
            TextGenerator generator = new TextGenerator(words, values);

            string sym = generator.getSym();
            Assert.IsTrue(sym == "a" || sym == "b" || sym == "c" || sym == "d");
        }

        [TestMethod]
        public void TestLoadDataFromFile()
        {
            TextGenerator generator = new TextGenerator();
            generator.LoadDataFromFile("Data1.txt");
            Assert.IsTrue(generator.getSym() != null);
        }

        [TestMethod]
        public void TestGetSymAfterLoadDataFromFile()
        {
            TextGenerator generator = new TextGenerator();
            generator.LoadDataFromFile("Data1.txt");
            string sym = generator.getSym();
            Assert.IsTrue(sym != null);
        }
    }
}
