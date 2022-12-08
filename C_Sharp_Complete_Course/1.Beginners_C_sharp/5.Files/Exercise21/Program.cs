//2 - Write a program that reads a text file and displays the longest word in the file.

String path = "C:\\Users\\Coditas\\Documents\\Assignment04Aug\\Exe.txt";
var str = File.ReadAllText(path);
string[] words= str.Split(' ');
string word = "";
int count = 0;
foreach (String s in words)
{
    if (s.Length > count)
    {
        word = s;
        count = s.Length;
    }
}

Console.WriteLine(word+" is the largest word");