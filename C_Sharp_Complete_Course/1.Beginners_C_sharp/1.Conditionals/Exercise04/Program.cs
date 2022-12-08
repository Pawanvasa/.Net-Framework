/*Write a program that asks the user to enter the speed limit. Once set, 
 the program asks for the speed of a car. If the user enters a value 
 less than the speed limit, program should display Ok on the console. 
 If the value is above the speed limit, the program should calculate 
 the number of demerit points. For every 5km/hr above the speed limit, 
 1 demerit points should be incurred and displayed on the console. 
 If the number of demerit points is above 12, the program should display 
 License Suspended.*/


Console.WriteLine("Enter the Speed limit");
int speedLimit = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter the speed of car");
int speedOfCar = Convert.ToInt32(Console.ReadLine());
if (speedOfCar < speedLimit)
{
    Console.WriteLine("Ok");
}
else
{
    int overSpeed = speedOfCar - speedLimit;
    int demeritPoints = overSpeed / 5;
    if (demeritPoints < 12)
    {
        Console.WriteLine("Demerit Points For Over Speed :" + demeritPoints);
    }
    else
    {
        Console.WriteLine("License Suspended");
    }
}