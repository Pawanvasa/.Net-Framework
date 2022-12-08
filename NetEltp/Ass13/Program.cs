using System.Collections.Generic;
using Assignment13;
//The Number Of Words in the String
String str = "The James Bond series focuses on a fictional British Secret Service agent created in 1953 by writer Ian Fleming, who featured him in twelve novels and two short-story collections. Since Fleming's death in 1964, eight other authors have written authorised Bond novels or novelisations: Kingsley Amis, Christopher Wood, John Gardner, Raymond Benson, Sebastian Faulks, Jeffery Deaver, William Boyd, and Anthony Horowitz. The latest novel is Forever and a Day by Anthony Horowitz, published in May 2018. Additionally Charlie Higson wrote a series on a young James Bond, and Kate Westbrook wrote three novels based on the diaries of a recurring series character, Moneypenny.The character-also known by the code number 007 (pronounced double-O-seven)-has also been adapted for television, radio, comic strip, video games and film. The films are one of the longest continually running film series and have grossed over US$7.04 billion in total, making it the fifth-highest-grossing film series to date, which started in 1962 with Dr. No, starring Sean Connery as Bond. As of 2021, there have been twenty-five films in the Eon Productions series. The most recent Bond film, No Time to Die (2021), stars Daniel Craig in his fifth portrayal of Bond; he is the sixth actor to play Bond in the Eon series. There have also been two independent productions of Bond films: Casino Royale(a 1967 spoof starring David Niven) and Never Say Never Again (a 1983 remake of an earlier Eon-produced film, 1965's Thunderball, both starring Connery). In 2015, the series was estimated to be worth $19.9 billion,[1] making James Bond one of the highest-grossing media franchises of all time.";
String[] st = str.Split(" ");
int strlen = str.Length;
int whiteSpaces = 0;
Console.WriteLine($"The Number Of Words in the String is = {st.Length}");

//Number of Statements Present in String
int StatementCount = 0;
for(int i = 1; i < str.Length; i++)
{
    if (str[i-1]=='.' && str[i]==' ')
    {
        StatementCount++;
    }
}
Console.WriteLine($"Number of Statements Present in String is = {StatementCount}");


//The Number of Blank  Spaces Present in the String
for (int j = 0; j < strlen; j++)
{
    if (str[j]==' ')
    {
        whiteSpaces++;
    }
}
Console.WriteLine($"The Number of Blank  Spaces Present in the String is = {whiteSpaces}");

//To print number of special Chars in a String 
int specialCharCount = 0;
List<char> list = new List<char>();
for (int i = 0; i < str.Length; i++)
{
    if (!Char.IsLetter(str[i]) && !Char.IsDigit(str[i])  && str[i] != ' ')
    {  
        list.Add(str[i]);
        specialCharCount++;
    }
}
Console.WriteLine($"Number of Special Charecters Present in String is = {specialCharCount}");
for (int i = 0; i < list.Count; i++)
{
    Console.WriteLine(list[i]);
}
Console.WriteLine();



//To Change the every starting char of word to Uppercase
Console.WriteLine("After Converting First Letter of Each Word in String :");
char[] ch = str.ToCharArray();
Boolean spaceFinder = true;
for(int i = 0; i < ch.Length; i++)
{
    if (Char.IsLetter(ch[i]))
    {
        if (spaceFinder)
        {
            ch[i]=Char.ToUpper(ch[i]);
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

//To Print the numbers index
Console.WriteLine();
Console.WriteLine("Index Of Numbers in String");
char[] nums = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
for (int i=0;i<str.Length; i++)
{
    for (int j = 0; j < nums.Length; j++)
    {
        if (str[i] == nums[j])
        {
            Console.WriteLine($"{str[i]} is Present At Index {i}");
        }
    }
}


//To Print Frequancy of Special chars
Console.WriteLine();
SpecialCharFequency(list);
static void SpecialCharFequency(List <char>str)
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



string myString = "The James Bond series focuses on a fictional British Secret Service agent created in 1953 by writer Ian Fleming, who featured him in twelve novels and two short-story collections. Since Fleming's death in 1964, eight other authors have written authorised Bond novels or novelisations: Kingsley Amis, Christopher Wood, John Gardner, Raymond Benson, Sebastian Faulks, Jeffery Deaver, William Boyd, and Anthony Horowitz. The latest novel is Forever and a Day by Anthony Horowitz, published in May 2018. Additionally Charlie Higson wrote a series on a young James Bond, and Kate Westbrook wrote three novels based on the diaries of a recurring series character, Moneypenny.The character-also known by the code number 007 (pronounced double-O-seven)-has also been adapted for television, radio, comic strip, video games and film. The films are one of the longest continually running film series and have grossed over US$7.04 billion in total, making it the fifth-highest-grossing film series to date, which started in 1962 with Dr. No, starring Sean Connery as Bond. As of 2021, there have been twenty-five films in the Eon Productions series. The most recent Bond film, No Time to Die (2021), stars Daniel Craig in his fifth portrayal of Bond; he is the sixth actor to play Bond in the Eon series. There have also been two independent productions of Bond films: Casino Royale(a 1967 spoof starring David Niven) and Never Say Never Again (a 1983 remake of an earlier Eon-produced film, 1965's Thunderball, both starring Connery). In 2015, the series was estimated to be worth $19.9 billion,[1] making James Bond one of the highest-grossing media franchises of all time.";
StringOperations.CountWords(myString);
myString.CountStatements();

