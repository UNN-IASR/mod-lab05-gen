using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace generator
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestConstructingFromInnerData()
        {
            string[] words = { "car", "bicycle", "motorcycle", "airplane" };
            double[] values = { 0.1, 0.4, 0.7, 1.0 };
            TextGenerator generator = new TextGenerator(words, values);
            Assert.IsNotNull(generator);
        }
    }
}
