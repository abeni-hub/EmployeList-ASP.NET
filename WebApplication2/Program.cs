using System.Text.Json;

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

            foreach (var employee in employees)
            {
                await context.Response.WriteAsync($"{employee.Name}: {employee.Position}\r\n");
            }
        }
    }
    else if (context.Request.Method == "POST")
    {
        if (context.Request.Path.StartsWithSegments("/employees"))
        {
            using var reader = new StreamReader(context.Request.Body);
            var body = await reader.ReadToEndAsync();
            var employee = JsonSerializer.Deserialize<Employee>(body);

            EmployeeRepository.AddEmployee(employee);
        }
    }

    else if (context.Request.Method == "PUT")
    {
        if (context.Request.Path.StartsWithSegments("/employees"))
        {
            using var reader = new StreamReader(context.Request.Body);
            var body = await reader.ReadToEndAsync();
            var employee = JsonSerializer.Deserialize<Employee>(body);

            var result = EmployeeRepository.UpdateEmployee(employee);
            if (result)
            {
                await context.Response.WriteAsync("Employee updated successfully.");
            }
            else
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("Employee not found.");
            }
        }
    }

    else if(context.Request.Method == "DELETE")
    {
        if (context.Request.Path.StartsWithSegments("/employees"))
        {
            if (context.Request.Query.ContainsKey("id"))
            {
                var id = context.Request.Query["id"];
                if(int.TryParse(id, out int employeeId))
                {
                    var result = EmployeeRepository.DeleteEmployee(employeeId);

                    if(result)
                    {
                        await context.Response.WriteAsync($"Employee deleted Successfully.");
                    }
                    else
                    {
                        await context.Response.WriteAsync($"Employee not found!");
                    }
                }
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

    public static void AddEmployee(Employee? employee)
    {
        if (employee != null)
        {
            employees.Add(employee);
        }
    }

    public static bool UpdateEmployee(Employee? employee)
    {
        if (employee is not null)
        {
            var emp = employees.FirstOrDefault(x =>x.Id == employee.Id);
            if (emp is not null)
            {
                emp.Name = employee.Name;
                emp.Position = employee.Position;
                emp.Salary = employee.Salary;

                return true;
            }
        }

        return false;
    }

    public static bool DeleteEmployee(int id)
    {
        var employee = employees.FirstOrDefault(x => x.Id == id);

        if (employee is not null)
        {
            employees.Remove(employee);
            return true;
        }
        return false;
    }
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