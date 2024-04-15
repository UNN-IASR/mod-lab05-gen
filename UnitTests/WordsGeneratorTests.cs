using Generator;

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
        public void GenerateOneWord()
        {
            Assert.AreEqual("a", generator.Generate(1));
        }

        [TestMethod]
        public void GenerateTwoWords()
        {
            Assert.AreEqual("a a", generator.Generate(2));
        }

         [TestMethod]
        public void GenerateThreeWords()
        {
            Assert.AreEqual("a a a", generator.Generate(3));
        }
      
    }
}
