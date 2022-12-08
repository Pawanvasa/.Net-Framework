//1- Write a program and ask the user to enter a few numbers separated by a hyphen.
//Work out if the numbers are consecutive. For example, if the input is "5-6-7-8-9"
//or "20-19-18-17-16", display a message: "Consecutive"; otherwise, display "Not Consecutive".

Console.WriteLine("Enter Numbers Separated by Hyphen");
String ?numbers = Console.ReadLine();
String[] saparated = numbers.Split("-");
int check = Convert.ToInt32(saparated[0]);
int count = 0;
for (int i = 0; i < saparated.Length; i++)
{
    if (Convert.ToInt32(saparated[i]) == check)
    {
        check++;
        count++;
    }
}
if (count == saparated.Length)
{
    Console.WriteLine("Consecutive");
}
else
{
    Console.WriteLine("Not Consecutive");
}