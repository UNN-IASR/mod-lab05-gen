using generator;

namespace UnitTests
{
    [TestClass]
    public class BetterCharGeneratorTests
    {
        BetterCharGenerator generator;

        public BetterCharGeneratorTests()
        {
            generator = new BetterCharGenerator("testBigrams.txt", new Random(1));
        }

        [TestMethod]
        public void Generate_1_OneBigram()
        {
            //Act
            var result = generator.Generate(1);

            //Assert
            Assert.AreEqual("aa", result); // Generate(1) returns one bigram
        }

        [TestMethod]
        public void Generate_2_TwoBigrams()
        {
            //Act
            var result = generator.Generate(2);

            //Assert
            Assert.AreEqual("aaaa", result); // Generate(2) returns two bigrams together
        }

        [TestMethod]
        public void Generate_3_ThreeBigrams()
        {
            //Act
            var result = generator.Generate(3);

            //Assert
            Assert.AreEqual("aaaaaa", result); // Generate(3) returns three bigrams together
        }
    }
}