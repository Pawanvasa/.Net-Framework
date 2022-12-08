//2. Write a program and ask the user to enter a few numbers separated by a hyphen.
//If the user simply presses Enter, without supplying an input, exit immediately;
//otherwise, check to see if there are duplicates. If so, display "Duplicate" on the console.

Console.WriteLine("Enter Numbers separated by a hyphen");
string numbers = Console.ReadLine();
string[] saparated = numbers.Split("-");
int count = 0;
for (int i = 0; i < saparated.Length; i++)
{
    for (int j = i + 1; j < saparated.Length; j++)
    {
        if (saparated[i] == saparated[j])
        {
            count = 1;
            break;
        }
    }
}
if (count > 0)
{
    Console.WriteLine("Duplicate");
}
else
{
    Console.WriteLine("No Duplicates");
}