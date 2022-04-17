using Microsoft.VisualStudio.TestTools.UnitTesting;
using generator;


namespace NET
{
    [TestClass]
    public class UnitTest1
    {
        CharGenerator gen = new CharGenerator();
        [TestMethod]
        public void TestMethod1()
        {
            string str;
            gen.BigramsReader();
            str = gen.createTextFromBigrams(100);
            Assert.IsTrue(str.Length == 200);
        }
        [TestMethod]
        public void TestMethod2()
        {
            string str;
            gen.BigramsReader(); 
            str = gen.createTextFromBigrams(15);
            Assert.IsTrue(str.Length == 30);
        }
        [TestMethod]
        public void TestMethod3()
        {
            string str;
            gen.OneWordReader();
            str = gen.createTextFromOneWord(100);
            Assert.IsTrue(str.Length > 99);
        }
        [TestMethod]
        public void TestMethod4()
        {
            string str;
            gen.OneWordReader();
            str = gen.createTextFromOneWord(500);
            Assert.IsTrue(str.Length > 499);
        }
        [TestMethod]
        public void TestMethod5()
        {
            string str;
            gen.TwoWordReader();
            str=gen.createTextFromTwoWord(50);
            Assert.IsTrue(str.Length > 99);
        }
        [TestMethod]
        public void TestMethod6()
        {
            string str;
            gen.TwoWordReader();
            str=gen.createTextFromTwoWord(100);
            Assert.IsTrue(str.Length >199);
        }
      




    }
}
