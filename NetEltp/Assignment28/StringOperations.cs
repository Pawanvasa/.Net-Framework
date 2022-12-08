using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment28
{

    public static class StringOperations
    {
        public static void CountWords(String str)
        {
            string[] st = str.Split(" ");
            Console.WriteLine($"The Number Of Words in the String is = {st.Length}");
            Console.WriteLine();
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
            Console.WriteLine();
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
            Console.WriteLine();
        }

        public static void specialChars(this String str)
        {
            int specialCharCount = 0;
            List<char> list = new List<char>();
            for (int i = 0; i < str.Length; i++)
            {
                if (!Char.IsLetter(str[i]) && !Char.IsDigit(str[i]) && str[i] != ' ')
                {
                    list.Add(str[i]);
                    specialCharCount++;
                }
            }
           /* Console.WriteLine($"Number of Special Charecters Present in String is = {specialCharCount}");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }*/


            SpecialCharFequency(list);
            static void SpecialCharFequency(List<char> str)
            {
                int n = str.Count;
                bool[] visited = new bool[n];
                for (int i = 0; i < n; i++)
                {
                    if (visited[i] == true)
                        continue;
                    int count = 1;
                    for (int j = i + 1; j < n; j++)
                    {
                        if (str[i] == str[j])
                        {
                            visited[j] = true;
                            count++;
                        }
                    }
                    if (count > 1)
                        Console.WriteLine($"The {str[i]} appears {count} times in array");
                    if (count == 1)
                        Console.WriteLine($"The {str[i]} appears {count} time in array");
                }
            }
        }

        public static void convertCapital(this String str)
        {
            Console.WriteLine();
            Console.WriteLine("After Converting First Letter of Each Word in String :");
            char[] ch = str.ToCharArray();
            Boolean spaceFinder = true;
            for (int i = 0; i < ch.Length; i++)
            {
                if (Char.IsLetter(ch[i]))
                {
                    if (spaceFinder)
                    {
                        ch[i] = Char.ToUpper(ch[i]);
                        spaceFinder = false;
                    }
                }
                else
                {
                    spaceFinder = true;
                }
            }
            str = new string(ch);
            Console.WriteLine(str);
        }

        public static void NumberFrequency(this String str)
        {
            Console.WriteLine();
            Console.WriteLine("Index Of Numbers in String");
            char[] nums = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (str[i] == nums[j])
                    {
                        Console.WriteLine($"{str[i]} is Present At Index {i}");
                    }
                }
            }
        }
    }
}