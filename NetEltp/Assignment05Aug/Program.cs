String SourceDirectory = @"C:\Users\Coditas\Documents\Assignment04Aug";
String DestinationDirectory = @"C:\Users\Coditas\Documents\TargertFolder";
CopyFiles(SourceDirectory,DestinationDirectory);
static void CopyFiles(string sourcePath, string targetPath)
{
    //Now Create all of the directories
    foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
    {
        Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
    }

    //Copy all the files & Replaces any files with the same name
    foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
    {
        File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
    }
    Console.WriteLine($"files copied from {sourcePath} to {targetPath}");
}