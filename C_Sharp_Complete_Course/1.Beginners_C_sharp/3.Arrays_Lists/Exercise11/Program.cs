//2. Write a program and ask the user to enter their name.
//Use an array to reverse the name and then store the result in a new string.
//Display the reversed name on the console.

Console.WriteLine("Enter your Name");
var name = Console.ReadLine();
char[] charsOfNames = name.ToCharArray();
String reverseString = String.Empty;
for (int i = charsOfNames.Length-1; i > 0; i--)
{
    reverseString+=charsOfNames[i];
}
Console.WriteLine(reverseString);