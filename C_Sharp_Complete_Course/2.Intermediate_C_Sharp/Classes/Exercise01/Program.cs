using Exercise01;
StopWatch sw = new StopWatch();
int choice;
bool validation = false;
do
{
    Console.WriteLine("Choose an option");
    Console.WriteLine("1. To start the stopwatch");
    Console.WriteLine("2. To stop the stopwatch");
    Console.WriteLine("3. To Exit");
    choice = Convert.ToInt32(Console.ReadLine());
    switch (choice)
    {
        case 1:
            if (validation == true)
            {
                Console.WriteLine();
                Console.WriteLine("stopwatch is still running");
            }
            else
            {
                sw.start();
                validation = true;
            }
            break;
        case 2:
            sw.stop();
            sw.durationCalculation();
            validation = false;
            break;
    }

} while (choice != 3);

sw.start();
sw.stop();
