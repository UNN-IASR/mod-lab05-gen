using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

using static System.Net.Mime.MediaTypeNames;

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

            BigramGen bg= new BigramGen();

            using (FileStream fstream = new FileStream("../../../../gen-1.txt", FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] buffer;
                for (int i = 0; i < 500; i++)
                {
                    buffer = Encoding.Default.GetBytes(bg.getPair());
                    fstream.Write(buffer, 0, buffer.Length);
                }
                Console.WriteLine("Текст записан в файл");
            }
        }
    }
}

