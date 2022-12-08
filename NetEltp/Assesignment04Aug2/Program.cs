// See https://aka.ms/new-console-template for more information
using System.Text;

Console.WriteLine("Assignment04Aug-2");
// Full file name 
string fileName = @"C:\Users\Coditas\Documents\Assignment04Aug\sub1\img2.jpg";
FileInfo fi = new FileInfo(fileName);

// Get File Name  
string justFileName = fi.Name;
Console.WriteLine($"File Name: {justFileName}" );

// Get file extension   
string extension = fi.Extension;
Console.WriteLine($"File Extension: {extension}");

// File Exists ?  
bool exists = fi.Exists;
if (fi.Exists)
{
    // Get file size  
    long size = fi.Length;
    Console.WriteLine($"File Size in Bytes: {size}" );
}