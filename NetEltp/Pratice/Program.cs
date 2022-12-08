using Pratice;
using Pratice.Delegate;
using System;



/*Console.WriteLine("Pattern Practice");
pattern1(5);
Console.WriteLine();
pattern2(5);
Console.WriteLine();
pattern3(5);
Console.WriteLine();
pattern4(5);
Console.WriteLine();
pattern5(5);
Console.WriteLine();
pattern6(5);
Console.WriteLine();
pattern10(5);
*/

//Step-1 : Run the outer forloop for the number of rows you want to print
//Step-2 : Identify how many coloumns are there for every row
//Step-3 : What do you need to print

static void pattern1(int n)
{
    for (int i = 1; i <= n; i++)
    {
        for (int j = 1; j <= n - i; j++)
        {
            Console.Write("* ");
        }
        Console.WriteLine();
    }
}

static void pattern2(int n)
{
    for (int i = 1; i <= n; i++)
    {
        for (int j = 1; j <= i; j++)
        {
            Console.Write(j);
        }
        Console.WriteLine();
    }
}

static void pattern3(int n)
{
    for (int i = 1; i <= n; i++)
    {
        for (int j = 1; j <= i; j++)
        {
            Console.Write("* ");
        }
        Console.WriteLine();
    }
}


static void pattern4(int n)
{
    for (int i = 1; i < n * 2; i++)
    {
        int numberOfColoumns = i > n ? 2 * n - i : i;
        for (int j = 1; j < numberOfColoumns; j++)
        {
            Console.Write("* ");
        }
        Console.WriteLine();
    }
}


static void pattern5(int n)
{
    for (int i = 1; i < n * 2; i++)
    {
        int numberOfColoumns = i > n ? 2 * n - i : i;

        int spaces = n - numberOfColoumns;
        for (int k = 1; k <= spaces; k++)
        {
            Console.Write(" ");
        }
        for (int j = 1; j < numberOfColoumns; j++)
        {
            Console.Write("* ");
        }
        Console.WriteLine();
    }
}


static void pattern6(int n)
{
    for (int row = 1; row <= n; row++)
    {
        for (int col = 1; col <= n; col++)
        {
            if (col >= row)
            {
                Console.Write("* ");
            }
            else
            {
                Console.Write(" ");
            }
        }
        Console.WriteLine();
    }
}




static void pattern10(int n)
{
    for (int row = 1; row <= n * 2; row++)
    {
        int c = row > n ? 2 * n - row : row;
        for (int space = 0; space < n - c; space++)
        {
            Console.Write("  ");
        }
        for (int col = c; col >= 1; col--)
        {
            Console.Write(col + " ");
        }
        for (int col = 2; col <= c; col++)
        {
            Console.Write(col + " ");
        }
        Console.WriteLine();
    }
}




static String WeigthSort(String strng)
{
    String[] strArr = strng.Split(" ");
    List<int> list = new List<int>();
    int res = 0;
    foreach (var str in strArr)
    {
        int n = Convert.ToInt32(str);
        while (n > 0)
        {
            res += n % 10;
            n /= 10;
        }
        list.Add(res);
        res = 0;
    }
    Console.WriteLine("Before Sorting");
    foreach (var v in list)
    {
        Console.Write(v + " ");
    }

    for (int i = 0; i < list.Count; i++)
    {
        for (int j = i + 1; j < list.Count; j++)
        {
            if (list[i] > list[j])
            {
                int temp = list[i];
                String temp2 = strArr[i];
                list[i] = list[j];
                strArr[i] = strArr[j];
                list[j] = temp;
                strArr[j] = temp2;
            }
        }
    }
    Console.WriteLine();
    SortAlphabetically(strArr, list);
    static void SortAlphabetically(String[] str, List<int> weights)
    {
        List<String> temp = new List<String>();
        for (int i = 1; i < weights.Count; i++)
        {
            int temp1 = weights[0];
            if (temp1 == weights[i])
            {
                temp.Add(str[i - 1]);
                //temp.Add(str[i]);
            }
        }
        foreach (String s in temp)
        {
            Console.Write(s + " ");
        }
    }
    Console.WriteLine();
    Console.WriteLine("After Sorting");
    String result = String.Empty;
    foreach (var v in strArr)
    {
        result += v + " ";
    }
    foreach (var v2 in list)
    {
        Console.Write(v2 + " ");
    }
    Console.WriteLine();
    return result;
}

//Console.WriteLine(WeigthSort("2000 10003 1234000 44444444 9999 11 11 22 123"));




static long Fibonacci(int max)
{
    long n1 = 0, n2 = 1, n3;
    long res = 0;
    for (int i = 2; i < max; ++i)
    {
        n3 = n1 + n2;
        if (n3 % 2 == 0 && n3 < max)
        {
            res += n3;
        }
        if (n3 >= max)
        {
            break;
        }
        n1 = n2;
        n2 = n3;
    }
    return res;
}
//Console.WriteLine(Fibonacci(44));



