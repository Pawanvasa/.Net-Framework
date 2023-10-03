using RulesEngine.Models;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace RuleEnginePerformanceTest
{

    public class RuleEngine
    {
        private readonly List<WorkflowRule> _workflowRules;

        public RuleEngine(List<WorkflowRule> workflowRules)
        {
            _workflowRules = workflowRules;
        }

        public List<Employee> CalculateSalary(List<Employee> employees, string ruleName)
        {
            var salaryCalculationWorkflow = _workflowRules.Find(w => w.WorkflowName == "SalaryCalculations");
            var employeeResult = new List<Employee>();

            foreach (var employee in employees)
            {
                foreach (var rule in salaryCalculationWorkflow!.Rules!)
                {
                    var parameterExpression = Expression.Parameter(typeof(RuleParameter), "RuleParameter");
                    var ruleExpression = DynamicExpressionParser.ParseLambda(new[] { parameterExpression }, typeof(bool), rule.Expression!);
                    var ruleLambda = ruleExpression.Compile();
                    var isRuleSatisfied = (bool)ruleLambda.DynamicInvoke(new RuleParameter { ExperienceInYears = employee.Experience })!;

                    if (isRuleSatisfied)
                    {
                        employee.Salary = rule.Salary;
                        break;
                    }
                    // Check the "ConcatenateNames" rule

                    var concatenateRule = salaryCalculationWorkflow!.Rules!.FirstOrDefault(r => r.RuleName == ruleName);
                    if (concatenateRule != null)
                    {
                        var concatenateExpression = DynamicExpressionParser.ParseLambda(new[] { parameterExpression }, typeof(string), concatenateRule.Expression!);
                        var concatenateLambda = concatenateExpression.Compile();
                        var resultParameter = new RuleParameter
                        {
                            FirstName = employee.FirstName,
                            LastName = employee.LastName,

                        };
                        var result = (string)concatenateLambda.DynamicInvoke(resultParameter)!;
                        if (result != null)
                        {
                            employee.Name = result;
                        }
                    }
                }

                employeeResult.Add(employee);
            }
            return employeeResult;
        }
    }
    public class RuleParameter
    {
        public int ExperienceInYears { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName { get; set; }
    }

}
