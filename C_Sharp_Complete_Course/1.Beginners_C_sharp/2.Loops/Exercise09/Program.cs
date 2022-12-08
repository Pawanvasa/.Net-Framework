//5- Write a program and ask the user to enter a series of numbers
//separated by comma. Find the maximum of the numbers and display
//it on the console. For example, if the user enters “5, 3, 8, 1, 4",
//the program should display 8.

Console.WriteLine("Enter a series of numbers");
string? numbers = Console.ReadLine();
String[] saparatednumbers = numbers.Split(",");
int[] arr = new int[saparatednumbers.Length];
int k = 0;
foreach (int number in arr)
{
    arr[k] = Convert.ToInt32(saparatednumbers[k]);
    k++;
}

Console.WriteLine($"Maximum Number in Given Series is = {maxNumberFinder(arr)}");

static int maxNumberFinder(int[] arr1)
{

    for (int i = 0; i < arr1.Length; i++)
    {
        for (int j = i + 1; j < arr1.Length; j++)
        {
            if (arr1[i] > arr1[j])
            {
                int temp = arr1[i];
                arr1[i] = arr1[j];
                arr1[j] = temp;
            }
        }
    }
    int maxNumber= Convert.ToInt32(arr1[arr1.Length - 1]); ;
    return maxNumber;
}