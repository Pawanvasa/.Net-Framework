// See https://aka.ms/new-console-template for more 
List<String> stringlist = new List<string>();
stringlist.Add("Pavan");
stringlist.Add("Mohan");
stringlist.Add("Amar");
stringlist.Add("Srinu");
stringlist.Add("BarathKumar");
stringlist.Add("Dileep");
stringlist.Add("Raja");
stringlist.Add("Ram");
stringlist.Add("Bittu");
stringlist.Add("Kalyan");
stringlist.Add("Mahesh");
stringlist.Add("Pavan");
stringlist.Add("Sri");
stringlist.Add("DileepKumar");

List<int> intlist = new List<int>();
intlist.Add(23);
intlist.Add(24);
intlist.Add(5);
intlist.Add(464);
intlist.Add(57);
intlist.Add(884);
intlist.Add(34);
intlist.Add(24);
intlist.Add(03);
intlist.Add(25);
intlist.Add(21);
intlist.Add(03);
intlist.Add(2);
intlist.Add(5);
String Continue = "y";
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
        case 1:
            Console.WriteLine("Original Array");
            printArray(stringlist);
            Console.WriteLine();
            Console.WriteLine("After Sorting");
            sortBasedOnLength(stringlist);
            Console.WriteLine();
            Console.WriteLine( "After Reverse");
            stringlist.Reverse();
            printArray(stringlist);
            break;

        case 2:
            toPrintEvenOddIndex(intlist);
            break;

        case 3:

            Console.WriteLine("Prime Numbers in Given Array");
            for (int i = 0; i < intlist.Count; i++)
            {
                Boolean check = CheckPrime(intlist[i]);
                if (check)
                {
                    Console.WriteLine($"{intlist[i]} is a prime number present in the index of {i}");
                }
            }
            break;

        case 4:
            Console.WriteLine("Strings that contains 'a'");
            for (int i = 0; i < stringlist.Count; i++)
            {
                Boolean present = checkOrNot(stringlist[i]);
                if (present)
                {
                    Console.WriteLine($"a is present in {stringlist[i]}");
                }
            }
            break;

        case 5:
            Console.WriteLine("The Strings That start With 'A' or 'M' or 'K' ");
            for (int i = 0; i < stringlist.Count; i++)
            {
                if (AMKcheck(stringlist[i]))
                {
                    Console.WriteLine(stringlist[i]);
                }
            }
            break;

        case 6:
            Console.WriteLine("String values");
            printArray(stringlist);
            Console.WriteLine();
            Console.WriteLine("Frequencies");
            frequenciesFind(stringlist);
            break;

        case 7:
            Console.WriteLine("Array values");
            printIntArray(intlist);
            Console.WriteLine();
            Console.WriteLine("Frequencies");
            intFrequencieCount(intlist);
            break;
    }


    //Array of Strings and Sort and reverse the array based on Length of each string from array
    static void sortBasedOnLength(List<String> org)
    {
        org.Sort();
        for (int i = 1; i < org.Count; i++)
        {
            String temp = org[i];

            // Insert s[j] at its correct position
            int j = i - 1;
            while (j >= 0 && temp.Length < org[j].Length)
            {
                org[j + 1] = org[j];
                j--;
            }
            org[j + 1] = temp;
        }
        foreach (String sr in org)
        {
            Console.WriteLine(sr);
        }
    }


    // Array of integers and print index of even and odd number from the array
    static void toPrintEvenOddIndex(List<int>arr)
    {
        for (int i = 0; i < arr.Count; i++)
        {
            if (arr[i] % 2 == 0)
            {
                Console.WriteLine($"Even Number {arr[i]} Present At the Index of {i}");
            }
            else
            {
                Console.WriteLine($"Odd Number {arr[i]} Present At the Index of {i}");
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
    static Boolean checkOrNot(String str)
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
        if (str[0] == 'A' || str[0] == 'M' || str[0] == 'K')
            return true;
        else
            return false;
    }


    //Array of Strings and Find out count of repeated strings
    //in an array and print them on console
    static void frequenciesFind(List<String> str)
    {
        int n = str.Count;
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
            if (count > 1)
                Console.WriteLine($"The {str[i]} appears {count} times in array");
            if (count == 1)
                Console.WriteLine($"The {str[i]} appears {count} time in array");

        }
    }

    //Array of Integers and Find out count of repeated Integers
    //in an array and print them on console
    static void intFrequencieCount(List<int> arry)
    {
        int n = arry.Count;
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
    static void printArray(List<String>res)
    {
        foreach (String str in res)
        {
            Console.WriteLine(str);
        }
    }
    //To Print the integer Array
    static void printIntArray(List<int> res)
    {
        foreach (int n in res)
        {
            Console.WriteLine(n);
        }
    }
    Console.WriteLine();
    Console.WriteLine("Enter Y to Continue N to stop");
    Continue = Console.ReadLine();
    Console.Clear();
}
while (Continue == "y" || Continue == "Y");

