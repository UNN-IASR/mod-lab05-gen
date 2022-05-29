using System;
using System.Collections.Generic;

namespace generator
{
    abstract class Generator{
        protected Random random = new Random();
        public abstract string generate(int seq_len);
        public Dictionary<string, Dictionary<string, float>> parse_csv(string csv_path){
            Dictionary<string, Dictionary<string, int>> table = new Dictionary<string, Dictionary<string, int>>();
            using (Microsoft.VisualBasic.FileIO.TextFieldParser csvParser = new Microsoft.VisualBasic.FileIO.TextFieldParser(csv_path))
            {
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;
                string[] first_line = csvParser.ReadFields();
                for(int i = 1; i < first_line.Length; i++){
                    table.Add(first_line[i], new Dictionary<string, int>());
                }
                while (!csvParser.EndOfData)
                {
                    // Read current line fields, pointer moves to the next line.
                    string[] fields = csvParser.ReadFields();
                    for(int i = 1; i < fields.Length; i++){
                        table[first_line[i]].Add(fields[0], int.Parse(fields[i]));
                    }
                    string letter = fields[0];
                    string Address = fields[1];
                }
            }
            Dictionary<string, int> sums = new Dictionary<string, int>();
            
            Dictionary<string, Dictionary<string, float>> table_prob = new Dictionary<string, Dictionary<string, float>>();
            foreach(KeyValuePair<string, Dictionary<string, int>> keyvalue in table){
                table_prob.Add(keyvalue.Key, new Dictionary<string, float>());
                int sum = 0;
                foreach (var item in keyvalue.Value)
                {
                    sum += item.Value;
                }
                sums.Add(keyvalue.Key, sum);
                foreach(var item in keyvalue.Value){
                    table_prob[keyvalue.Key].Add(item.Key, (float)item.Value / sum);
                }
            }
            float res = table_prob["а"]["б"];
            return table_prob;
        }
    }
    class WordGenOneGramm: Generator{
        Dictionary<string, float> weights = new Dictionary<string, float>();
        void parse_data_txt(string data_path="data_1gramm.txt"){
            int sum = 0;
            using (Microsoft.VisualBasic.FileIO.TextFieldParser parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(data_path))
            {
                parser.SetDelimiters(new string[] { " ", "\t" });while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    sum += Int32.Parse(fields[3]);
                }
            }
            using (Microsoft.VisualBasic.FileIO.TextFieldParser parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(data_path))
            {
                parser.SetDelimiters(new string[] { " ", "\t" });
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    weights.Add(fields[1], (float)Int32.Parse(fields[3]) / sum);
                }
            }
        }
        public WordGenOneGramm(string data_path="data_1gramm.txt"){
            parse_data_txt(data_path);
        }

        public override string generate(int seq_len){
            List<string> output = new List<string>();

            for(int i = 0; i < seq_len; i++){
                if(output.Count == 0){
                    int rand_int = random.Next(0, output.Count);
                    foreach(var item in weights){
                        if (rand_int >= 0){
                            rand_int --;
                        }
                        else {
                            output.Add(item.Key);
                            break;
                        }
                    }
                } 
                else{
                    float prob = (float)random.NextDouble();  
                    float prob_sum = 0;
                    foreach(var item in weights){
                        prob_sum += item.Value;
                        if (prob_sum >= prob){
                            output.Add(item.Key);
                            break;
                        }
                    }
                }
            }
            string out_str = "";  
            foreach(var item in output){
                out_str += item + " ";
            }
            return out_str;
        }
    }
    class WordGenTwoGramm: Generator{

        Dictionary<string, float> weights = new Dictionary<string, float>();
        public WordGenTwoGramm(string data_path="data_2gramm.txt"){
            parse_data_txt();
        }
        void parse_data_txt(string data_path="data_2gramm.txt"){
            int sum = 0;
            using (Microsoft.VisualBasic.FileIO.TextFieldParser parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(data_path))
            {
                parser.SetDelimiters(new string[] { " ", "\t" });while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    sum += Int32.Parse(fields[4]);
                }
            }
            using (Microsoft.VisualBasic.FileIO.TextFieldParser parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(data_path))
            {
                parser.SetDelimiters(new string[] { " ", "\t" });
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    weights.Add(fields[1] + " " + fields[2], (float)Int32.Parse(fields[4]) / sum);
                }
            }
        }
        public override string generate(int seq_len){
            List<string> output = new List<string>();

            for(int i = 0; i < seq_len; i++){
                if(output.Count == 0){
                    int rand_int = random.Next(0, output.Count);
                    foreach(var item in weights){
                        if (rand_int >= 0){
                            rand_int --;
                        }
                        else {
                            output.Add(item.Key);
                            break;
                        }
                    }
                } 
                else{
                    float prob = (float)random.NextDouble();  
                    float prob_sum = 0;
                    foreach(var item in weights){
                        prob_sum += item.Value;
                        if (prob_sum >= prob){
                            output.Add(item.Key);
                            break;
                        }
                    }
                }
            }
            string out_str = "";  
            foreach(var item in output){
                out_str += item + " ";
            }
            return out_str;
        }
    }
    class CharGeneratorTwoGramm: Generator{
        Dictionary<string, Dictionary<string, float>> weights;
        public CharGeneratorTwoGramm(string data_path="2gramm_char.csv"){
             weights = parse_csv("2gramm_char.csv");
        }
        public override string generate(int seq_len){
            List<string> output = new List<string>();

            for(int i = 0; i < seq_len; i++){
                if(output.Count == 0){
                    int rand_int = random.Next(0, output.Count);
                    foreach(var item in weights){
                        if (rand_int >= 0){
                            rand_int --;
                        }
                        else {
                            output.Add(item.Key);
                            break;
                        }
                    }
                } 
                else{
                    float prob = (float)random.NextDouble();  
                    float prob_sum = 0;
                    foreach(var item in weights[output[output.Count - 1]]){
                        prob_sum += item.Value;
                        if (prob_sum >= prob){
                            output.Add(item.Key);
                            break;
                        }
                    }
                }
            }
            string out_str = "";  
            foreach(var item in output){
                out_str += item;
            }
            return out_str;
        }
    }
    class CharGeneratorOneGramm: Generator
    {
        private string syms = "абвгдеёжзийклмнопрстуфхцчшщьыъэюя"; 
        private char[] data;
        private int size;
        public CharGeneratorOneGramm()
        {
            Dictionary<string, Dictionary<string, float>> table_prob = parse_csv("2gramm_char.csv");
            size = syms.Length;
            data = syms.ToCharArray();
        }
        public char getSym() 
        {
           return data[random.Next(0, size)]; 
        }

        public override string generate(int seq_len){
            string output = "";
            for(int i=0; i < seq_len; i++){
                output += getSym();
            }
            return output; 
        }
    }
    
}
