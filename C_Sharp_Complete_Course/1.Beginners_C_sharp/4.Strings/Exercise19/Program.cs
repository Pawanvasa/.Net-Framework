//5. Write a program and ask the user to enter an English word.
//Count the number of vowels (a, e, o, u, i) in the word. So,
//if the user enters "inadequate", the program should display 6 on the console.

Console.WriteLine("Enter a Word");
string ?word=Console.ReadLine();
char[] vowels = { 'a', 'e', 'i', 'o', 'i' };
int count = 0;
for(int i = 0; i < vowels.Length; i++)
{
    for(int j = 0; j < word.Length; j++)
    {
        if(vowels[i] == word[j])
        {
            count++;
        }
    }
}
Console.WriteLine($"Vowels in given {word} is {count}");