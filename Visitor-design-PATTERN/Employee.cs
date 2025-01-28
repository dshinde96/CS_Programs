
namespace VisitorDesignPattern;

public abstract class Employee{

    public string Name{ get;}
    public double Salary{get;}
    protected Employee(string name,double salary){
        Name=name;
        Salary=salary;
    }
}

