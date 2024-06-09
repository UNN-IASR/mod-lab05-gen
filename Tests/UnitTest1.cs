using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace generator
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test1()
        {
            Generator_char generator = new Generator_char();
            char symbol = generator.Get_symb();
            Assert.IsTrue("абвгдеёжзийклмнопрстуфхцчшщъыьэюя".Contains(symbol.ToString()));
        }

        [TestMethod]
        public void Test2()
        {
            Generator_char generator = new Generator_char();
            char symbol = generator.Get_symb();
            Assert.IsFalse("abcdefghijklmnopqrstuvwxyz".Contains(symbol.ToString()));
        }

        [TestMethod]
        public void Test3()
        {
            Generator_text generator = new Generator_text();
            generator.Data_loading("../../../../Data1.txt");
            Assert.IsNotNull(generator);
        }

        [TestMethod]
        public void Test4()
        {
            Generator_text generator = new Generator_text();
            generator.Data_loading("../../../../Data2.txt");
            Assert.IsNotNull(generator);
        }

        [TestMethod]
        public void Test5()
        {
            string[] words = { "a", "b", "c", "d", "e"};
            double[] values = { 0.1, 0.2, 0.3, 0.4, 0.5};
            Generator_text generator = new Generator_text(words, values);

            string sym = generator.Get_symb();
            Assert.IsTrue(sym == "a" || sym == "b" || sym == "c" || sym == "d" || sym == "e");
        }

        [TestMethod]
        public void Test6()
        {
            string[] words = { "word_1", "word_2", "word_3"};
            double[] values = { 0.1, 0.3, 0.5};
            Generator_text generator = new Generator_text(words, values);
            Assert.IsNotNull(generator);
        }
    }
}
