using ProjCharGenerator;
using System.Reflection.Emit;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            BigramGenerator generator = new BigramGenerator("../../../test1.txt");
            Assert.AreEqual(generator.stat.Count, 0);
        }

        [TestMethod]
        public void TestMethod2()
        {
            BigramGenerator generator = new BigramGenerator("../../../test2.txt");
            Assert.AreEqual(generator.stat.Count, 2);
        }
        [TestMethod]
        public void TestMethod3()
        {
            BigramGenerator generator = new BigramGenerator("../../../test2.txt");
            Assert.AreEqual(generator.sum, 3);
        }

        [TestMethod]
        public void TestMethod4()
        {
            WordGenerator generator = new WordGenerator("../../../test1.txt");
            Assert.AreEqual(generator.stat.Count, 0);
        }

        [TestMethod]
        public void TestMethod5()
        {
            WordGenerator generator = new WordGenerator("../../../test3.txt");
            Assert.AreEqual(generator.stat.Count, 2);
        }
        [TestMethod]
        public void TestMethod6()
        {
            WordGenerator generator = new WordGenerator("../../../test3.txt");
            Assert.AreEqual(generator.sum, 3);

        }
    }
}