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
            generator_bgramm g1 = new generator_bgramm("../../../tab/bigramm.txt");
            if (g1.bgramm[2, 5] != 32 || g1.bgramm[11, 19] != 6 || g1.bgramm[19, 5] != 2)
                flag = false;
            Assert.IsTrue(flag == true);
        }
        [TestMethod]
        public void Test2()
        {
            bool flag = true;
            generator_chast_slov g2 = new generator_chast_slov("../../../tab/ch_1_slovo.txt");
            if (g2.ver[31] != 442198 || g2.ver[92] != 160363 || g2.words[6] != "я" || g2.words[64] != "себя")
                flag = false;
            Assert.IsTrue(flag == true);
        }
        [TestMethod]
        public void Test3()
        {
            bool flag = true;
            generator_chast_par g3 = new generator_chast_par("../../../tab/ch_2_slovo.txt");
            if (g3.ver[23] != 67202 || g3.ver[59] != 40259 || g3.words[17, 0]!="и" || g3.words[96, 1] != "образом")
                flag = false;
            Assert.IsTrue(flag == true);
        }
        [TestMethod]
        public void Test4()
        {
            char str = '1';
            string text;
            generator_bgramm g1 = new generator_bgramm("../../../tab/bigramm.txt");
            using (StreamWriter w = new StreamWriter("../../../tab/1.txt"))
            {

                for (int i = 0; i < 20; i++)
                {
                    str = g1.getsym(str);
                    w.Write(str);
                }
            }
            using (StreamReader f = new StreamReader("../../../tab/1.txt"))
            {
                text = f.ReadLine();
            }
            Assert.IsTrue(text.Length == 20);
        }
        [TestMethod]
        public void Test5()
        {
            string slovo;
            string text;
            int k = 0;
            generator_chast_slov g2 = new generator_chast_slov("../../../tab/ch_1_slovo.txt");
            using (StreamWriter w = new StreamWriter("../../../tab/2.txt"))
            {
                for (int i = 0; i < 20; i++)
                {
                    slovo = g2.getslovo();
                    for (int j = 0; j < slovo.Length; j++)
                    {
                        w.Write(slovo[j]);
                        k++;
                    }
                }
            }
            using (StreamReader f = new StreamReader("../../../tab/2.txt"))
            {
                text = f.ReadLine();
            }
            Assert.IsTrue(text.Length == k);
        }
        [TestMethod]
        public void Test6()
        {
            int k = 0;
            string paraslov;
            string text;
            generator_chast_par g3 = new generator_chast_par("../../../tab/ch_2_slovo.txt");
            using (StreamWriter w = new StreamWriter("../../../tab/3.txt"))
            {
                for (int i = 0; i < 20; i++)
                {
                    paraslov = g3.getparslov();
                    for (int j = 0; j < paraslov.Length; j++)
                    {
                        w.Write(paraslov[j]);
                        k++;
                    }
                }
            }
            using (StreamReader f = new StreamReader("../../../tab/3.txt"))
            {
                text = f.ReadLine();
            }
            Assert.IsTrue(text.Length == k);
        }
    }
}
