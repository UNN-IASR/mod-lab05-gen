using generator;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Read1()
        {
            FirstGenerator gen = new("testdata_1_1.txt");
        }
        [TestMethod]
        public void Gen1()
        {
            FirstGenerator gen = new("testdata_1_1.txt");
            Assert.AreEqual(gen.generateString(100).Length, 100);
        }
        [TestMethod]
        public void ShouldFail1()
        {
            Assert.ThrowsException<FileNotFoundException>(() => { new FirstGenerator("testdata_invalid.txt"); });
        }
        [TestMethod]
        public void Read2()
        {
            SecondGenerator gen = new("testdata_1_2.txt");
        }
        [TestMethod]
        public void Gen2()
        {
            SecondGenerator gen = new("testdata_1_2.txt");
            Assert.IsTrue(gen.generateString(100).Length >= 100);
        }
        [TestMethod]
        public void ShouldFail2()
        {
            Assert.ThrowsException<FileNotFoundException>(() => { new SecondGenerator("testdata_invalid.txt"); });
        }
    }
}