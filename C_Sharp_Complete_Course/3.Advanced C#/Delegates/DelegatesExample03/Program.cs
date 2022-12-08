using Delegates3;

DelegateExample del = new DelegateExample();
del.sender += reciver;
del.sender += reciver1;
del.sender += reciver2;

Thread thread = new Thread(new ThreadStart(del.hugeProcess));
thread.Start();
//del.hugeProcess();
Console.WriteLine("This main");


static void reciver(int i)
{
    Console.WriteLine($"Reciver = {i}");
}
static void reciver1(int i)
{
    Console.WriteLine($"Reciver1 = {i}");

}
static void reciver2(int i)
{
    Console.WriteLine($"Reciver2 = {i}");

}