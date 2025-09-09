var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    // context.Request
    if (context.Request.Method == "GET")
    {
        if (context.Request.Path.StartsWithSegments("/"))
        {
            await context.Response.WriteAsync("The method is: {context.Request.Method}");
            await context.Response.WriteAsync("The Url iss : {context.");

            await context.Response.WriteAsync($"\r\nHeaders:r\n");

            foreach (var key in context.Request.Headers.Keys)
            {
                await context.Response.WriteAsync($"{key}:{context.Request.Headers[key]}\r\n");

            }
        }
        else if (context.Request.Path.StartsWithSegments("/employees"))
        {
            //  await context.Response.WriteAsync("Employee List");
            var employees = EmployeeRepository.GetEmployees();

            foreach(var employee in employees) {
                await context.Response.WriteAsync($"{employee.Name}: {employee.Position}\r\n");
            }
        }
    }
    
});

app.Run();

static class EmployeeRepository
{
    private static List<Employee> employees = new List<Employee>
    {
        new Employee(1, "Abeni Sileshi" , "Programmer" , 60000),
        new Employee(2, "Tebeyen Bekele", " Security", 70000),
        new Employee(3, "Hasan Ahmed", "Cyber" , 100000)
    };

    public static List<Employee> GetEmployees() => employees;
}

public class Employee
{

    public int Id { get; set; }
    public string Name { get; set; }

    public string Position { get; set; }

    public double Salary { get; set; }

    public Employee(int id, string name, string position, double salary)
    {
        Id = id;
        Name = name;
        Position = position;
        Salary = salary;

    }
}