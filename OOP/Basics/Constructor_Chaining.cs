using System;

namespace Basics;

public class Employee
{
    public string? Name { get; set; }
    public int EnployeeId { get; set; }
    public Employee(string name, int employeeId)
    {
        Name = name;
        EnployeeId = employeeId;
    }
    public void Work()
    {
        Console.WriteLine("Employee is working.");
    }
    public void TakeBreak()
    {
        Console.WriteLine("Employee is taking a break.");
    }
}
public class Manager : Employee
{
    public string Department { get; set; }
    public Manager(string name, int employeeId, string department) : base(name, employeeId)
    {
        Department = department;
    }
    public new void Work()
    {
        base.Work();
        Console.WriteLine("Manager is working.");
    }
    public void ConductMeeting()
    {
        Console.WriteLine("Manager is conducting a meeting.");
    }
}
public class SeniorManager : Manager
{
    public int NoOfTeams { get; set; }
    public SeniorManager(string name, int employeeId, string department, int NoOfTeams) : base(name, employeeId, department)
    {
        this.NoOfTeams = NoOfTeams;
    }
    public new void Work()
    {
        base.Work();
        Console.WriteLine("Senior Manager is working.");
    }
    public void MakeDecisions()
    {
        Console.WriteLine("Senior Manager is making decisions.");
    }
}
/****
// Creating an instance of the SeniorManager class
SeniorManager seniorManager = new SeniorManager(name: "Alice", employeeId: 12345, department: "Engineering", NoOfTeams: 5);
seniorManager.MakeDecisions();
seniorManager.Work();

Console.WriteLine("\n**********\n");
// Creating an instance of the Manager class
Manager manager = new Manager(name: "Bob", employeeId: 67890, department: "Marketing");
manager.ConductMeeting();
manager.Work();
 ****/