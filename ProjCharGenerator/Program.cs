using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace generator
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var enc1251 = Encoding.GetEncoding(1251);
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;
            System.Console.InputEncoding = enc1251;
            WordGen wg = new WordGen();
            BigramGen bg= new BigramGen();
            using (FileStream fstream = new FileStream("../../../../gen-1.txt", FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] buffer;
                for (int i = 0; i < 600; i++)
                {
                    string pair = bg.getPair();
                    buffer = Encoding.GetEncoding(1251).GetBytes(pair);
                    fstream.Write(buffer, 0, buffer.Length);
                }
                Console.WriteLine("Текст записан в файл gen-1.txt");
            }
            using (FileStream fstream = new FileStream("../../../../gen-2.txt", FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] buffer;
                for (int i = 0; i < 300; i++)
                {
                    string pair = wg.getPair()+" ";
                    buffer = Encoding.GetEncoding(1251).GetBytes(pair);
                    fstream.Write(buffer, 0, buffer.Length);
                }
                Console.WriteLine("Текст записан в файл gen-2.txt");
            }
        }
    }
}

