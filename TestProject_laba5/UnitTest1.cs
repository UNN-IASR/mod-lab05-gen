using generator;
namespace TestProject_laba5;


[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestGetSym()
    {
        CharGenerator gen = new CharGenerator();
        char sym = gen.getSym();
        Assert.IsTrue(gen.syms.Contains(sym.ToString()));
    }
    [TestMethod]
    public void TestGenerator1()
    {
        Generator1 gen1 = new Generator1();
        gen1.read_file("file1.txt");

        for (int i = 0; i < 1000; i++)
        {
            string sym = gen1.getSymm();
            Assert.IsNotNull(sym);
        }
    }
    [TestMethod]
    public void TestMetod4()
    {
        Generator1 gen = new Generator1();
        gen.read_file("test1.txt");
        var res = gen.getSymm();
        Assert.IsTrue(res == "aa");
    }
    [TestMethod]
    public void TestMetod5()
    {
        Generator1 gen = new Generator1();
        gen.read_file("test1.txt");
        var res = gen.getSymm();
        Assert.AreEqual("aa", res);
    }
    [TestMethod]
    public void TestMetod6()
    {
        Generator2 gen = new Generator2();
        gen.read_file("test2.txt");
        var res = gen.getSymm();
        Assert.IsTrue(res == "aaa" || res == "bbb");
    }
}

