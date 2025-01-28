
namespace VisitorDesignPattern;

public class EngineeringManager:Employee{
    public int Reports{get;}
    public EngineeringManager(string name,double salary,int reports):base(name,salary){
        Reports=reports;
    }
}