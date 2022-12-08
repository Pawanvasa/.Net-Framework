using DBConnection;
DateTime StartTime; 
DateTime EndTime;
SqlConnection SqlConnection;
OracleConnection OracleConnection;
int respose = 0;
bool isSqlOpen = false;
bool isOracleOpen=false;
do
{
    Console.WriteLine("Open DataBase Connection");
    Console.WriteLine("1. Open DB Connection");
    Console.WriteLine("2. Close DB Connection");
    Console.WriteLine("3. Stop Execution\n");
    respose=Convert.ToInt32(Console.ReadLine());
    Console.Clear();

    switch (respose)
    {

        case 1:
            StartTime = DateTime.Now;
            Console.WriteLine("Enter Connection Sting");
            String? ConnectionString = Console.ReadLine();
            if (isOracleOpen)
            {
                Console.WriteLine("Please Close The Oracle Connection To Open New Connection\n");
            }
            else if (isSqlOpen)
            {
                Console.WriteLine("Please Close The Sql Connection To Open New Connection\n");

            }
            else if (ConnectionString == "sql")
            {
                SqlConnection = new SqlConnection(ConnectionString);
                try
                {

                    EndTime = DateTime.Now;
                    TimeSpan TimeOut = EndTime - StartTime;
                    if (TimeOut.TotalSeconds > 10)
                    {
                        throw new Exception("Time out");
                    }
                    SqlConnection.open();
                    isSqlOpen = true;
                    StartTime = DateTime.MinValue;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (ConnectionString == "oracle")
            {
                OracleConnection = new OracleConnection(ConnectionString);
                try
                {
                    EndTime = DateTime.Now;
                    TimeSpan TimeOut1 = EndTime - StartTime;
                    if (TimeOut1.TotalSeconds > 10)
                    {
                        throw new Exception("Time out");
                    }
                    OracleConnection.open();
                    isOracleOpen = true;
                    StartTime = DateTime.MinValue;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Invalid String Enter sql/oracle\n");
            }
            break;
        case 2:
            Console.WriteLine("Enter Connection Sting");
            String ?ConnectionString1 = Console.ReadLine();
            SqlConnection = new SqlConnection(ConnectionString1);
            OracleConnection = new OracleConnection(ConnectionString1);
            if (isOracleOpen && ConnectionString1=="oracle")
            { 
                OracleConnection.close();
               // Console.WriteLine("Oracle Conection Closed Successfully\n");
                isOracleOpen=false;
            }else if(isSqlOpen && ConnectionString1=="sql") {
                SqlConnection.close();
                //Console.WriteLine("Sql Conection Closed Successfully\n");
                isSqlOpen = false;
            }
            else
            {
                Console.WriteLine("Conection Not Opened\n");
            }
            break;

    }

} while (respose!=3);