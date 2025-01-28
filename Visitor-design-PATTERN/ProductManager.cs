
namespace VisitorDesignPattern;

public class ProductManager:Employee{
    public int Reports{get;}
    public ProductManager(string name,double salary,int reports):base(name, salary){
        Reports = reports;
    }
}