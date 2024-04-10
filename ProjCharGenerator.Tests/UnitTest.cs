using generator;

namespace ProjCharGenerator.Tests
{
    [TestClass]
    public class UnitTest
    {
        static string fileBigrams = "bigrams.csv";
        static string fileWords = "frequency_words.csv";
        static Balaboba balaboba;
        static Balaboba2_0 balaboba2_0;

        [TestInitialize]
        public void Setup()
        {
            FileHandler.BalabobaFromFile(fileBigrams, out balaboba);
            FileHandler.Balaboba2_0FromFile(fileWords, out balaboba2_0);
        }

        [TestMethod]
        public void InitBalaboba()
        {
            Assert.AreEqual(balaboba.size, balaboba.weights.Length);
        }
        [TestMethod]
        public void InitBalaboba2_0()
        {
            Assert.AreEqual(balaboba2_0.size, balaboba2_0.weights.Length);
        }
        [TestMethod]
        public void SumWeightBalabola()
        {
            Assert.AreEqual(balaboba.sum, balaboba.weights.Sum());
        }
        [TestMethod]
        public void SumWeightBalabola2_0()
        {
            Assert.AreEqual(balaboba2_0.sum, balaboba2_0.weights.Sum());
        }
        [TestMethod]
        public void PairWeightBalabola()
        {
            Assert.AreEqual("ад", balaboba.pairLetters[4]);
            Assert.AreEqual(1139097, balaboba.weights[4]);
        }
        [TestMethod]
        public void PairWeightBalabola2_0()
        {
            Assert.AreEqual("я", balaboba2_0.words[4]);
            Assert.AreEqual((int)13348.584146654037, (int)balaboba2_0.weights[4]);
        }
    }
}