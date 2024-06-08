using System;

namespace ProjCharGenerator
{
    public class CharGenerator
    {
        private string syms = "абвгдеёжзийклмнопрстуфхцчшщьыъэюя";
        private char[] data;
        private int size;
        private Random random = new Random();

        public CharGenerator()
        {
            size = syms.Length;
            data = syms.ToCharArray();
        }

        public char getSym()
        {
            return data[random.Next(0, size)];
        }
    }
}
