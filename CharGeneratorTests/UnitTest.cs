using generator;

namespace CharGeneratorTests;

[TestClass]
public class UnitTest {
    Dictionary<string, int> dict = new Dictionary<string, int> {
            {"one", 11}, {"two", 22}, {"three", 33}
    };
    string path = "../../../../input/";
    [TestMethod]
    public void GeneratorCreate() {
        CharGenerator gen = new CharGenerator(_source: dict);
        Assert.AreEqual(3, gen.chars.Count());
    }
    [TestMethod]
    public void GeneratorCreateEmpty() {
        CharGenerator gen = new CharGenerator(_source: new Dictionary<string, int>());
        Assert.AreEqual(0, gen.chars.Count());
        Assert.ThrowsException<InvalidOperationException>(() => gen.genToken());
    }
    [TestMethod]
    public void CharGeneratorLoad() {
        CharGenerator chGen = new CharGenerator(_source: path + "chars.txt");
        Assert.AreEqual(33, chGen.chars.Count());
    }
    [TestMethod]
    public void CharGeneratorResult() {
        CharGenerator chGen = new CharGenerator(_source: path + "chars.txt", _seed: 12);
        Assert.AreEqual("якегубиооц", chGen.genString(10));
    }
    [TestMethod]
    public void BigrammsGeneratorLoad() {
        CharGenerator biGen = new CharGenerator(_source: path + "bigrams.txt");
        Assert.AreEqual(biGen.sum, biGen.chars.Values.ElementAt(^1));
    }
    [TestMethod]
    public void BigrammsGeneratorToken() {
        CharGenerator biGen = new CharGenerator(_source: path + "bigrams.txt");
        Assert.AreEqual(2, biGen.genToken().Length);
    }
    [TestMethod]
    public void BigrammsGeneratorResult() {
        CharGenerator biGen = new CharGenerator(_source: path + "bigrams.txt", _seed: 12);
        Assert.AreEqual("янингрвооманжнмемепр", biGen.genString(10));
    }
    [TestMethod]
    public void WordGeneratorLoad() {
        CharGenerator wordGen = new CharGenerator(_source: path + "words.txt", _mode: "space");
        Assert.AreEqual(500, wordGen.chars.Count());
    }
    [TestMethod]
    public void WordGeneratorToken() {
        CharGenerator wordGen = new CharGenerator(_source: path + "words.txt", _mode: "space", _seed: 12);
        Assert.AreEqual("знакомый", wordGen.genToken());
    }
    [TestMethod]
    public void WordGeneratorResult() {
        CharGenerator wordGen = new CharGenerator(_source: path + "words.txt", _mode: "space");
        Assert.AreEqual(10, wordGen.genString(10).Split().Length);
    }
}