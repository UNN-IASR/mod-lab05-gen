using System;
using System.Collections.Generic;
using System.IO;

namespace generator
{
    public class BigrammGenerator
    {
        private List<List<int>> _probability;
        private readonly string _incomingFileWay;
        private readonly string _exitingFileWay;
        private readonly string _syms = "абвгдежзийклмнопрстуфхцчшщыьэюя";

        public BigrammGenerator(string incomWay, string exitWay)
        {
            _incomingFileWay = incomWay;
            _exitingFileWay = exitWay;
            _probability = new List<List<int>>();
        }

        private void GetData()
        {
            var data = File.ReadAllLines(_incomingFileWay);

            foreach (var str in data)
            {
                var probabilityChar = new List<int>();
                var splitString = str.Split(' ');

                foreach(var digit in splitString)
                {
                    probabilityChar.Add(int.Parse(digit));
                }

                _probability.Add(probabilityChar);
            }
        }

        private char GetChar(char symbol)
        {
            int index = _syms.IndexOf(symbol);
            var rand = new Random();
            var sum = 0;
            var weight = new List<int>();

            foreach (var digit in _probability[index])
            {
                sum += digit;
                weight.Add(sum);
            }

            var randomValue = rand.Next(0, sum);

            for(int i = 0; i<weight.Count; i++)
            {
                if(randomValue < weight[i])
                {
                    return _syms[i];
                }
            }

            throw new Exception();
        }

        public string GetText(int value)
        {
            GetData();
            var text = new List<char>();
            var rand = new Random();
            var symbol = _syms[rand.Next(0, _syms.Length - 1)];
            text.Add(symbol);

            for(int i = 1; i<value; i++)
            {
                text.Add(GetChar(symbol));
                symbol = text[i];
            }

            var str = new string(text.ToArray());
            File.Create(_exitingFileWay).Close();
            File.WriteAllText(_exitingFileWay, str);

            return str;
        }
    }

    public class GeneratorByFrequency
    {
        private List<int> _probability;
        private List<string> _words;
        private readonly string _incomingFileWay;
        private readonly string _exitingFileWay;

        public GeneratorByFrequency(string incomWay, string exitWay)
        {
            _incomingFileWay = incomWay;
            _exitingFileWay = exitWay;
            _probability = new List<int>();
            _words = new List<string>();
        }

        private void GetData()
        {
            var data = File.ReadAllLines(_incomingFileWay);

            foreach (var str in data)
            {
                var splitString = str.Split(' ');
                _words.Add(splitString[0]);
                _probability.Add(int.Parse(splitString[1]));
            }
        }

        private string GetWord()
        {
            var rand = new Random();
            var sum = 0;
            var weight = new List<int>();

            foreach (var digit in _probability)
            {
                sum += digit;
                weight.Add(sum);
            }

            var randomValue = rand.Next(0, sum);

            for (int i = 0; i < weight.Count; i++)
            {
                if (randomValue < weight[i])
                {
                    return _words[i] + " ";
                }
            }

            throw new Exception();
        }

        public string GetText(int value)
        {
            GetData();
            string text = "";
            var rand = new Random();

            for (int i = 0; i < value; i++)
            {
                text+=GetWord();
            }

            File.Create(_exitingFileWay).Close();
            File.WriteAllText(_exitingFileWay, text);

            return text;
        }
    }

    public class GeneratorByFrequency2
    {
        private List<int> _probability;
        private List<string> _words;
        private readonly string _incomingFileWay;
        private readonly string _exitingFileWay;

        public GeneratorByFrequency2(string incomWay, string exitWay)
        {
            _incomingFileWay = incomWay;
            _exitingFileWay = exitWay;
            _probability = new List<int>();
            _words = new List<string>();
        }

        private void GetData()
        {
            var data = File.ReadAllLines(_incomingFileWay);

            foreach (var str in data)
            {
                var splitString = str.Split('\t');
                _words.Add(splitString[0]);
                _probability.Add(int.Parse(splitString[1]));
            }
        }

        private string GetWord()
        {
            var rand = new Random();
            var sum = 0;
            var weight = new List<int>();

            foreach (var digit in _probability)
            {
                sum += digit;
                weight.Add(sum);
            }

            var randomValue = rand.Next(0, sum);

            for (int i = 0; i < weight.Count; i++)
            {
                if (randomValue < weight[i])
                {
                    return _words[i] + " ";
                }
            }

            throw new Exception();
        }

        public string GetText(int value)
        {
            GetData();
            string text = "";
            var rand = new Random();

            for (int i = 0; i < value; i++)
            {
                text += GetWord();
            }

            File.Create(_exitingFileWay).Close();
            File.WriteAllText(_exitingFileWay, text);

            return text;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var gen1 = new BigrammGenerator(".//TableProbability//Bigramm.txt", ".//res1.txt");
            gen1.GetText(1000);
            var gen2 = new GeneratorByFrequency(".//TableProbability//Frequency.txt", ".//res2.txt");
            gen2.GetText(1000);
            var gen3 = new GeneratorByFrequency2(".//TableProbability//Frequency2.txt", ".//res3.txt");
            gen3.GetText(1000);
        }
    }
}

