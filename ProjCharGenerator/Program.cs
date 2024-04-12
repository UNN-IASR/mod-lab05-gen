using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace generator {
    public class CharGenerator {
        public Dictionary<string, int> chars { get; private set; }
        public int sum { get; private set; }
        private Random rand;
        private string mode;
        public CharGenerator(Dictionary<string, int> _source, string _mode = "", int _seed = 0) {
            chars = _source;
            rand = _seed == 0 ? new Random() : new Random(_seed);
            mode = _mode;
        }
        public CharGenerator(string _source, string _mode = "", int _seed = 0) {
            string[] lines = File.ReadAllLines(_source);
            chars = lines.Select(x => x.Split())
                         .Select(x => new KeyValuePair<string, int>(x[0], sum += int.Parse(x[1])))
                         .ToDictionary();
            rand = _seed == 0 ? new Random() : new Random(_seed);
            mode = _mode;
        }
        public string genToken() {
            int r = rand.Next(sum);
            return chars.SkipWhile(x => x.Value <= r)
                        .First().Key;
        }
        public string genString(int count) {
            return string.Join(
                mode == "space" ? " " : "",
                Enumerable.Range(1, count)
                          .Select(x => genToken())
            );
        }
    }
    class Program {
        static void Main(string[] args) {
            CharGenerator charGen = new CharGenerator(_source: "input/chars.txt");
            string result = charGen.genString(1000);
            foreach (char ch in result.Distinct().Order())
                Console.WriteLine($"{ch} - {result.Where(x => x == ch).Count()}");
            File.WriteAllText("gen-0.txt", result);
            CharGenerator biGen = new CharGenerator(_source: "input/bigrams.txt");
            result = biGen.genString(1000);
            File.WriteAllText("gen-1.txt", result);
            CharGenerator textGen = new CharGenerator(_source: "input/words.txt", _mode: "space");
            result = textGen.genString(1000);
            File.WriteAllText("gen-2.txt", result);
        }
    }
} 