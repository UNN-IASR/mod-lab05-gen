using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ProjCharGenerator.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1Async()
        {
            string result = "";
            DoubleCharGenerator gen = new DoubleCharGenerator();
            await gen.ReadTextFromFileAsync("DoubleCharTest.txt");
            SortedDictionary<char, int> stat = new SortedDictionary<char, int>();
            for (int i = 0; i < 30; i++)
            {
                char ch = gen.getSym();
                if (stat.ContainsKey(ch))
                    stat[ch]++;
                else
                    stat.Add(ch, 1);
                result += ch;
            }
            Assert.IsTrue(result.Equals("нанананананананананананананана"));
        }
        [TestMethod]
        public async Task TestMethod2Async()
        {
            string result = "";
            DoubleCharGenerator gen = new DoubleCharGenerator();
            await gen.ReadTextFromFileAsync("DoubleCharTest1.txt");
            SortedDictionary<char, int> stat = new SortedDictionary<char, int>();
            for (int i = 0; i < 30; i++)
            {
                char ch = gen.getSym();
                if (stat.ContainsKey(ch))
                    stat[ch]++;
                else
                    stat.Add(ch, 1);
                result += ch;
            }
            Assert.IsTrue(result.Equals("лалалалалалалалалалалалалалала"));
        }
        [TestMethod]
        public async Task TestMethod3Async()
        {
            string result = "";
            WordGenerator gen = new WordGenerator();
            await gen.ReadTextFromFileAsync("WordGeneratorTest.txt");
            SortedDictionary<string, int> stat = new SortedDictionary<string, int>();
            for (int i = 0; i < 5; i++)
            {
                string word = gen.getSym();
                if (stat.ContainsKey(word))
                    stat[word]++;
                else
                    stat.Add(word, 1); result += word + " ";
            }
            Assert.IsTrue(result.Equals("может может может может может "));
        }
        [TestMethod]
        public async Task TestMethod4Async()
        {
            string result = "";
            WordGenerator gen = new WordGenerator();
            await gen.ReadTextFromFileAsync("WordGeneratorTest1.txt");
            SortedDictionary<string, int> stat = new SortedDictionary<string, int>();
            for (int i = 0; i < 5; i++)
            {
                string word = gen.getSym();
                if (stat.ContainsKey(word))
                    stat[word]++;
                else
                    stat.Add(word, 1); result += word + " ";
            }
            Assert.IsTrue(result.Equals("их их их их их "));
        }
        [TestMethod]
        public async Task TestMethod5Async()
        {
            string result = "";
            DoubleWordGenerator gen = new DoubleWordGenerator();
            await gen.ReadTextFromFileAsync("DoubleGeneratorTest.txt");
            SortedDictionary<string, int> stat = new SortedDictionary<string, int>();
            for (int i = 0; i < 8; i++)
            {
                string word = gen.getSym();
                if (stat.ContainsKey(word))
                    stat[word]++;
                else
                    stat.Add(word, 1); result += word + " ";
            }
            Assert.IsTrue(result.Equals("не знаю не знаю не знаю не знаю не знаю не знаю не знаю не знаю "));
        }
        [TestMethod]
        public async Task TestMethod6Async()
        {
            string result = "";
            DoubleWordGenerator gen = new DoubleWordGenerator();
            await gen.ReadTextFromFileAsync("DoubleGeneratorTest1.txt");
            SortedDictionary<string, int> stat = new SortedDictionary<string, int>();
            for (int i = 0; i < 8; i++)
            {
                string word = gen.getSym();
                if (stat.ContainsKey(word))
                    stat[word]++;
                else
                    stat.Add(word, 1); result += word + " ";
            }
            Assert.IsTrue(result.Equals("один из один из один из один из один из один из один из один из "));
        }
    }
}
