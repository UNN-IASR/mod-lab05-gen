using System;
using System.Collections.Generic;

namespace ProjCharGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            CharGenerator gen0 = new CharGenerator();
            BigramGenerator gen1 = new BigramGenerator();
            WordGenerator gen2 = new WordGenerator();

            gen0.Generate(1000);
            gen1.Generate(1000);
            gen2.Generate(1000);
        }
    }
}

