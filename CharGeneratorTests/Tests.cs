using Microsoft.VisualStudio.TestTools.UnitTesting;
using generator;

// الشيخ

namespace CharGeneratorTests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void BigramTestGeneric()
        {
            BigramGenerator bg = new BigramGenerator("../../../../test_data/bigram.csv");

            Assert.IsTrue(bg.GetSym() == 'а');
        }

        [TestMethod]
        public void BigramTestNoExcessiveSymbols()
        {
            BigramGenerator bg = new BigramGenerator("../../../../test_data/bigram.csv");

            for (int i = 0; i < 10000; i++)
                Assert.IsTrue(bg.GetSym() == 'а');
        }

        [TestMethod]
        public void WordGeneratorTestGeneric()
        {
            WordGenerator wg = new WordGenerator("../../../../test_data/words.csv");

            Assert.IsTrue(wg.GetSym() == 'м');
            Assert.IsTrue(wg.GetSym() == 'е');
            Assert.IsTrue(wg.GetSym() == 'н');
            Assert.IsTrue(wg.GetSym() == 'я');
            Assert.IsTrue(wg.GetSym() == ' ');

            Assert.IsTrue(wg.GetSym() == 'м');
            Assert.IsTrue(wg.GetSym() == 'е');
            Assert.IsTrue(wg.GetSym() == 'н');
            Assert.IsTrue(wg.GetSym() == 'я');
            Assert.IsTrue(wg.GetSym() == ' ');
        }

        [TestMethod]
        public void WordGeneratorTestAbnormal() // Все веса установлены в нули -- выбирается последний элемент
        {
            WordGenerator wg = new WordGenerator("../../../../test_data/words2.csv");

            Assert.IsTrue(wg.GetSym() == 'к');
            Assert.IsTrue(wg.GetSym() == 'о');
            Assert.IsTrue(wg.GetSym() == 'т');
            Assert.IsTrue(wg.GetSym() == 'о');
            Assert.IsTrue(wg.GetSym() == 'р');
            Assert.IsTrue(wg.GetSym() == 'ы');
            Assert.IsTrue(wg.GetSym() == 'й');
            Assert.IsTrue(wg.GetSym() == ' ');
        }

        [TestMethod]
        public void WordPairGeneratorTestGeneric()
        {
            WordGenerator wg = new WordGenerator("../../../../test_data/word_pairs.csv");

            Assert.IsTrue(wg.GetSym() == 'в');
            Assert.IsTrue(wg.GetSym() == ' ');
            Assert.IsTrue(wg.GetSym() == 'р');
            Assert.IsTrue(wg.GetSym() == 'о');
            Assert.IsTrue(wg.GetSym() == 'с');
            Assert.IsTrue(wg.GetSym() == 'с');
            Assert.IsTrue(wg.GetSym() == 'и');
            Assert.IsTrue(wg.GetSym() == 'и');
            Assert.IsTrue(wg.GetSym() == ' ');
            Assert.IsTrue(wg.GetSym() == 'в');
            Assert.IsTrue(wg.GetSym() == ' ');
            Assert.IsTrue(wg.GetSym() == 'р');
            Assert.IsTrue(wg.GetSym() == 'о');
        }

        [TestMethod]
        public void WordPairGeneratorTestAbnormal() // Все веса установлены в нули -- выбирается последний элемент
        {
            WordGenerator wg = new WordGenerator("../../../../test_data/word_pairs2.csv");

            Assert.IsTrue(wg.GetSym() == 'н');
            Assert.IsTrue(wg.GetSym() == 'е');
            Assert.IsTrue(wg.GetSym() == 'с');
            Assert.IsTrue(wg.GetSym() == 'м');
            Assert.IsTrue(wg.GetSym() == 'о');
            Assert.IsTrue(wg.GetSym() == 'т');
            Assert.IsTrue(wg.GetSym() == 'р');
            Assert.IsTrue(wg.GetSym() == 'я');
            Assert.IsTrue(wg.GetSym() == ' ');
            Assert.IsTrue(wg.GetSym() == 'н');
            Assert.IsTrue(wg.GetSym() == 'а');
            Assert.IsTrue(wg.GetSym() == ' ');
        }
    }
}
