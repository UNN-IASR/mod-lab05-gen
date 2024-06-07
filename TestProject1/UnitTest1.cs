using ProjCharGenerator;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void Test_1_1()
        {
            CharGenerator CG = new CharGenerator();
            string alf = "абвгдеёжзийклмнопрстуфхцчшщьыъэюя";

            for (int i = 0; i < 100; i++)
            {
                Assert.IsFalse(!alf.Contains(CG.getSym()));
            }
        }

        [TestMethod]
        public void Test_1_2()
        {
            CharGenerator CG = new CharGenerator();
            for (int i = 0; i < 100; i++)
            {
                Assert.IsFalse(string.IsNullOrEmpty(string.Concat(CG.getSym())));
            }
        }

        [TestMethod]
        public void Test_2_1()
        {
            Generator_BIGRAMM BI = new Generator_BIGRAMM();
            string alf = "абвгдеёжзийклмнопрстуфхцчшщьыъэюя";
            Assert.IsFalse(!alf.Contains(BI.GenerateNextSymbol(' ')));
        }

        [TestMethod]
        public void Test_2_2()
        {
            Generator_BIGRAMM BI = new Generator_BIGRAMM();
            Assert.IsFalse(string.IsNullOrEmpty(string.Concat(BI.GenerateNextSymbol(' '))));
        }

        [TestMethod]
        public void Test_3_1()
        {
            WordGenerator gW2 = new WordGenerator();

            Assert.IsTrue(!gW2.frequentWordsList.Contains("кровать"));
        }

        [TestMethod]
        public void Test_3_2()
        {
            WordGenerator gW2 = new WordGenerator();
            Assert.AreEqual(gW2.frequentWordsList[1], "в");
        }
        
    }
}
