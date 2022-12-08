//4 - Write a program and ask the user to continuously enter a number or type
//"Quit" to exit. The list of numbers may include duplicates.
//Display the unique numbers that the user has entered.

List<int> numbers = new List<int>();
String? number;
do
{
    Console.WriteLine("Enter Number");
    number = Console.ReadLine();
    if (number != "quit")
    {
        numbers.Add(Convert.ToInt32(number));
    }
} while (number != "quit");
List<int> NoDuplicates = new List<int>();
foreach (int i in numbers)
{
    if (!NoDuplicates.Contains(i))
        NoDuplicates.Add(Convert.ToInt32(i));
}
foreach (int i in NoDuplicates)
{
    Console.WriteLine(i);
}