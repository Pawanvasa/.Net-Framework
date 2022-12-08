using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment03Aug_Spot_.Operations
{
    public class FileOperations
    {

        //Create File
        public void CreateFile(String directory,string fileName)
        {
            try
            {
                if (fileName == string.Empty || fileName.Substring(fileName.IndexOf(".") + 1)!="txt")
                {
                    throw new Exception("File Name Cannot be Empty");
                }
                FileStream fs = File.Create($"{directory}{fileName}");
                Console.WriteLine("The File is created successfully");
                fs.Close();
                fs.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //Write Data into the File
        public void WriteFile(string directory,string fileName, string contents)
        {
            try
            {
                if (fileName == string.Empty || fileName.Substring(fileName.IndexOf(".") + 1) != "txt")
                {
                    throw new Exception("File Name Cannot be Empty");
                }
                File.WriteAllText(@$"{directory}{fileName}", contents);
                Console.WriteLine("Contents are written to the File");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void WriteFile(string directory,string fileName, string[] contents)
        {
            try
            {
                if (fileName == string.Empty || fileName.Substring(fileName.IndexOf(".") + 1) != "txt")
                {
                    throw new Exception("File Name Cannot be Empty");
                }
                File.WriteAllLines($"{directory}{fileName}", contents);
                Console.WriteLine("Contents are written to the File");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //Read The File 
        public string ReadFile(String directory,string fileName)
        {
            try
            {
                string contents = string.Empty;
                if (fileName == string.Empty || fileName.Substring(fileName.IndexOf(".") + 1) != "txt")
                {
                    throw new Exception("File Name Cannot be Empty");
                }
                contents = File.ReadAllText($"{directory}{fileName}");
                return contents;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AppendFile(string directory, string fileName, string contents)
        {
            try
            {
                if (fileName == string.Empty || fileName.Substring(fileName.IndexOf(".") + 1) != "txt")
                {
                    throw new Exception("File Name Cannot be Empty");
                }
                File.AppendAllText($"{directory}{fileName}", contents);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void AppendFile(string directory, string fileName, string[] contents)
        {
            try
            {
                if (fileName == string.Empty || fileName.Substring(fileName.IndexOf(".") + 1) != "txt")
                {
                    throw new Exception("File Name Cannot be Empty");
                }
                File.AppendAllLines($"{directory}{fileName}", contents);
            }
            catch (Exception)
            {

                throw;
            }
        }


        // Make the copy of the file
        public void MakeCopy(string srcFileName, string destFileName)
        {
            if (File.Exists(destFileName))
                File.Delete(destFileName);
            if (srcFileName == string.Empty || destFileName == string.Empty )
            {
                throw new Exception("Source File Name or Destination File NAme Cannot be Empty");
            }
            File.Copy(srcFileName, destFileName);
        }

        //Move the File
        public void MoveFile(string srcFileName,String destFile)
        {
            if (File.Exists(destFile))
                File.Delete(destFile);
            File.Move(srcFileName, destFile);
            Console.WriteLine("{0} was moved to {1}.", srcFileName, destFile);            
        }

        //Encrypt The File
        public void Encrypt(string filename)
        {
            if (filename == string.Empty)
            {
                throw new Exception("Source File Name or Destination File Name Cannot be Empty");
            }
            File.Encrypt(filename);
        }

        //Decrypt the File
        public void Decrypt(String filename)
        {
            if (filename == string.Empty)
            {
                throw new Exception("Source File Name or Destination File Name Cannot be Empty");
            }
            File.Decrypt(filename);
             
            Console.WriteLine("The File is created successfully");
        }

        //Delete the File
        public void DeleteFile(String filename)
        {
            if (filename == string.Empty)
            {
                throw new Exception("Source File Name or Destination File Name Cannot be Empty");
            }
            File.Delete(filename);
        }
    }
}
