
namespace partialClassDemo;

partial class Employee{
    public void getDetails(){
        Console.WriteLine($"Full Name:{this.FirstName} {this.LastName}; Salary:{this.Salary}");
    }
}