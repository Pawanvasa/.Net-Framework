using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment13
{

    public  class StringOperations
    {
        public static void CountWords(String str)
        {
            string[] st = str.Split(" ");
            Console.WriteLine($"The Number Of Words in the String is = {st.Length}");
        }
    }

    public static class ExtensionClass
    {
        public static void CountStatements(this String str)
        {
            int StatementCount = 0;
            for (int i = 1; i < str.Length; i++)
            {
                if (str[i - 1] == '.' && str[i] == ' ')
                {
                    StatementCount++;
                }
            }
            Console.WriteLine($"Number of Statements Present in String is = {StatementCount}");
        }
        public static void CountBlanKSpaces(this String str)
        {
            int whiteSpaces=0;
            for (int j = 0; j < str.Length; j++)
            {
                if (str[j] == ' ')
                {
                    whiteSpaces++;
                }
            }
            Console.WriteLine($"The Number of Blank  Spaces Present in the String is = {whiteSpaces}");
        }
    }
}