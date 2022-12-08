//1- Write a program that reads a text file and displays the number of words.

String path = @"C:\Users\Coditas\Documents\Assignment04Aug\Exe.txt";
String str = File.ReadAllText(path);
string[]wordsCount=str.Split(" ");
Console.WriteLine($"Words Count in the File is :{wordsCount.Length}");
