namespace ProjCharGenerator.Tests;

[TestClass]
public class SequenceGeneratorTest
{
    private const int TextLength = (int)1e6;

    [TestMethod]
    [DynamicData(nameof(ImpossibleCombinations), DynamicDataSourceType.Method)]
    public void ShouldNotContainImpossibleCombination(BigrammGenerator generator, string[] impossibleCombinations)
    {
        var sequenceGenerator = generator.SequenceGenerator;
        var combinations = new List<string>();
        for (var i = 0; i < TextLength; i++)
        {
            var combination = sequenceGenerator.GetNextStr();
            if (!combinations.Contains(combination))
            {
                combinations.Add(combination);
            }
        }

        foreach (var combination in impossibleCombinations)
        {
            Assert.IsFalse(combinations.Contains(combination));
        }
    }

    [TestMethod]
    [DynamicData(nameof(BigrammCombinationsData), DynamicDataSourceType.Method)]
    public void ShouldConsistCombinations_BigrammGenerator(string[] combinations)
    {
        var generator = new BigrammGenerator().SequenceGenerator;

        var frequencies = new SortedDictionary<string, bool>();
        for (var i = 0; i < TextLength; i++)
        {
            var combination = generator.GetNextStr();
            frequencies[combination] = true;
        }

        foreach (var combination in combinations)
        {
            Assert.IsTrue(frequencies[combination]);
        }
    }

    [TestMethod]
    [DynamicData(nameof(WordCombinationsData), DynamicDataSourceType.Method)]
    public void ShouldConsistCombinations_WordGenerator(string[] combinations)
    {
        var generator = new WordGenerator().SequenceGenerator;

        var frequencies = new SortedDictionary<string, bool>();
        for (var i = 0; i < TextLength; i++)
        {
            var combination = generator.GetNextStr();
            frequencies[combination] = true;
        }

        foreach (var combination in combinations)
        {
            Assert.IsTrue(frequencies[combination]);
        }
    }

    [TestMethod]
    [DynamicData(nameof(PairCombinationsData), DynamicDataSourceType.Method)]
    public void ShouldConsistCombinations_PairGenerator(string[] combinations)
    {
        var generator = new PairWordGenerator().SequenceGenerator;

        var frequencies = new SortedDictionary<string, bool>();
        for (var i = 0; i < TextLength; i++)
        {
            var combination = generator.GetNextStr();
            frequencies[combination] = true;
        }

        foreach (var combination in combinations)
        {
            Assert.IsTrue(frequencies[combination]);
        }
    }

    private static IEnumerable<object[]> ImpossibleCombinations()
    {
        yield return new object[]
        {
            new BigrammGenerator(), new[] { "АЫ", "АЬ", "ББ", "БВ", "БГ", "ДБ", "ПГ" }
        };
    }

    private static IEnumerable<object[]> BigrammCombinationsData()
    {
        yield return new object[]
        {
            new[] { "АА", "БО", "ДО", "ЖА", "ЙЗ" }
        };
    }

    private static IEnumerable<object[]> WordCombinationsData()
    {
        yield return new object[]
        {
            new[] { "а", "был", "время", "даже", "есть", "или", "кто" }
        };
    }

    private static IEnumerable<object[]> PairCombinationsData()
    {
        yield return new object[]
        {
            new[] { "а в", "в москве", "да и", "и он", "несмотря на", "что и" }
        };
    }
}