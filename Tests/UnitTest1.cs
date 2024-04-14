using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            GeneratorTexta1 generator = new GeneratorTexta1();
            Assert.AreEqual(generator.firstsymbol(2), 'в');
        }
        [TestMethod]
        public void TestMethod2()
        {
            GeneratorTexta1 generator = new GeneratorTexta1();
            Assert.AreEqual(generator.kol_v_stroke(), 31);
        }   
        [TestMethod]
        public void TestMethod3()
        {
          GeneratorTexta1 generator = new GeneratorTexta1();
          generator.firstsymbol(2);
          generator.secondsymbol(2);
          Assert.AreEqual(generator.summa_veroyatnosti(2), 262);
        }  
        [TestMethod]
        public void TestMethod4()
        {
            GeneratorTexta2 generator = new GeneratorTexta2();
            generator.randomword();
            Assert.AreEqual(generator.weroyatnosti_slov.Length, 100);
        }
        [TestMethod]
        public void TestMethod5()
        {
            GeneratorTexta2 generator = new GeneratorTexta2();
            Assert.AreEqual(generator.sum(), 146497800);
        } 
        [TestMethod]
        public void TestMethod6()
        {
            GeneratorTexta2 generator = new GeneratorTexta2();
            Assert.AreEqual(generator.weroyatnosti_slov[3], 5737426);
        }
    }
}
