/*2. Write a program and continuously ask the user to enter a number or "ok" to exit. 
 Calculate the sum of all the previously entered numbers and display it on the console.*/

string ?number;
int sumOfEntries = 0;
do
{
    Console.WriteLine("Enter a Number or ok to exit");
    number = Console.ReadLine();
    if (number != "ok")
        sumOfEntries += Convert.ToInt32(number);
} while (number != "ok");
Console.WriteLine($"Sum of all Entries = {sumOfEntries}");
