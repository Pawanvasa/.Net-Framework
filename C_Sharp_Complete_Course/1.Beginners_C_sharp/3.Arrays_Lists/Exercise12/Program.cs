﻿//3- Write a program and ask the user to enter 5 numbers.
//If a number has been previously entered, display an error
//message and ask the user to re-try. Once the user successfully
//enters 5 unique numbers, sort them and display the result on the console.


List<int> numbers = new List<int>();

while(numbers.Count < 5)
{
    Console.WriteLine("Enter Number");
    int num=Convert.ToInt32(Console.ReadLine());
    if (numbers.Contains(num))
    {
        Console.WriteLine("Already Number is Entered");
        continue;
    }
    numbers.Add(num);

}
numbers.Sort();
foreach(int num in numbers)
{
    Console.WriteLine(num);
}