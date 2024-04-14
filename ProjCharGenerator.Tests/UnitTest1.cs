using generator;
// SHIFT + Ctrl + B для запуска в VS (постоянно забываю) 
namespace ProjCharGenerator.Tests
{
    [TestClass]
    public class UnitTest1 : PageTest
    {
        [TestMethod]
        public void Test_1_1()
        {
            CharGenerator gen0 = new CharGenerator();
            string alf = "абвгдеёжзийклмнопрстуфхцчшщьыъэюя";

            for (int i = 0; i < 100; i++)
            {
                Assert.IsFalse(!alf.Contains(gen0.getSym()));
            }
        }

        [TestMethod]
        public void Test_1_2()
        {
            CharGenerator gen0 = new CharGenerator();
            for (int i = 0; i < 100; i++)
            {
                Assert.IsFalse(string.IsNullOrEmpty(string.Concat(gen0.getSym())));
            }
        }

        [TestMethod] 
        public void Test_2_1()
        {
            Generator_BIgramm gen1 = new Generator_BIgramm();
            string alf = "абвгдеёжзийклмнопрстуфхцчшщьыъэюя";
            Assert.IsFalse(!alf.Contains(gen1.getSym(' ')));
        }

        [TestMethod]
        public void Test_2_2()
        {
            Generator_BIgramm gen1 = new Generator_BIgramm();
            Assert.IsFalse(string.IsNullOrEmpty(string.Concat(gen1.getSym(' '))));
        }

        [TestMethod]
        public void Test_3_1()
        {
            Generator_Words_Text gen2 = new Generator_Words_Text();
            gen2.Minimizing_and_Calculating_Summa();
            Assert.AreEqual(gen2.Summa, gen2.np[99]);
        }

        [TestMethod]
        public void Test_3_2()
        {
            Generator_Words_Text gen2 = new Generator_Words_Text();
            Assert.AreEqual(gen2.words[1], "в");
        }
    }
}
