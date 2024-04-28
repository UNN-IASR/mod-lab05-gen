using CharGenerator;

namespace Generator
{
    class Program
    {
        static Random rd = new Random();
        static void Main(string[] args)
        {
            int size = 1050;
            FileSave("gen-1.txt", new BigramChar(rd).GetText(size));
            FileSave("gen-2.txt", new BigramWord(rd).GetText(size));
            FileSave("gen-3.txt", new BigramPairWord(rd).GetText(size));
        }

        static void FileSave(string path, string text)
        {
            File.WriteAllText(path, text);
        }
    }
}

