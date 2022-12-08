
public class Company
{
    private Company()
    {
        Console.WriteLine("This is a private Constructor");
    }
    public Company(String ename,int EId)
    {
        Console.WriteLine($"{ename} employee id is {EId}");
    }
}

class main2
{
    static void main(String[] args)
    {
        Company com = new Company("pawan", 33);
    }
}