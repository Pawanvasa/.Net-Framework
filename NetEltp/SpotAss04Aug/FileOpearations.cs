using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace SpotAss04Aug
{
    public class FileOpearations : IDisposable
    {
        FileStream ?fs;
        string filePath = string.Empty;
        public FileOpearations()
        {
            filePath = @"C:\Users\Coditas\Desktop\MCU.txt";
        }

        public string ReadFileLineByLine()
        {
            string str = string.Empty;
            try
            {
               fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                str = sr.ReadToEnd();
                foreach(var s in str)
                {
                    if (s == '.')
                    {
                        Console.WriteLine();
                        
                    }
                    Console.Write(s);
                }
                sr.Close();
                sr.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex); ;
            }
            return str;
        }

        public string ReadEntireFile()
        {
            string str = string.Empty;
            try
            {
                fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                StreamWriter srw = new StreamWriter(fs);
                str = sr.ReadToEnd();

                sr.Close();
                sr.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex); ;
            }
            return str;
        }

        public char[] ReadFileStartandEnd(int startIndex,int count)
        {
            Char []res=new char[1024];
            try
            {
                fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                sr.ReadBlock(res,startIndex,count-1);
                sr.Close();
                sr.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return res;
        }


        public void Dispose()
        {
            fs!.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

