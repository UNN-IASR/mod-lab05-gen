using generator;
namespace Test_lab5;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        string[] letters = new string[] { "a" };
        int[] sums = new int[] { 1 };
        Generator1 generator1 = new Generator1(letters, sums);
        var result = generator1.getStr();
        Assert.AreEqual("a", result);
    }

    [TestMethod]
    public void TestMethod2()
    {
        string[] letters = new string[] { "a", "b" };
        int[] sums = new int[] { 1, 1 };
        Generator1 generator1 = new Generator1(letters, sums);
        var result = generator1.getStr();
        Assert.IsTrue(result == "a" || result == "b");
    }

    [TestMethod]
    public void TestMethod3()
    {
        string[] letters = new string[] { "a" };
        int[] sums = new int[] { 1 };
        Generator1 generator1 = new Generator1(letters, sums);
        var result = generator1.getStr();
        Assert.IsFalse(string.IsNullOrEmpty(result));
    }

    [TestMethod]
    public void TestMethod4()
    {
        string[] letters1 = new string[] { "этот" };
        double[] sums1 = new double[] { 1.32 };
        Generator2 generator2 = new Generator2(letters1, sums1);
        var result = generator2.getStr();
        Assert.AreEqual("этот", result);
    }

    [TestMethod]
    public void TestMethod5()
    {
        string[] letters1 = new string[] { "этот", "она" };
        double[] sums1 = new double[] { 1.32, 6.91 };
        Generator2 generator2 = new Generator2(letters1, sums1);
        var result = generator2.getStr();
        Assert.IsTrue(result == "этот" || result == "она");
    }

    [TestMethod]
    public void TestMethod6()
    {
        string[] letters1 = new string[] { "этот" };
        double[] sums1 = new double[] { 1.32 };
        Generator2 generator2 = new Generator2(letters1, sums1);
        var result = generator2.getStr();
        Assert.IsFalse(string.IsNullOrEmpty(result));
    }

}