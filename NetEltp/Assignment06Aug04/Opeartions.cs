using System.Xml;

namespace Assignment04Aug
{
    public class Opeartions
    {
        List<String> ?records;
        List<Staff> st = new List<Staff>();
        public void CreateFile(String directory, string fileName)
        {
            try
            {
                if (fileName == string.Empty || fileName.Substring(fileName.IndexOf(".") + 1) != "csv")
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
                Console.WriteLine(ex.Message); ;
            }
        }

    
        public void WriteDataIntoFile(String directory, String fileName, Staff contents)
        {
            try
            {
                if (fileName == string.Empty || fileName.Substring(fileName.IndexOf(".") + 1) != "csv")
                {
                    throw new Exception("File Name Cannot be Empty");
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
                            sw.Write(line.StaffId + ", " + line.StaffName + ", " + line.ContactNo + ", " + line.Department + ", " + line.Education + ", " + line.Email + ", " + line.Location+", "+doc.Specilization);
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
                throw;
            }
        }

        public void ReadFileByCategory(String category,string filePath)
        {
            try
            {
                if(category == null)
                {
                    throw new FormatException("Category Cannot be Empty");
                }
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
                throw;
            }
        }


        public void CheckStaffId(int staffid)
        {
            try
            {
                if(staffid < 0)
                {
                    throw new Exception("Invalid Staff Id");
                }
                records = File.ReadAllLines(@"C:\Users\Coditas\Documents\Assignment04Aug\DBFile.csv").ToList();
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
                    Console.WriteLine("Staff Details Not Found");
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }



        public void GetStaffByCount(int count)
        {
            try
            {
                if (count < 0)
                {
                    throw new Exception("Invalid Count");
                }
                String filePath = @"C:\Users\Coditas\Documents\Assignment04Aug\DBFile.csv";
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
                throw;
            }
        }


        public void DeleteStaffById(int id)
        {
            try
            {
                if (id<0)
                {
                    Console.WriteLine("Invalid Staff Id");
                }
                records = File.ReadAllLines(@"C:\Users\Coditas\Documents\Assignment04Aug\DBFile.csv").ToList();
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
                        Console.WriteLine("Record Removed");
                        break;
                    }
                }
                if (!bol)
                {
                    Console.WriteLine("Record Not Found");
                }

                FileStream fs = new FileStream(@$"C:\Users\Coditas\Documents\Assignment04Aug\DBFile.csv", FileMode.Truncate);
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
                throw;
            }
        }


        public void UpdateStaffById(int id)
        {
            try
            {
                if (id < 0)
                {
                    Console.WriteLine("y");
                }
                records = File.ReadAllLines(@"C:\Users\Coditas\Documents\Assignment04Aug\DBFile.csv").ToList();
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
                int index = 0;
                Boolean check = false;
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
                using (FileStream fs = new FileStream(@$"C:\Users\Coditas\Documents\Assignment04Aug\DBFile.csv", FileMode.Truncate))
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
                    Console.WriteLine("Staff Details Not Found");
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
        static Staff AddRecord(int staffid)
        {
            Console.WriteLine("Enter staff Details");
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