using Newtonsoft.Json;
using RuleEnginePerformanceTest;
using RulesEngine.Models;

string rulesJsonFilePath = "C:\\Users\\Coditas\\source\\repos\\RuleEnginePerformanceTest\\RuleEnginePerformanceTest\\Rules.json";
string jsonContent = File.ReadAllText(rulesJsonFilePath);

// Deserialize the JSON data into a list of WorkflowRule objects
var workflowRules = JsonConvert.DeserializeObject<List<WorkflowRule>>(jsonContent)!;
var ruleEngine = new RuleEngine(workflowRules);


List<Employee> employees = new List<Employee>
{
    new Employee {FirstName="pavan",LastName="vasa" ,Name = "Harry", Experience = 3 },
    new Employee {FirstName="pavan",LastName="vasa" ,Name = "Tony", Experience = 1 },
    new Employee {FirstName="pavan",LastName="vasa",Name = "Eren", Experience = 7 },
    new Employee {FirstName="pavan",LastName="vasa", Name = "Lufy", Experience = 10 },
    new Employee {FirstName="pavan",LastName="vasa", Name = "uzumaki", Experience = 3 },
    new Employee {FirstName="pavan",LastName="vasa", Name = "nami", Experience = 6 },
    new Employee {FirstName="pavan",LastName="vasa", Name = "sanji", Experience = 2 }
};

var res = ruleEngine.CalculateSalary(employees, "ConcatenateNames");

foreach (var employee in res)
{
    Console.WriteLine($"Calculated salary for {employee.Experience} years of experience: {employee.Salary}");
}


public class WorkflowRule
{
    public string? WorkflowName { get; set; }
    public List<SalaryRule>? Rules { get; set; }
}

public class SalaryRule
{
    public string? RuleName { get; set; }
    public string? Expression { get; set; }
    public int Salary { get; set; }
    public string? Action { get; set; }
}

public class Employee
{
    public string? Name { get; set; }
    public int Experience { get; set; }
    public int Salary { get; set; } = 0;
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}