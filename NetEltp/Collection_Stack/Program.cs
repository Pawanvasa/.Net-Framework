// See https://aka.ms/new-console-template for more information
using System.Collections;
Stack st = new Stack();
Console.WriteLine("Enter Size :");
int n = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter Elements of Stack");
for (int i = 0; i < n; i++)
{
    st.Push(Console.ReadLine());
}

Console.WriteLine($"First Element of Stack Before Pop Value = {st.Peek()}");
Console.WriteLine($"Performing Pop Operation value ={st.Pop()}");
Console.WriteLine($"First Element of stack after Pop Value ={st.Peek()}");
int len = st.Count;
for (int i = 0; i <len; i++)
{
    Console.WriteLine($"Type of value={st.Pop()}");
}



