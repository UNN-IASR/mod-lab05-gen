using System;
using System.Collections.Generic;
using System.Text;

namespace ProjCharGenerator
{
    abstract class utils
    {
        public static List<String> readLine(String line)
        {
            List<String> result = new List<String>();
            String word = "";
            foreach(char c in line)
            {
                if(c == ' ' || c == '\t')
                {
                    result.Add(word);
                    word = "";
                }
                else
                {
                    word += c;
                }
            }
            if(word.Length != 0)
            {
                result.Add(word);
            }
            return result;
        }
    }
}
