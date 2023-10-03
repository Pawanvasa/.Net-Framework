using DDD.Domin.Entites;

namespace DDD.Infrastucture.Repositories
{
    public class SalaryRepository : ISalaryRepository
    {
        public void Add(Salary salary)
        {
            Console.WriteLine("Salary Added Successfully");
        }
    }
}
