// See https://aka.ms/new-console-template for more information
using Delegates;

Console.WriteLine("Hello, World!");

DelegateExample delegateExample = new DelegateExample();
myDelegate del = new myDelegate(delegateExample.Mul);
del += delegateExample.Add;
del += delegateExample.Sub;
del(10,2);
