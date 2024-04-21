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
    public class CreatingTextTests
    {
        [TestMethod()]
        public void CreatingTextTest()
        {
            CreatingText text = new CreatingText("Probability.txt");
            Assert.AreEqual(text.sum, 414975024);
            //Assert.Fail();
        }
    }
}