static double Solution(int[] firstArray, int[] secondArray)
{
    int[] result = new int[firstArray.Length];
    for (int i = 0; i < firstArray.Length; i++)
    {
        result[i] = firstArray[i] - secondArray[i];
    }
    double res = 0;
    foreach (int i in result)
    {
        res += i * i;
    }
    res /= firstArray.Length;
    return res;
}
int[] arr1 = { 1, 2, 3 };
int[] arr2 = { 4, 5, 6 };
//Console.WriteLine(Solution(arr1, arr2));




static long RowSumOddNumbers(long n)
{
    //List<int>li=new List<int> ();
    int odd = 1, temp = 0, res = 0;
    for (int i = 0; i <= n; i++)
    {
        while (temp != i)
        {
            if (odd % 2 != 0)
            {
                //li.Add(odd);
                temp++;
                if (i == n)
                {
                    res += odd;
                }
            }
            odd++;
        }
        temp = 0;
    }
    return res;
}
//Console.WriteLine(RowSumOddNumbers(42));

static long NextBiggerNumber(long n)
{
    List<long> list = new List<long>();
    String res = n.ToString();
    long[] arr = new long[res.Length];
    for (int i = 0; i < res.Length; i++)
    {
        arr[i] = Convert.ToInt64(res[i]);
    }
    for (int i = 0; i < res.Length; i++)
    {
        for (int j = i + 1; j < res.Length; j++)
        {
            long temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
    for (int i = 0; i < res.Length; i++)
    {
        Console.WriteLine(arr[i]);
    }
    return 0;
}
//NextBiggerNumber(531);



static bool Scramble(string str1, string str2)
{
    int count = 0;
    for (int i = 0; i < str1.Length; i++)
    {
        for (int j = 0; j < str2.Length; j++)
        {
            if (str1[i] == str2[j])
            {
                str1.Append('1');
                str2.Append('0');
            }
        }
    }
    foreach (char c in str2)
    {
        if (c == '0')
        {
            count++;
        }
        // Console.WriteLine(c);
    }
    Console.WriteLine(str1);
    Console.WriteLine(str2);

    if (count == str2.Length)
    {
        Console.WriteLine(true);
    }
    else
    {
        Console.WriteLine(false);
    }
    return true;
}
//Scramble("scriptingjava", "javascript");

static int[] Parse(string data)
{
    int res = 0, len = 0, j = 0;
    for (int i = 0; i < data.Length; i++)
    {
        if (data[i] == 'o')
            len++;
    }
    int[] outPutArray = new int[len];
    for (int i = 0; i < data.Length; i++)
    {
        char s = data[i];
        switch (s)
        {
            case 'i':
                res++;
                break;
            case 'd':
                res--;
                break;
            case 's':
                res *= res;
                break;
            case 'o':
                outPutArray[j] = res;
                j++;
                break;
        }
    }
    return outPutArray;
}

//Parse("iiisdosodddddiso");
//Deadfish.Parse("iiisdoso") => new int[] {8, 64};
static IEnumerable<Char> Reverse(string str)
{
    return str.Reverse();
}

foreach(var s in Reverse("Ayush"))
{
    Console.Write(s);
}
Console.WriteLine();
static int[] ProductArray(int[] array)
{
    //Do Some Magic
    int[] res = new int[array.Length];
    int temp1 = 1;
    for (int i = 0; i < array.Length; i++)
    {
        int temp = array[i];
        array[i] = 0;
        for (int j = 0; j < array.Length; j++)
        {
            if (array[j] != 0)
                temp1 *= array[j];
        }
        res[i] = temp1;
        temp1 = 1;
        array[i] = temp;
    }
    return res;
}
int[] arr = { 10, 3, 5, 6, 2 };
/*foreach(int a in ProductArray(arr))
{
Console.WriteLine(a);
}*/

String str = String.Join(" ", arr);
//Console.WriteLine(str);

DateTime dt = new DateTime(1999, 05, 23);



static string[] ?inArray(string[] array1, string[] array2)
{
    for (int i = 0; i < array2.Length; i++)
    {
        for (int j = 0; j < array1.Length; j++)
        {
            //if (array2[i].IndexOf(array1[j]))
        }
    }
    return null!;
}
string[] a1 = new string[] { "arp", "live", "strong" };
string[] a2 = new string[] { "lively", "alive", "harp", "sharp", "armstrong" };
//inArray(a1, a2);

printing print = new printing();
ITesting test = new printing();
test.implemetedFunction();

public class printing : ITesting
{
    public void print(string message)
    {
        Console.WriteLine(message);
    }

    public void run()
    {
        Console.WriteLine("Running");
    }
}

