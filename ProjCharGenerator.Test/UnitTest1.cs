using Microsoft.VisualStudio.TestTools.UnitTesting;
using generator;
using System.Collections.Generic;
using System.IO;

//党的耻辱

namespace ProjCharGenerator.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            BigramGenerator generator = new BigramGenerator("../../../../sources/BG.txt");
            int rows = generator.chWeights.GetUpperBound(0) + 1;
            Assert.IsTrue(rows == generator.syms.Length);
        }
        [TestMethod]
        public void TestMethod2()
        {
            BigramGenerator generator = new BigramGenerator("../../../../sources/BG.txt");
            int weightOfChar = generator.getSumOfWeightOfCurrentCh('п');
            Assert.IsTrue(weightOfChar == 134);
        }
        [TestMethod]
        public void TestMethod3()
        {
            BigramGenerator generator = new BigramGenerator("../../../../sources/BG.txt");
            List<char> possibleValues = new List<char>("аеилнорсуыя".ToCharArray());
            char receivedValue = generator.getNextCh('п');
            Assert.IsTrue(possibleValues.Contains(receivedValue));
        }
        [TestMethod]
        public void TestMethod4()
        {
            BigramGenerator generator = new BigramGenerator("../../../../sources/BG.txt");
            Program.writeToFile("tests/BigramGeneratorTest.txt", generator);
            string[] s = File.ReadAllLines("../../../../work_results/tests/BigramGeneratorTest.txt");
            string receivedValue = s[0];
            Assert.IsTrue(receivedValue.Length >= 1000);
        }
        [TestMethod]
        public void TestMethod5()
        {
            WordGenerator generator1 = new WordGenerator("../../../../sources/Words.txt");
            int count = generator1.wordsInSample.Count;
            Assert.IsTrue(count == 100);
        }
        [TestMethod]
        public void TestMethod6()
        {
            string[] strAfterSplit = { "и", "7416716" };
            Word expected = new Word(strAfterSplit);
            WordGenerator generator = new WordGenerator("../../../../sources/Words.txt");
            Word comparison = generator.wordsInSample[0];
            Assert.IsTrue((expected.word == comparison.word) && (expected.weight == comparison.weight));
        }
        [TestMethod]
        public void TestMethod7()
        {
            WordGenerator generator = new WordGenerator("../../../../sources/Words.txt");
            Program.writeToFile("tests/WordGeneratorTest.txt", generator);
            string[] s = File.ReadAllLines("../../../../work_results/tests/WordGeneratorTest.txt");
            string[] receivedValue = s[0].Split(" ");
            Assert.IsTrue(receivedValue.Length >= 1000);
        }
        [TestMethod]
        public void TestMethod8()
        {
            WordBigramGenerator generator = new WordBigramGenerator("../../../../sources/WB.txt");
            int count = generator.wordsInSample.Count;
            Assert.IsTrue(count == 100);
        }
        [TestMethod]
        public void TestMethod9()
        {
            string[] strAfterSplit = { "и", "не", "201352" };
            WordBigram expected = new WordBigram(strAfterSplit);
            WordBigramGenerator generator = new WordBigramGenerator("../../../../sources/WB.txt");
            WordBigram comparison = generator.wordsInSample[0];
            Assert.IsTrue((expected.firstWord == comparison.firstWord) && (expected.secondWord == comparison.secondWord) && (expected.weight == comparison.weight));
        }
        [TestMethod]
        public void TestMethod10()
        {
            WordBigramGenerator generator = new WordBigramGenerator("../../../../sources/WB.txt");
            List<WordBigram> wordBigrams;
            int sumOfList;
            generator.getWordsWhichStartsWithLastWord("в", out wordBigrams, out sumOfList);
            Assert.IsTrue(wordBigrams.Count == 8 && sumOfList == 389188);
        }
        [TestMethod]
        public void TestMethod11()
        {
            WordBigramGenerator generator = new WordBigramGenerator("../../../../sources/WB.txt");
            List<WordBigram> wordBigrams;
            int sumOfList;
            generator.getWordsWhichStartsWithLastWord("в", out wordBigrams, out sumOfList);
            WordBigram result = generator.getWBByRandom(wordBigrams, 1000000000);
            Assert.IsTrue(result == null);
        }
        public void TestMethod12()
        {
            WordBigramGenerator generator = new WordBigramGenerator("../../../../sources/WB.txt");
            List<WordBigram> wordBigrams;
            int sumOfList;
            generator.getWordsWhichStartsWithLastWord("в", out wordBigrams, out sumOfList);
            WordBigram result = generator.getWBByRandom(wordBigrams, 15000);
            string[] strAfterSplit = { "в", "том", "89842" };
            WordBigram expected = new WordBigram(strAfterSplit);
            Assert.IsTrue((result.firstWord == expected.firstWord) && (result.secondWord == expected.secondWord) && (result.weight == expected.weight));
        }
        [TestMethod]
        public void TestMethod13()
        {
            WordBigramGenerator generator = new WordBigramGenerator("../../../../sources/WB.txt");
            Program.writeToFile("tests/WordBigramGenerator.txt", generator);
            string[] s = File.ReadAllLines("../../../../work_results/tests/WordBigramGenerator.txt");
            string[] receivedValue = s[0].Split(" ");
            Assert.IsTrue(receivedValue.Length >= 1000);
        }
    }
}
