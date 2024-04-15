using Generator;

namespace UnitTests
{
    [TestClass]
    public class BetterWordsGeneratorTests
    {
        BetterWordsGenerator generator;

        public BetterWordsGeneratorTests()
        {
            generator = new BetterWordsGenerator("testBigrams.txt", new Random(1));
        }

        [TestMethod]
        public void GenerateOneBigram()
        {
            Assert.AreEqual("aa", generator.Generate(1));
        }

        [TestMethod]
        public void GenerateTwoBigrams()
        {
            Assert.AreEqual("aaaa", generator.Generate(2)); 
        }

        
        [TestMethod]
        public void GenerateThreeBigrams()
        {
            Assert.AreEqual("aaaaaa", generator.Generate(3));
        }

        [TestMethod]
        public void Generate_NegativeCount_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => generator.Generate(-1));
        }
    }
}