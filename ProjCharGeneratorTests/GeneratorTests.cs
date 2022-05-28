using Microsoft.VisualStudio.TestTools.UnitTesting;
using generator;
using System;
using System.Collections.Generic;
using System.Text;

namespace generator.Tests
{
    [TestClass()]
    public class GeneratorTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            BigramsGenerator gen = new BigramsGenerator();
            string str = gen.getText(500);

            Assert.IsTrue(str.Length == 500);
        }

        [TestMethod]
        public void TestMethod2()
        {
            GramsGenerator gen = new GramsGenerator();
            string str = gen.getText(500);

            Assert.IsTrue(str.Length >= 500);
        }

        [TestMethod]
        public void TestMethod3()
        {
            TwoGramsGenerator gen = new TwoGramsGenerator();
            string str = gen.getText(500);

            Assert.IsTrue(str.Length >= 500);
        }

        [TestMethod]
        public void TestMethod4()
        {
            BigramsGenerator gen = new BigramsGenerator();
            Dictionary<char, int> stat = new Dictionary<char, int>();
            for (int i = 0; i < 1000; i++)
            {
                char ch = gen.getSymbol();
                if (stat.ContainsKey(ch))
                    stat[ch]++;
                else
                    stat.Add(ch, 1);
            }

            Assert.IsTrue((stat['а'] / 1000.0) >= 0.5);
        }

        [TestMethod]
        public void TestMethod5()
        {
            GramsGenerator gen = new GramsGenerator();
            Dictionary<string, int> stat = new Dictionary<string, int>();
            for (int i = 0; i < 1000; i++)
            {
                string w = gen.getWord();
                if (stat.ContainsKey(w))
                    stat[w]++;
                else
                    stat.Add(w, 1);
            }

            Assert.IsTrue((stat["и"] / 1000.0) >= 0.1);
        }

        [TestMethod]
        public void TestMethod6()
        {
            TwoGramsGenerator gen = new TwoGramsGenerator();
            Dictionary<string, int> stat = new Dictionary<string, int>();
            for (int i = 0; i < 1000; i++)
            {
                string p = gen.getPair();
                if (stat.ContainsKey(p))
                    stat[p]++;
                else
                    stat.Add(p, 1);
            }

            Assert.IsTrue((stat["и не"] / 1000.0) >= 0.02);
        }

        [TestMethod]
        public void TestMethod7()
        {
            BigramsGenerator gen = new BigramsGenerator();
            Dictionary<char, int> stat = new Dictionary<char, int>();
            for (int i = 0; i < 1000; i++)
            {
                char ch = gen.getSymbol();
                if (stat.ContainsKey(ch))
                    stat[ch]++;
                else
                    stat.Add(ch, 1);
            }

            Assert.IsTrue((stat['щ'] / 1000.0) < 0.2 || !stat.ContainsKey('щ'));
        }

        [TestMethod]
        public void TestMethod8()
        {
            GramsGenerator gen = new GramsGenerator();
            Dictionary<string, int> stat = new Dictionary<string, int>();
            for (int i = 0; i < 1000; i++)
            {
                string w = gen.getWord();
                if (stat.ContainsKey(w))
                    stat[w]++;
                else
                    stat.Add(w, 1);
            }

            Assert.IsTrue((stat["будет"] / 1000.0) < 0.01);
        }

        [TestMethod]
        public void TestMethod9()
        {
            TwoGramsGenerator gen = new TwoGramsGenerator();
            Dictionary<string, int> stat = new Dictionary<string, int>();
            for (int i = 0; i < 1000; i++)
            {
                string p = gen.getPair();
                if (stat.ContainsKey(p))
                    stat[p]++;
                else
                    stat.Add(p, 1);
            }

            Assert.IsTrue((stat["несмотря на"] / 1000.0) < 0.01);
        }
    }
}