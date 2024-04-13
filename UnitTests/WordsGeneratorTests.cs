using generator;

namespace UnitTests
{
    [TestClass]
    public class WordsGeneratorTests
    {
        WordsGenerator generator;

        public WordsGeneratorTests()
        {
            generator = new WordsGenerator("testWords.txt", new Random(1));
        }

        [TestMethod]
        public void Generate_1_OneWord()
        {
            //Act
            var result = generator.Generate(1);

            //Assert
            Assert.AreEqual("bbb", result); // Generate(1) returns one word
        }

        [TestMethod]
        public void Generate_2_TwoWords()
        {
            //Act
            var result = generator.Generate(2);

            //Assert
            Assert.AreEqual("bbb bbb", result); // Generate(2) returns two words separated with space
        }

        [TestMethod]
        public void Generate_3_ThreeWords()
        {
            //Act
            var result = generator.Generate(3);

            //Assert
            Assert.AreEqual("bbb bbb aaa", result); // Generate(3) returns three words separated with space
        }
    }
}
