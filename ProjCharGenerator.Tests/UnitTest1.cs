using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
using System;
using generator;

namespace NET
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            BigrammGenerator bg = new BigrammGenerator("../../../../Tables/SymbolsBigramm.txt");
            string Text = bg.GenerateText();
            Assert.IsTrue(Text.Length == 1000);
        }

        [TestMethod]
        public void TestMethod2()
        {
            FreqGenerator fg = new FreqGenerator("../../../../Tables/FreqGramm.txt");
            string str = fg.GenerateText();
            string[] Text = str.Split(' ');
            Assert.IsTrue(Text.Length == 1000);
        }   

        [TestMethod]
        public void TestMethod3()
        {
            BigrammFreqGenerator bfg = new BigrammFreqGenerator("../../../../Tables/BiFreqGramm.txt");
            string str = bfg.GenerateText();
            string[] Text = str.Split(' ');
            Assert.IsTrue(Text.Length == 2000);
        }  

        [TestMethod]
        public void TestMethod4()
        {
            BigrammGenerator bg = new BigrammGenerator("../../../../Tables/SymbolsBigramm.txt");
            int[][] Bigramm = bg.PullBigrammFromFile(bg.PathToTable);
            int max_index = 0;
            int max_value = 0;
            string Alphabet = "абвгдежзийклмнопрстуфхцчшщыьэюя"; 
            for (int j = 0; j < Bigramm[0].Length; j++)
            {
                if (Bigramm[0][j] >= max_value)
                {
                    max_value = Bigramm[0][j];
                    max_index = j;
                }
            }
            Assert.IsTrue(Alphabet[max_index] == 'н');
        }  

        [TestMethod]
        public void TestMethod5()
        {
            FreqGenerator fg = new FreqGenerator("../../../../Tables/FreqGramm.txt");
            (string[] Words, int[] Weights) = fg.PullFreqFromFile(fg.PathToTable);
            Assert.IsTrue(Words.Length + Weights.Length == 200);
        }  

        [TestMethod]
        public void TestMethod6()
        {
            BigrammFreqGenerator bfg = new BigrammFreqGenerator("../../../../Tables/BiFreqGramm.txt");
            (string[] Words, int[] Weigths) = bfg.PullBigrammFromFile(bfg.PathToTable);
            string val1 = Words[0];
            string val2 = Words[99];
            string str = bfg.GenerateText();
            int amount1 = new Regex(val1).Matches(str).Count;
            int amount2 = new Regex(val2).Matches(str).Count;
            Assert.IsTrue(amount1 > amount2);
        }  
    }
}
