using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCharGenerator
{
    public class CharGenerator
    {
        private string alfavit = "абвгдеёжзийклмнопрстуфхцчшщьыъэюя";
        private char[] data;
        private int size;
        private Random random = new Random();
        public CharGenerator()
        {
            size = alfavit.Length;
            data = alfavit.ToCharArray();
        }
        public char getSym()
        {
            return data[random.Next(0, size)];
        }
    }
}
