// See https://aka.ms/new-console-template for more information

using ExceptionHandling;

Console.WriteLine("Exception Handling");
try
{
	int number1 = 10 ;
    int number2 = 0;
	int number3 = number1/number2;
}
catch (DivideByZeroException ex)
{
	Console.WriteLine(ex.Message);
}
catch (Exception ex)
{
	Console.WriteLine("Cannot Divide by zero"+ex.Message);
}
 


StreamReader reader=null!;
try
{
	reader = new StreamReader("C:\\Users\\Coditas\\Documents\\SpotAssDotNet\\01_Nov_2022");
	var content = reader.ReadToEnd();
	Console.WriteLine(content);
}
catch(CustomeException ex)
{
	Console.WriteLine(ex);
}
catch (Exception ex)
{
	Console.WriteLine(ex.Message);
}
finally
{
	if (reader != null)
	{
		reader.Dispose();
		Console.WriteLine("Stream is Successfully closed");
	}
}
