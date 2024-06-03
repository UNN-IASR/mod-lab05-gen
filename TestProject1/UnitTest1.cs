using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            bool flag = true;
            StreamReader file = new StreamReader("BiGramm.txt");
            string str = file.ReadToEnd();
            string[] data = str.Split(" ");
            if (data.Length - 1 < 1000)
                flag = false;
            Assert.IsTrue(flag);
        }
        [TestMethod]
        public void TestMethod2()
        {
            bool flag = true;
            StreamReader file = new StreamReader("Word.txt");
            string str = file.ReadToEnd();
            string[] data = str.Split(" ");
            if (data.Length - 1 < 1000)
                flag = false;
            Assert.IsTrue(flag);
        }
        [TestMethod]
        public void TestMethod3()
        {
            bool flag = true;
            StreamReader file = new StreamReader("PairWord.txt");
            string str = file.ReadToEnd();
            string[] data = str.Split(" ");
            if (data.Length - 1 < 2000)
                flag = false;
            Assert.IsTrue(flag);
        }
        public void TestMethod4()
        {
            bool flag = true;
            if (new FileInfo("BiGramm.txt").Length == 0)
            {
                flag = false;
            }
            Assert.IsTrue(flag);
        }
        public void TestMethod5()
        {
            bool flag = true;
            if (new FileInfo("Word.txt").Length == 0)
            {
                flag = false;
            }
            Assert.IsTrue(flag);
        }
        public void TestMethod6()
        {
            bool flag = true;
            if (new FileInfo("PairWord.txt").Length == 0)
            {
                flag = false;
            }
            Assert.IsTrue(flag);
        }
    }
}
