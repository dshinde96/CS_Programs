
namespace VisitorDesignPattern;

public class Developer:Employee{

    public int Project{get;}
    public Developer(string name, double salary, int projects):base(name,salary){
        Project = projects;
    }
}