//5- Write/ a program and ask the user to supply a list of comma
//separated numbers (e.g 5, 1, 9, 2, 10). If the list is empty or
//includes less than 5 numbers, display "Invalid List" and ask the
//user to re-try; otherwise, display the 3 smallest numbers in the list.


string str = string.Empty;
while (str.Length < 9)
{
    Console.WriteLine("Enter Five Coma Separated values");
    str = Console.ReadLine();
    if (str.Length < 9)
    {
        Console.WriteLine("Invalid list");
    }
}

var numbers = str.Split(",");
List<int> list = new List<int>();
for (int i = 0; i < numbers.Length; i++)
{
    list.Add(Convert.ToInt32(numbers[i]));
}
list.Sort();

Console.WriteLine(list[0]);
Console.WriteLine(list[1]);
Console.WriteLine(list[2]);
