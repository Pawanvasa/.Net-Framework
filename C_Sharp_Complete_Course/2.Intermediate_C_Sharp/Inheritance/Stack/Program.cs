using StackOperations;
using System.Data;

Stack stack = new Stack();
stack.push(1);
stack.push("pavan");
stack.push(4.7);
stack.push(true);
stack.push(7465);
/*Console.WriteLine(stack.pop());
Console.WriteLine(stack.pop());
Console.WriteLine(stack.pop());
Console.WriteLine(stack.pop());
Console.WriteLine(stack.pop());
Console.WriteLine(stack.pop());
stack.clear();
Console.WriteLine(stack.pop());
Console.WriteLine(stack.pop());
Console.WriteLine(stack.pop());
*/
int choice=0;
String toStop;
do
{
    Console.WriteLine();
    Console.WriteLine("Stack Operations");
    Console.WriteLine("1. Push Elements");
    Console.WriteLine("2. Pop Elements");
    Console.WriteLine("3. Clear Stack");
    Console.WriteLine();
    choice=Convert.ToInt32(Console.ReadLine());
    switch (choice)
    {
        case 1:
            Console.WriteLine("Enter Value to push");
            object ?obj=Console.ReadLine();
            stack.push(obj);
            break;
        case 2:
            object popedElement=stack.pop();
            Console.WriteLine($"Poped Element is {popedElement}");
            break;
        case 3:
            stack.clear();
            Console.WriteLine("Stack is empty");
            break;
    }
  /*  Console.WriteLine("Enter n/N to stop");
    toStop = Console.ReadLine();*/
}while(true);
