using Delegates02;

MyClass myClass = new MyClass();
myClass.longRun(printStatus);

static void printStatus(int i)
{
    Console.WriteLine(i);
}