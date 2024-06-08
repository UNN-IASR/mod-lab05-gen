using System;
using System.Text;
using System.IO;

namespace generator
{
    public class generator_bgramm {
        public string syms = "абвгдежзийклмнопрстуфхцчшщьыэюя";
        public int[,] bgramm;
        private int[] maxbg = new int[31];
        public generator_bgramm(string file) {
            bgramm = new int[31, 31];
            using (StreamReader f = new StreamReader(file)) {
                for (int i = 0; i < 30; i++) {
                    string text = f.ReadLine();
                    string[] stroki = text.Split(new char[] { ' ' });
                    for (int j = 0; j < 30; j++)
                    {
                        bgramm[i, j] = Int32.Parse(stroki[j]);
                    }
                }
            }
            for (int i = 0; i < 30; i++)
                for (int j = 0; j < 30; j++)
                    if (maxbg[i] < bgramm[i, j])
                        maxbg[i] = bgramm[i, j];
        }
        public char getsym(char s) {
            Random random = new Random();
            if (s == '1')
                s = syms[random.Next(0, 31)];
            int i = syms.IndexOf(s);
            int j = 0;
            int r = random.Next(0, maxbg[i]);
            while (true) {
                j = random.Next(0, 31);
                if (r < bgramm[i, j])
                    break;
            }
            return syms[j];
        }
    }
    public class generator_chast_slov {
        public string[] words;
        public int[] ver;
        private int maxver;
        public generator_chast_slov(string file)
        {
            ver = new int[100];
            words = new string[100];
            using (StreamReader f = new StreamReader(file))
            {
                for (int i = 0; i < 100; i++)
                {
                    string text = f.ReadLine();
                    string[] stroka = text.Split(new Char[] { ' ' });
                    words[i] = stroka[0];
                    ver[i] = Int32.Parse(stroka[1]);
                }
                maxver = ver[0];
            }
        }
        public string getslovo() {
            Random random = new Random();
            int r = random.Next(0, maxver);
            int i;
            while (true) {
                i = random.Next(0, 100);
                if (r < ver[i])
                    break;
            }
            return words[i];
        }
    }
    public class generator_chast_par {
        public string[,] words;
        public int[] ver;
        private int maxver;
        public generator_chast_par(string file) {
            words = new string[100, 2]; 
            ver = new int[100];
            
            using (StreamReader f = new StreamReader(file))
            {
                for (int i = 0; i < 100; i++) {
                    string text = f.ReadLine();
                    string[] stroka = text.Split(new Char[] { ' ' });
                    words[i, 0] = stroka[0];
                    words[i, 1] = stroka[1];
                    ver[i] = Int32.Parse(stroka[2]);
                }
                maxver = ver[0];
            }
        }
        public string getparslov() {
            Random random = new Random();
            int r = random.Next(0, maxver);
            int i;
            while (true)
            {
                i = random.Next(0, 100);
                if (r < ver[i])
                    break;
            }
            return (words[i, 0]+" "+words[i, 1]);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int m = random.Next(0, 31);
            char str = '1';
            string slovo;
            string paraslov;

            generator_bgramm g1 = new generator_bgramm("../../../tab/bigramm.txt");
            generator_chast_slov g2 = new generator_chast_slov("../../../tab/ch_1_slovo.txt");
            generator_chast_par g3 = new generator_chast_par("../../../tab/ch_2_slovo.txt");

            using (StreamWriter w = new StreamWriter("../../../text/1.txt"))
            {

                for (int i = 0; i < 1000; i++)
                {
                    str = g1.getsym(str);
                    w.Write(str);
                    w.Write(" ");
                }
            }

            using (StreamWriter w = new StreamWriter("../../../text/2.txt"))
            {
                for (int i = 0; i < 1000; i++)
                {
                    slovo = g2.getslovo();
                    for (int j = 0; j < slovo.Length; j++)
                        w.Write(slovo[j]);
                    w.Write(' ');
                }
            }

            using (StreamWriter w = new StreamWriter("../../../text/3.txt")) {
                for (int i = 0; i < 1000; i++) {
                    paraslov = g3.getparslov();
                    for (int j = 0; j < paraslov.Length; j++)
                        w.Write(paraslov[j]);
                    w.Write(' ');
                }
            }
        }
    }
}
