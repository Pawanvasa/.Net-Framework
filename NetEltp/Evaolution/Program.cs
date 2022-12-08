// See https://aka.ms/new-console-template for more information


int[] arr = { 4, 6, 2, 7, 5, 3, 34, 6, 4, 31, 39 };

Console.WriteLine(NumberSearch(arr,39));

static String NumberSearch(int[]arr,int number)
{
    int len = arr.Length;
    if (arr[len - 1] == number)
        return "Number Found";
    
    int temp = arr[len - 1]; 
    arr[len - 1] = number;

        
    for(int i=0; ; i++)
    {
        if (arr[i] == number)
        {
            arr[len - 1] = temp;

            if (i < len - 1)
                return "Number Found";

            return "Number Not Found";
        }
    }
}
/*Console.WriteLine("After Swapping");
foreach(int i in arr)
{
    Console.Write(i+" ");
}*/


