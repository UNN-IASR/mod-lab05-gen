using generator;
using System.Reflection.Emit;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CorrectBigramTotal()
        {
            BigramGenerator generator = new BigramGenerator("../../../../bigrams.txt");
            Assert.AreEqual(generator.total, 414975024);
        }
        [TestMethod]
        public void CorrectBigramWeightsLength()
        {
            BigramGenerator generator = new BigramGenerator("../../../../bigrams.txt");
            Assert.AreEqual(generator.weights.Length, 694);
        }
        [TestMethod]
        public void CorrectBigramResultLength()
        {
            BigramGenerator generator = new BigramGenerator("../../../../bigrams.txt");
            Assert.IsTrue(generator.Result().Length >= 1000);
        }
        [TestMethod]
        public void CorrectWordsTotal()
        {
            WordsGenerator generator = new WordsGenerator("../../../../words.txt");
            Assert.AreEqual(generator.total, 146497800);
        }
        [TestMethod]
        public void CorrectWordsWeightsLength()
        {
            WordsGenerator generator = new WordsGenerator("../../../../words.txt");
            Assert.AreEqual(generator.weights.Length, 100);
        }
        [TestMethod]
        public void CorrectWordsResultLength()
        {
            WordsGenerator generator = new WordsGenerator("../../../../words.txt");
            Assert.IsTrue(generator.Result().Length >= 1000);
        }
    }
}