using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(File.Exists("gen-1.txt"));
            Assert.IsTrue(File.Exists("gen-2.txt"));
            Assert.IsTrue(File.Exists("gen-3.txt"));
        }

        [TestMethod]
        public void TestMethod2()
        {
            bool flag = true;
            StreamReader f = new StreamReader("gen-1.txt");
            while (f.EndOfStream)
            {
                string s = f.ReadLine();
                for (int i = 0; i < s.Length - 1; i++)
                {
                    if (s[i] == 'б' && s[i + 2] == 'б')
                    {
                        flag = false;
                    }
                }
            }
            Assert.IsTrue(flag);
        }
        [TestMethod]
        public void TestMethod3()
        {
            bool flag = true;

            if (new FileInfo("gen-1.txt").Length == 0)
            {
                flag= false;
            }
            if (new FileInfo("gen-2.txt").Length == 0)
            {
                flag = false;
            }
            if (new FileInfo("gen-3.txt").Length == 0)
            {
                flag = false;
            }
            Assert.IsTrue(flag);
        }
        [TestMethod]
        public void TestMethod4()
        {
            StreamReader f = new StreamReader("gen-2.txt");
            int count1 = 0;
            int count2 = 0;
            for (int j=0; j<10; j++)
            {
                string s = f.ReadLine();
                string[] data = s.Split(" ");
                for (int i = 0; i < data.Length; i++)
                {
                    if (data[i] == "и")
                    {
                        count1++;
                    }
                    if (data[i] == "глаз")
                    {
                        count2++;
                    }
                }
            }
            int result = count1 / count2/10;
            Assert.IsTrue(result>=2);
        }
        [TestMethod]
        public void TestMethod5()
        {
            bool flag = true;
            StreamReader f = new StreamReader("gen-3.txt");
            for (int j = 0; j < 10; j++)
            {
                string s = f.ReadLine();
                string[] data = s.Split(" ");
                for (int i = 0; i < data.Length - 1; i++)
                {
                    if (data[i] == "это" && data[i + 1] == "это")
                    {
                        flag = false;
                    }
                }
            }
            Assert.IsTrue(flag);
        }
        [TestMethod]
        public void TestMethod6()
        {
            bool flag = true;
            StreamReader f = new StreamReader("gen-2.txt");
            string s = f.ReadToEnd();
            string[] data = s.Split(" ");
            if (data.Length - 1 < 1000)
                flag = false;
            Assert.IsTrue(flag);
        }
        [TestMethod]
        public void TestMethod7()
        {
            bool flag = true;
            StreamReader f = new StreamReader("gen-1.txt");
            string s = f.ReadToEnd();
            string[] data = s.Split(" ");
            if (data.Length-1 < 1000)
                flag = false;
            Assert.IsTrue(flag);
        }
        [TestMethod]
        public void TestMethod8()
        {
            bool flag = true;
            StreamReader f = new StreamReader("gen-3.txt");
            string s = f.ReadToEnd();
            string[] data = s.Split(" ");
            if (data.Length - 1 < 2000)
                flag = false;
            Assert.IsTrue(flag);
        }
    }
}
