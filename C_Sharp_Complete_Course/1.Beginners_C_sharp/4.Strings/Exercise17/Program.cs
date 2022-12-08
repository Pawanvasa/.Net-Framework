//3- Write a program and ask the user to enter a time value in
//the 24-hour time format (e.g. 19:00). A valid time should be
//between 00:00 and 23:59. If the time is valid, display "Ok";
//otherwise, display "Invalid Time". If the user doesn't provide any values,
//consider it as invalid time.

Console.WriteLine("Enter time in 24-hour format");
String ?time = Console.ReadLine();
String[] timeMinutes = time.Split(":");
if (timeMinutes.Length != 2)
{
    Console.WriteLine("Invalid Time");
}

int houre = Convert.ToInt32(timeMinutes[0]);
int minutes = Convert.ToInt32(timeMinutes[1]);

if (houre >= 0 && houre < 24 && minutes >= 0 && minutes < 60)
{
    Console.WriteLine("Ok");
}
else
{
    Console.WriteLine("Invalid Time");
}