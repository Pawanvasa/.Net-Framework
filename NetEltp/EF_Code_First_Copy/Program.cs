// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore.Infrastructure;

Console.WriteLine("Hello, World!");
string str = "INFO 2023-01-12T13:57:55.134408100Z 2023-01-12 13:57:55,134 [167] Kevin Osborne OR | Outreach GetSequenceContacts method Contacts retrieved meta count: 273 | CompanyName: Thomson Reuters";
string[] words = str.Split("count: ");
foreach (string word in words)
{
    Console.WriteLine(word);
}
