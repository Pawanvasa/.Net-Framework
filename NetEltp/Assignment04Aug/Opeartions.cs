using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace Assignment04Aug
{
    public class Opeartions
    {
        List<String> ?records;
        List<Staff> st = new List<Staff>();
        string sourceFilePath = @"C:\Users\Coditas\Documents\Assignment04Aug\";
        string sourceFileName = "DBFile.txt";
        public void CreateFile(String directory, string fileName)
        {
            try
            {
                if (fileName == string.Empty || fileName.Substring(fileName.IndexOf(".") + 1) != "txt")
                {
                    throw new Exception("File Name Cannot be Empty\n");
                }
                FileStream fs = File.Create($"{directory}{fileName}");
                Console.WriteLine("The File is created successfully");
                fs.Close();
                fs.Dispose();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); ;
            }
        }


        /*public void WriteDataIntoFile(String directory, String fileName, Staff contents)
        {
            try
            {
                if (fileName == string.Empty || fileName.Substring(fileName.IndexOf(".") + 1) != "txt")
                {
                    throw new Exception("File Name Cannot be Empty\n");
                }
                String path = $"{directory}{fileName}";
                List<Staff> lines = new List<Staff>();
                lines.Add(contents);
                FileStream fs = new FileStream(@$"{directory}{fileName}", FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                foreach (Staff line in lines)
                {
                    //Console.WriteLine(line.StaffId);
                    if (line.Department == "Doctor")
                    {
                        foreach (Doctor doc in lines)
                        {
                            sw.Write(line.StaffId + ", " + line.StaffName + ", " + line.ContactNo + ", " + line.Department + ", " + line.Education + ", " + line.Email + ", " + line.Location + ", " + doc.Specilization);
                            sw.Write(Environment.NewLine);
                        }
                    }
                    if (line.Department == "Nurse")
                    {
                        foreach (Nurse nur in lines)
                        {
                            sw.Write(line.StaffId + ", " + line.StaffName + ", " + line.ContactNo + ", " + line.Department + ", " + line.Education + ", " + line.Email + ", " + line.Location + ", " + nur.Experience);
                            sw.Write(Environment.NewLine);
                        }
                    }
                    if (line.Department == "Technician")
                    {
                        foreach (Technician tec in lines)
                        {
                            sw.Write(line.StaffId + ", " + line.StaffName + ", " + line.ContactNo + ", " + line.Department + ", " + line.Education + ", " + line.Email + ", " + line.Location + ", " + tec.SaftyChecksDone);
                            sw.Write(Environment.NewLine);
                        }
                    }
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }*/

        public void WriteDataIntoFile(String directory, String fileName, Staff contents)
        {
            Stream fs = new FileStream(@"C:\Users\Coditas\Documents\Assignment04Aug\Emp.json", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            JsonSerializer.Serialize(fs, contents);
            sw.Write(Environment.NewLine);
            fs.Close(); // CLose the File
            fs.Dispose(); // Release the Object
        }

        public void ReadFileByCategory(String category)
        {
            try
            {
                if (category == string.Empty)
                {
                    throw new Exception("Category Cannot be Empty or Invalid Category\n");
                }
                String filePath = $"{sourceFilePath}{sourceFileName}";
                FileInfo fi = new FileInfo(filePath);
                StreamReader sr1 = fi.OpenText();
                String s = String.Empty;
                while ((s = sr1.ReadLine()) != null)
                {
                    if (s.Contains(category))
                    {
                        Console.WriteLine(s);
                        Console.WriteLine();
                    }
                }
                sr1.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public void CheckStaffId(int staffid)
        {
            if (staffid < 0)
            {
                throw new Exception("Invalid Staff Id\n");
            }
            records = File.ReadAllLines($"{sourceFilePath}{sourceFileName}").ToList();
            foreach (String record in records)
            {
                String[] rc = record.Split(", ");
                Staff s = new Staff();
                s.StaffId = Convert.ToInt32(rc[0]);
                s.StaffName = rc[1];
                s.ContactNo = Convert.ToInt32(rc[2]);
                s.Department = rc[3];
                s.Education = rc[4];
                s.Email = rc[5];
                s.Location = rc[6];
                st.Add(s);
            }
            Boolean check = false;
            foreach (Staff s in st)
            {
                if (s.StaffId == staffid)
                {
                    check = true;
                    Console.WriteLine($"Staff Id = {s.StaffId} Staff Name = {s.StaffName} Email = {s.Email} Department = {s.Department} Education = {s.Education}");
                    break;
                }
            }
            if (!check)
            {
                Console.WriteLine("Staff Details Not Found\n");
            }

        }

        public void GetStaffByCount(int count)
        {
            try
            {
                if (count <= 0)
                {
                    throw new Exception("Invalid Count\n");
                }
                String filePath = $"{sourceFilePath}{sourceFileName}";
                FileInfo fi = new FileInfo(filePath);
                StreamReader sr1 = fi.OpenText();
                String s = String.Empty;
                int temp = 0;
                while ((s = sr1.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                    temp++;
                    Console.WriteLine();
                    if (temp >= count)
                    {
                        break;
                    }
                }
                sr1.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DeleteStaffById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new Exception("Invalid Staff Id\n");
                }
                records = File.ReadAllLines($"{sourceFilePath}{sourceFileName}").ToList();
                foreach (String record in records)
                {
                    String[] rc = record.Split(", ");
                    Staff s = new Staff();
                    s.StaffId = Convert.ToInt32(rc[0]);
                    s.StaffName = rc[1];
                    s.ContactNo = Convert.ToInt32(rc[2]);
                    s.Department = rc[3];
                    s.Education = rc[4];
                    s.Email = rc[5];
                    s.Location = rc[6];
                    st.Add(s);
                }
                Boolean bol = false;
                foreach (Staff s in st)
                {
                    if (s.StaffId == id)
                    {
                        bol = st.Remove(s);
                        Console.WriteLine("Record Removed\n");
                        break;
                    }
                }
                if (!bol)
                {
                    Console.WriteLine("Record Not Found\n");
                }
                FileStream fs = new FileStream($"{sourceFilePath}{sourceFileName}", FileMode.Truncate);
                StreamWriter sw = new StreamWriter(fs);
                foreach (Staff line in st)
                {
                    //Console.WriteLine(line.StaffId);
                    sw.Write(line.StaffId + ", " + line.StaffName + ", " + line.ContactNo + ", " + line.Department + ", " + line.Education + ", " + line.Email + ", " + line.Location);
                    sw.Write(Environment.NewLine);
                }
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void UpdateStaffById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new Exception("Invalid Staff Id\n");
                }
                records = File.ReadAllLines($"{sourceFilePath}{sourceFileName}").ToList();
                foreach (String record in records)
                {
                    String[] rc = record.Split(", ");
                    Staff s = new Staff();
                    s.StaffId = Convert.ToInt32(rc[0]);
                    s.StaffName = rc[1];
                    s.ContactNo = Convert.ToInt32(rc[2]);
                    s.Department = rc[3];
                    s.Education = rc[4];
                    s.Email = rc[5];
                    s.Location = rc[6];
                    st.Add(s);
                }
                Boolean check = false;
                int index = 0;
                foreach (Staff s in st)
                {
                    if (s.StaffId == id)
                    {
                        check = true;
                        st.Remove(s);
                        st.Insert(index, AddRecord(id));
                        break;
                    }
                    index++;
                }
                using (FileStream fs = new FileStream($"{sourceFilePath}{sourceFileName}", FileMode.Truncate))
                {
                    StreamWriter sw = new StreamWriter(fs);
                    foreach (Staff line in st)
                    {
                        //Console.WriteLine(line.StaffId);
                        sw.Write(line.StaffId + ", " + line.StaffName + ", " + line.ContactNo + ", " + line.Department + ", " + line.Education + ", " + line.Email + ", " + line.Location);
                        sw.Write(Environment.NewLine);
                    }
                }
                if (!check)
                {
                    Console.WriteLine("Staff Details Not Found\n");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static Staff AddRecord(int staffid)
        {
            Console.WriteLine("Enter Staff Details");
            Staff staff = new Staff();
            staff.StaffId = staffid;
            Console.WriteLine("Enter Staff Name");
            staff.StaffName = Console.ReadLine()!;
            Console.WriteLine("Enter Staff Email");
            staff.Email = Console.ReadLine()!;
            Console.WriteLine("Enter Staff ContactNo");
            staff.ContactNo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Staff Education");
            staff.Education = Console.ReadLine();
            Console.WriteLine("Enter Staff ShiftStartTime");
            staff.ShiftStartTime = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Staff ShiftEndTime");
            staff.ShiftEndTime = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Staff Location");
            staff.Location = Console.ReadLine()!;
            return staff;
        }
    }
}