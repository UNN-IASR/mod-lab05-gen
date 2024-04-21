using Microsoft.VisualStudio.TestTools.UnitTesting;
using laba5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba5.Tests
{
    [TestClass()]
    public class Laba5Test
    {
        [TestMethod()]
        public void CreatingTextTest()
        {
            CreatingText text = new("Probability.txt");
            Assert.AreEqual(text.sum, 414975024);
        }
        [TestMethod()]
        public void CreatingTextTest1()
        {
            CreatingText text = new("Probability.txt");
            Assert.AreEqual(text.Power[1], 654430);
        }
        [TestMethod()]
        public void CreatingTextTest2()
        {
            CreatingText text = new("Probability.txt");
            Assert.AreEqual(text.words[1], "аб");
        }
        [TestMethod()]
        public void CreatingTextTest3()
        {
            CreatingText text = new("Probability.txt");
            Assert.AreEqual(text.Power.Count, 694);
        }
        [TestMethod()]
        public void CreatingTextTest4()
        {
            CreatingText text = new("Probability.txt");
            Assert.AreEqual(text.Power[0], 8146);
        }
        [TestMethod()]
        public void CreatingTextTest5()
        {
            CreatingText text = new("Probability.txt");
            Assert.AreEqual(text.words[0], "aa");
        }
    }
}
