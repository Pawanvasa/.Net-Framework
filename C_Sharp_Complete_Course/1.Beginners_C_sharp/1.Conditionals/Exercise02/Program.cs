/*2. Write a program which takes two numbers from the console and displays the maximum of the two.*/

Console.WriteLine("Enter Number 1:");
int number1=Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter Number 2:");
int number2=Convert.ToInt32(Console.ReadLine());
if (number1 > number2)
{
    Console.WriteLine($"Largest number is {number1}");
}
else
{
    Console.WriteLine($"Largest number is {number2}");
}