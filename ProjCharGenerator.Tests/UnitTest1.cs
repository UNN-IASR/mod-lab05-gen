namespace ProjCharGenerator.Tests;
using generator;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        CharGenerator cg = new CharGenerator();
        string alphabet = "абвгдеёжзийклмнопрстуфхцчшщьыъэюя";
        for (int i = 0; i < 100; i++){
            char c = cg.getSym();
            Assert.IsTrue(alphabet.Contains(c));
        }
    }

    [TestMethod]
    public void TestMethod6()
    {
        CharGenerator cg = new CharGenerator();
        for (int i = 0; i < 100; i++){
            Assert.IsTrue(!string.IsNullOrEmpty(string.Concat(cg.getSym())));
        }
    }

    [TestMethod]
    public void TestMethod2()
    {
        BiCharGenerator bg = new BiCharGenerator();
        string alphabet = "абвгдеёжзийклмнопрстуфхцчшщьыъэюя";
        Assert.IsTrue(alphabet.Contains(bg.getSym(' ')));
    }

    [TestMethod]
    public void TestMethod5()
    {
        BiCharGenerator bg = new BiCharGenerator();
        Assert.IsTrue(!string.IsNullOrEmpty(string.Concat(bg.getSym(' '))));
    }

    [TestMethod]
    public void TestMethod3()
    {
        BiCharGenerator bg = new BiCharGenerator();
        string alphabet = "абвгдеёжзийклмнопрстуфхцчшщьыъэюя";
        char pr = 'a';
        for (int i = 0; i < 100; i++) {
            Assert.IsTrue(alphabet.Contains(bg.getSym(pr)));
        }
    }

    [TestMethod]
    public void TestMethod4()
    {
        WordGenerator wg = new WordGenerator();
        for (int i = 0; i < 100; i++){
            string word = wg.getWord();
            Assert.IsTrue(!string.IsNullOrEmpty(word));
        }
    }
}