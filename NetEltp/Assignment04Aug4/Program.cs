DirectoryInfo di = new DirectoryInfo(@"C:\Users\Coditas\Documents\Assignment04Aug");

DirectoryInfo[] dir = di.GetDirectories();
FileInfo[] files = di.GetFiles("*.*");

//For Directory Files
foreach (FileInfo file in files)
{
    Console.WriteLine(file.FullName);
    Console.WriteLine($"File name is {file.Name}" );
    Console.WriteLine($"File Size is {file.Length.ToString()}" );
    Console.WriteLine($"File Created At {file.CreationTime}");
    Console.WriteLine($"File Modified At {file.LastAccessTime}" );
    Console.WriteLine();
}

// for Sub Directories Files
foreach (DirectoryInfo dirInfo in dir)
{
    Console.WriteLine(dirInfo.FullName);
    FileInfo[] fi = dirInfo.GetFiles("*.*");
    foreach (FileInfo fi2 in fi)
    {
        Console.WriteLine($"File name is {fi2.Name}" );
        Console.WriteLine($"File Size is {fi2.Length.ToString()}" );
        Console.WriteLine($"File Created At {fi2.CreationTime}" );
        Console.WriteLine($"File Modified At {fi2.LastAccessTime}" );
        Console.WriteLine();
    }
}
Console.WriteLine();
