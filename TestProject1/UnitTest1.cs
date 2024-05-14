using generator;
namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_1_1()
        {
            CharGenerator gen0 = new CharGenerator();
            for (int i = 0; i < 100; i++)
            {
                Assert.IsFalse(string.IsNullOrEmpty(string.Concat(gen0.getSym())));
            }
        }

        [TestMethod]
        public void Test_1_2()
        {
            CharGenerator gen0 = new CharGenerator();
            string alf = "àáâãäå¸æçèéêëìíîïðñòóôõö÷øùüûúýþÿ";

            for (int i = 0; i < 100; i++)
            {
                Assert.IsFalse(!alf.Contains(gen0.getSym()));
            }
        }

        [TestMethod]
        public void Test_2_1()
        {
            Generator_BIgramm gen1 = new Generator_BIgramm();
            Assert.IsFalse(string.IsNullOrEmpty(string.Concat(gen1.GetSymbol(' '))));
        }

        [TestMethod]
        public void Test_2_2()
        {
            Generator_BIgramm gen1 = new Generator_BIgramm();
            string alf = "àáâãäå¸æçèéêëìíîïðñòóôõö÷øùüûúýþÿ";
            Assert.IsFalse(!alf.Contains(gen1.GetSymbol(' ')));
        }

        [TestMethod]
        public void Test_3_1()
        {
            Generator_Words_Text gen2 = new Generator_Words_Text();
            gen2.CalculateAndMinimizeSum();
            Assert.AreEqual(gen2.totalSum, gen2.upperBounds[99]);
        }

        [TestMethod]
        public void Test_3_2()
        {
            Generator_Words_Text gen2 = new Generator_Words_Text();
            Assert.AreEqual(gen2.wordList[6], "áûòü");
        }
    }
}