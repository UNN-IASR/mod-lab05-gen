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
            BigrammGenerator bg = new BigrammGenerator("tables/BG.txt", "res1.txt");
            string str = bg.GetCharsUsingBG();
            Assert.IsTrue(str.Length == 1000);
        }

        [TestMethod]
        public void TestMethod2()
        {
            FreqGenerator fg = new FreqGenerator("tables/FG.txt", "res2.txt");
            string str = fg.GetTextUsingFG();
            string[] arr = str.Split(' ');
            Assert.IsTrue(arr.Length == 1000);
        }   

        [TestMethod]
        public void TestMethod3()
        {
            BiFreqGenerator bfg = new BiFreqGenerator("tables/BFG.txt", "res3.txt");
            string str = bfg.GetTextUsingBFG();
            string[] arr = str.Split(' ');
            Assert.IsTrue(arr.Length == 2000);
        }  

        [TestMethod]
        public void TestMethod4()
        {
            BigrammGenerator bg = new BigrammGenerator("tables/BG.txt", "res1.txt");
            int[][] arr = bg.GetBG();
            int max_index = 0;
            int max_value = 0;
            string syms = "абвгдежзийклмнопрстуфхцчшщыьэюя"; 
            for (int j = 0; j < arr[0].Length; j++)
            {
                if (arr[0][j] >= max_value)
                {
                    max_value = arr[0][j];
                    max_index = j;
                }
            }
            Assert.IsTrue(syms[max_index] == 'н');
        }  

        [TestMethod]
        public void TestMethod5()
        {
            FreqGenerator fg = new FreqGenerator("tables/FG.txt", "res2.txt");
            (string[] words, int[] vals) = fg.GetFG();
            Assert.IsTrue(words.Length + vals.Length == 200);
        }  

        [TestMethod]
        public void TestMethod6()
        {
            BiFreqGenerator bfg = new BiFreqGenerator("tables/BFG.txt", "res3.txt");
            (string[] words, int[] vals) = bfg.GetBFG();
            string val1 = words[0];
            string val2 = words[99];
            string str = bfg.GetTextUsingBFG();
            int amount1 = new Regex(val1).Matches(str).Count;
            int amount2 = new Regex(val2).Matches(str).Count;
            Assert.IsTrue(amount1 > amount2);
        }  
    }
}
