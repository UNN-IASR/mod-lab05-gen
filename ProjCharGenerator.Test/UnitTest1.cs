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
            await gen.ReadTextFromFileAsync("dct1.txt");
            SortedDictionary<char, int> stat = new SortedDictionary<char, int>();
            int i = 0;
            while (i < 50)
            {
                char ch = gen.getSym();
                if (stat.ContainsKey(ch))
                    stat[ch]++;
                else
                    stat.Add(ch, 1);
                result += ch;
                i++;
            }
            Assert.IsTrue(result.Equals("яаяаяаяаяаяаяаяаяаяаяаяаяаяаяаяаяаяаяаяаяаяаяаяаяа"));
        }
        [TestMethod]
        public async Task TestMethod2Async()
        {
            string result = "";
            DoubleCharGenerator gen = new DoubleCharGenerator();
            await gen.ReadTextFromFileAsync("dct2.txt");
            SortedDictionary<char, int> stat = new SortedDictionary<char, int>();
            int i = 0;
            while (i < 50)
            {
                char ch = gen.getSym();
                if (stat.ContainsKey(ch))
                    stat[ch]++;
                else
                    stat.Add(ch, 1);
                result += ch;
                i++;
            }
            Assert.IsTrue(result.Equals("зазазазазазазазазазазазазазазазазазазазазазазазаза"));
        }
        [TestMethod]
        public async Task TestMethod3Async()
        {
            string result = "";
            WordGenerator gen = new WordGenerator();
            await gen.ReadTextFromFileAsync("wgt1.txt");
            SortedDictionary<string, int> stat = new SortedDictionary<string, int>();
            int i = 0;
            while (i < 3)
            {
                string word = gen.getSym();
                if (stat.ContainsKey(word))
                    stat[word]++;
                else
                    stat.Add(word, 1); result += word + " ";
                i++;
            }
            Assert.IsTrue(result.Equals("этом этом этом "));
        }
        [TestMethod]
        public async Task TestMethod4Async()
        {
            string result = "";
            WordGenerator gen = new WordGenerator();
            await gen.ReadTextFromFileAsync("wgt2.txt");
            SortedDictionary<string, int> stat = new SortedDictionary<string, int>();
            int i = 0;
            while (i < 3)
            {
                string word = gen.getSym();
                if (stat.ContainsKey(word))
                    stat[word]++;
                else
                    stat.Add(word, 1); result += word + " ";
                i++;
            }
            Assert.IsTrue(result.Equals("которые которые которые "));
        }
        [TestMethod]
        public async Task TestMethod5Async()
        {
            string result = "";
            DoubleWordGenerator gen = new DoubleWordGenerator();
            await gen.ReadTextFromFileAsync("dgt1.txt");
            SortedDictionary<string, int> stat = new SortedDictionary<string, int>();
            int i = 0;
            while (i < 3)
            {
                string word = gen.getSym();
                if (stat.ContainsKey(word))
                    stat[word]++;
                else
                    stat.Add(word, 1); result += word + " ";
                i++;
            }
            Assert.IsTrue(result.Equals("так что так что так что "));
        }
        [TestMethod]
        public async Task TestMethod6Async()
        {
            string result = "";
            DoubleWordGenerator gen = new DoubleWordGenerator();
            await gen.ReadTextFromFileAsync("dgt2.txt");
            SortedDictionary<string, int> stat = new SortedDictionary<string, int>();
            int i = 0;
            while (i < 3)
            {
                string word = gen.getSym();
                if (stat.ContainsKey(word))
                    stat[word]++;
                else
                    stat.Add(word, 1); result += word + " ";
                i++;
            }
            Assert.IsTrue(result.Equals("в этом в этом в этом "));
        }
    }
}
