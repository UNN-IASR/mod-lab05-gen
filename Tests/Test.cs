using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace generator
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestConstructingFromInnerData()
        {
            string[] words = { "car", "bicycle", "motorcycle", "airplane" };
            double[] values = { 0.1, 0.4, 0.7, 1.0 };
            TextGenerator generator = new TextGenerator(words, values);
            Assert.IsNotNull(generator);
        }
        
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
            generator.FileLoading("Data1.txt");
            Assert.IsNotNull(generator);
        }

    }
}
