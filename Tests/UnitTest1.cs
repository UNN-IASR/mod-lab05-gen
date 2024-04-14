using generator;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void BigramGenTest1()
        {
            BigramGen bg;
            try
            {
                bg = new BigramGen();
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public void WordGenTest1()
        {
            WordGen bg;
            try
            {
                bg = new WordGen();
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public void BigramGenTest2()
        {
            BigramGen bg = new BigramGen();
            Assert.IsTrue(bg.getPair().Length == 2);
        }
        [TestMethod]
        public void WordGenTest2()
        {
            WordGen wg = new WordGen();
            Assert.IsTrue((wg.getWord().Length >= 1) && (wg.getWord().Length <= 15));
        }
        [TestMethod]
        public void BigramGenTest3()
        {
            BigramGen bg = new BigramGen();
            Assert.IsTrue(bg.Size >= 694);
        }
        [TestMethod]
        public void WordGenTest3()
        {
            WordGen wg = new WordGen();
            Assert.IsTrue(wg.Size >= 500);
        }
    }
}