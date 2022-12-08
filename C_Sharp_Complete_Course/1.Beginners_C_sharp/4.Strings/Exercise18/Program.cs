//4. Write a program and ask the user to enter a few words separated by a space.
//Use the words to create a variable name with PascalCase. For example, if the
//user types: "number of students", display "NumberOfStudents".Make sure that
//the program is not dependent on the input. So, if the user types "NUMBER OF STUDENTS",
//the program should still display "NumberOfStudents".


Console.WriteLine("Enter Word Saparated by Space");
String word=Console.ReadLine();
convertCapital(word.ToLower());

static void convertCapital(String str)
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