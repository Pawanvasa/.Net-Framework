Decimal number1, number2;
String respose;
do
{
    Console.WriteLine("1. Addition");
    Console.WriteLine("2. subtraction");
    Console.WriteLine("3. Multiplication");
    Console.WriteLine("4. Division");
    Console.WriteLine("5. Square of a Number");
    Console.WriteLine("6. Squre Root of an Number");
    Console.WriteLine("7. Power of a Number");
    Console.WriteLine("Enter Your Choice ");
    int choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {
        //Addition
        case 1:
            Console.WriteLine("Enter Number 1");
            number1 = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter Number 2");
            number2 = Convert.ToDecimal(Console.ReadLine());
            Decimal add = number1 + number2;
            Console.WriteLine("The Additon is = " + add);
            break;

        //subtraction
        case 2:
            Console.WriteLine("Enter Number 1");
            number1 = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter Number 2");
            number2 = Convert.ToDecimal(Console.ReadLine());
            Decimal sub = number1 - number2;
            Console.WriteLine("The Substraction is = " + sub);
            break;


        //Multiplication
        case 3:
            Console.WriteLine("Enter Number 1");
            number1 = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter Number 2");
            number2 = Convert.ToDecimal(Console.ReadLine());
            Decimal mul = number1 * number2;
            Console.WriteLine("The Multiplication is = " + mul);
            break;

        //Division
        case 4:
            Console.WriteLine("Enter Number 1");
            number1 = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter Number 2");
            number2 = Convert.ToDecimal(Console.ReadLine());
            if (number1 == 0 || number2 == 0)
            {
                Console.WriteLine("Please Enter a valide Number");
            }
            else
            {
                Double div = (Double)number1 / (Double)number2;
                Console.WriteLine("The Division is = " + div);
            }
            break;
    
        //Square of a Number
        case 5:
            Console.WriteLine("Enter Number");
            number1 = Convert.ToDecimal(Console.ReadLine());
            Decimal sqrnum1 = number1 * number1;
            Console.WriteLine($"The Squre of {number1} is  {sqrnum1}");
            break;

        //Squre Root of an Number
        case 6:
            String res;
            Console.WriteLine("Enter Number");
            int n = Convert.ToInt32(Console.ReadLine());

            double i = 0,j=0;

            for (j = 1; j * j < n; j++) ;
            if (j * j == n)
            {
                Console.WriteLine($"Square Root {n} is {j}");
            }
            else
            {
                for (i = 0.01; i * i < n; i +=  0.01) ;
                res = i.ToString("0.00");
                Console.WriteLine($"Square Root {n} is {res}");
            }
            break;


        // Power of a Number
        case 7:
            //Decimal base = 237868756;
            Console.WriteLine("Enter base ");
            Decimal base1 = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter Exponent ");
            Decimal Exponent = Convert.ToDecimal(Console.ReadLine());
            Decimal pow = 1;
            for(int k = 0; k < Exponent; k++)
            {
                pow *= base1;
            }

            Console.WriteLine(base1 + " Power " + Exponent + " is =  " + pow);
            break;


    }
    Console.WriteLine();
    Console.WriteLine("Enter Y to continue N to stop");
    respose = Console.ReadLine();
    //Console.Clear();
    Console.WriteLine();
} while (respose=="y" || respose=="Y");



