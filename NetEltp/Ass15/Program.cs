
//String[] str= new String[] {"Pavan","Mohan","Amar","Sri","Barath","Dileep","Raja", "AmarnadhaReddy", "Ram","Kalyan","Mahesh","Pavan","Raja","Sri","MohanBravo"};
//int[] arr ={ 23, 24, 1, 7, 5, 1, 8, 345, 23, 8, 7, 56, 34, 246, 345, 342, 96 };
char Continue = 'y';

//To Read String Array
Console.WriteLine("Enter String Array Size");
int len = Convert.ToInt32(Console.ReadLine());
String[] ?str = new string[len];
Console.WriteLine("Enter Values of Array");
for (int i = 0; i < str.Length; i++)
{ 
    str[i] = Console.ReadLine();
}

//To Read Integer Array
Console.WriteLine("Enter Integer Array Size");
int len2 = Convert.ToInt32(Console.ReadLine());
int[] ar = new int[len2];
Console.WriteLine("Enter Array Elements");
for (int i = 0; i < len2; i++)
{
    ar[i] = Convert.ToInt32(Console.ReadLine());
}

do
{
    Console.WriteLine("1. Sort and reverse the array based on Length of each string from array");
    Console.WriteLine("2. print index of even and odd number from the array");
    Console.WriteLine("3. print an index of prime numbers from the array");
    Console.WriteLine("4. print only those strings that contains 'a' in it at any position in that string");
    Console.WriteLine("5. print only those strings that starts from 'A' or 'M', or 'K' from the array");
    Console.WriteLine("6. count of repeated strings in an array and print them on console");
    Console.WriteLine("7. count of repeated Numbers in an array and print them on console");

    Console.WriteLine();
    Console.WriteLine("Enter Your Choice to perform Operation");
    int respose = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();
    
    switch (respose)
    {
        //Sort and reverse the array based on Length of each string
        case 1:
            Console.WriteLine();
            Console.WriteLine("Original Array");
            printArray(str);
            Console.WriteLine();
            Console.WriteLine("After Sorting");
            sortBasedOnLength(str);
            Console.WriteLine();
            Console.WriteLine("After Reverse");
            Array.Reverse(str);
            printArray(str);
            break;

        //print index of even and odd number from the array
        case 2:
            toPrintEvenOddIndex(ar);
            break;

        //print an index of prime numbers from the array"
        case 3:
            Console.WriteLine("Prime Numbers in Given Array");
            for (int i = 0; i < len; i++)
            {
                Boolean check = CheckPrime(ar[i]);
                if (check)
                {
                    Console.WriteLine($"{ar[i]} is a prime number present in the index of {i}");
                }
            }
            break;

        //strings that contains 'a' in it at any position in that string
        case 4:
            Console.WriteLine();
            Console.WriteLine("Strings that contains 'a' are");
            for (int i = 0; i < str.Length; i++)
            {
                Boolean present = checkPresentOrNot(str[i]);
                if (present)
                {
                    Console.WriteLine(str[i]);
                }
            }
            break;

        //strings that starts from 'A' or 'M', or 'K' from the array
        case 5:
            Console.WriteLine();
            Console.WriteLine("The Strings That start With 'A' or 'M' or 'K' ");
            for(int i = 0; i < str.Length; i++)
            {
                if (AMKcheck(str[i]))
                {
                    Console.WriteLine(str[i]);
                }
            }
            break;

        //repeated strings in an array and print them on console
        case 6:
            Console.WriteLine("String values");
            printArray(str);
            Console.WriteLine();
            Console.WriteLine("Strings and Frequencies");
            frequenciesFind(str);
            break;

        //repeated Numbers in an array and print them on console
        case 7:
            
            Console.WriteLine("Array values");
            printIntArray(ar);
            Console.WriteLine();
            Console.WriteLine("Frequencies");
            intFrequencieCount(ar);
            break;
    }


    //Array of Strings and Sort and reverse the array based on Length of each string from array
    static void sortBasedOnLength(String[] orginal)
    {
        Array.Sort(orginal);
        for (int i = 1; i < orginal.Length; i++)
        {
            String temp = orginal[i];

            // Insert s[j] at its correct position
            int j = i - 1;
            while (j >= 0 && temp.Length < orginal[j].Length)
            {
                orginal[j + 1] = orginal[j];
                j--;
            }
            orginal[j + 1] = temp;
        }
        foreach (String sr in orginal)
        {
            Console.WriteLine(sr);
        }
    }


   // Array of integers and print index of even and odd number from the array
    static void toPrintEvenOddIndex(int[] arr)
    {
        Console.WriteLine("Even Numbers and Their Indexes");
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] % 2 == 0)
            {
                Console.WriteLine($"{arr[i]} Present At the Index of {i}");
            }
        }
        Console.WriteLine();
        Console.WriteLine("Odd Numbers and Their Indexes");
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] % 2 != 0)
            {
                Console.WriteLine($"{arr[i]} Present At the Index of {i}");
            }
        }

    }

    //To Check Whether a number is prime or not
    static Boolean CheckPrime(int n)
    {
        Boolean b = false;
        int a = 0;
        for (int i = 1; i <= n; i++)
        {
            if (n % i == 0)
            {
                a++;
            }
        }
        if (a == 2)
        {
            b = true;
        }
        else
        {
            b = false;
        }
        return b;
    }

    //Array of Strings and print only those strings that contains 'a'
    //in it at any position in that string
    static Boolean checkPresentOrNot(String str)
    {
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == 'a')
            {
                return true;
            }
        }
        return false;
    }
    //Array of Strings and print only those strings that
    //starts from 'A' or 'M', or 'K' from the array
    static Boolean AMKcheck(string str)
    {
        char[] chars = { 'A','M', 'K' };
            foreach (char c in chars)
            {
                if (str[0]==c) { 
                return true;
                }
            }
            return false;
    }


    //Array of Strings and Find out count of repeated strings
    //in an array and print them on console
    static void frequenciesFind(String[] str)
    {
        int n = str.Length; 
        bool[] visited = new bool[n];
        for (int i = 0; i < n; i++)
        {
            if (visited[i] == true)
                continue;
            int count = 1;
            for (int j = i + 1; j < n; j++)
            {
                if (str[i] == str[j])
                {
                    visited[j] = true;
                    count++;
                }
            }
            if(count>1)
            Console.WriteLine($"The {str[i]} appears { count} times in array");
            if (count == 1)
                Console.WriteLine($"The {str[i]} appears {count} time in array");

        }
}

    //Array of Integers and Find out count of repeated Integers
    //in an array and print them on console
    static void intFrequencieCount(int[] arry)
    {
        int n = arry.Length;
        bool[] visited = new bool[n];

        for (int i = 0; i < n; i++)
        {
            if (visited[i] == true)
                continue;
            int count = 1;
            for (int j = i + 1; j < n; j++)
            {
                if (arry[i] == arry[j])
                {
                    visited[j] = true;
                    count++;
                }
            }
            if (count > 1)
                Console.WriteLine($"The {arry[i]} appears {count} times in array");
            if (count == 1)
                Console.WriteLine($"The {arry[i]} appears {count} time in array");

        }
    }


    //To Print the String Array
    static void printArray(String[] res)
    {
        foreach(String str in res)
        {
            Console.WriteLine(str);
        }
    }
    //To Print the integer Array
    static void printIntArray(int[] res)
    {
        foreach (int n in res)
        {
            Console.WriteLine(n);
        }
    }
    Console.WriteLine();
    Console.WriteLine("Enter Y to Continue N to stop");
    Continue = Convert.ToChar(Console.ReadLine());
    Console.Clear();
}
while (Continue == 'y' || Continue == 'Y');

