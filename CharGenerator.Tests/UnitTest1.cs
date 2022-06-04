using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.IO;
using generator;

namespace TestGenerator
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test1()
        {
            bool flag = true;
            BigrammGenerator g1 = new BigrammGenerator("bigramms.txt");
            if (g1.bigramm[1, 9] != 0 || g1.bigramm[20, 5] != 30)
            {
                flag = false; 
            }
            Assert.IsTrue(flag == false);
        }
        [TestMethod]
        public void Test2()
        {
            bool flag = true;
            WordsGenerator g2 = new WordsGenerator("words.txt");
            if (g2.odds[1] != 695763 || g2.words[53] != "во")
            {
                flag = false;
            }
            Assert.IsTrue(flag == false);
        }
        [TestMethod]
        public void Test3()
        {
            bool flag = true;
            BiWordsGenerator g3 = new BiWordsGenerator("comb_words.txt");
            if (g3.odds[23] != 67202 || g3.odds[59] != 40259 || g3.words[17, 0] != "и" || g3.words[96, 1] != "образом")
            {
                flag = false;
            }
            Assert.IsTrue(flag == true);
        }
        [TestMethod]
        public void Test4()
        {
            char str = '1';
            string text;
            BigrammGenerator g1 = new BigrammGenerator("bigramms.txt");
            using (StreamWriter w = new StreamWriter("text-1.txt"))
            {

                for (int i = 0; i < 20; i++)
                {
                    str = g1.getsym(str);
                    w.Write(str);
                }
            }
            using (StreamReader f = new StreamReader("text-1.txt"))
            {
                text = f.ReadLine();
            }
            Assert.IsTrue(text.Length == 20);
        }
        [TestMethod]
        public void Test5()
        {
            string word;
            string text;
            int k = 0;
            WordsGenerator g2 = new WordsGenerator("words.txt");
            using (StreamWriter w = new StreamWriter("text-2.txt"))
            {
                for (int i = 0; i < 20; i++)
                {
                    slovo = g2.getword();
                    for (int j = 0; j < word.Length; j++)
                    {
                        w.Write(word[j]);
                        k++;
                    }
                }
            }
            using (StreamReader f = new StreamReader("text-2.txt"))
            {
                text = f.ReadLine();
            }
            Assert.IsTrue(text.Length == k);
        }
        [TestMethod]
        public void Test6()
        {
            int k = 0;
            string biwords;
            string text;
            BiWordsGenerator g3 = new BiWordsGenerator("text-3.txt");
            using (StreamWriter w = new StreamWriter("text-3.txt"))
            {
                for (int i = 0; i < 20; i++)
                {
                    paraslov = g3.getbiwors();
                    for (int j = 0; j < biwords.Length; j++)
                    {
                        w.Write(biwords[j]);
                        k++;
                    }
                }
            }
            using (StreamReader f = new StreamReader("text-3.txt"))
            {
                text = f.ReadLine();
            }
            Assert.IsTrue(text.Length == k);
        }
    }
}