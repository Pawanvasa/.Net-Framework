using DaysCalculator; 
Console.WriteLine("Days Calculator!");

Console.WriteLine("Enter Start Date");
DateTime sdate = DateTime.Parse(Console.ReadLine()!);
Console.WriteLine("Enter End Date");
DateTime edate = DateTime.Parse(Console.ReadLine()!);
String str1 = Convert.ToString(sdate);
String str2 = Convert.ToString(edate);

int Syear= DateTime.Parse(str1).Year;
int Eyear = DateTime.Parse(str2).Year;


int Smonth= DateTime.Parse(str1).Month;
int Emonth = DateTime.Parse(str2).Month;
int Days = DateTime.Parse(str2).Day;

if (Smonth == Emonth)
{
    int yearRes = calyears(Syear, Eyear);
    Console.WriteLine($"{yearRes} Years {Emonth} Months {Days} Days");
}
   
//To Calculate Years

int calyears(int start, int end)
{

    int years = end - start;
    return years;
}

CalculateDays days = new CalculateDays(sdate);
Console.WriteLine();


 
 