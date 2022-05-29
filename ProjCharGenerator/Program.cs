using System;

namespace generator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int seq_len = 1000;
            CharGeneratorTwoGramm gen_char = new CharGeneratorTwoGramm();
            string output_char_gen = gen_char.generate(seq_len);
            string char_gen_file_path = "char_gen_result.txt";
            System.IO.File.WriteAllText(char_gen_file_path, output_char_gen);
            WordGenOneGramm gen_onegramm = new WordGenOneGramm();
            string output_onegramm_gen = gen_onegramm.generate(seq_len);
            string gen_onegramm_file_path = "gen_onegramm_result.txt";
            System.IO.File.WriteAllText(gen_onegramm_file_path, output_onegramm_gen);
            WordGenOneGramm gen_twogramm = new WordGenOneGramm();
            string output_twogramm_gen = gen_twogramm.generate(seq_len);
            string gen_twogramm_file_path = "gen_twogramm_result.txt";
            System.IO.File.WriteAllText(gen_twogramm_file_path, output_twogramm_gen);
        }
    }
}

