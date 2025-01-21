

using System.Runtime.CompilerServices;

namespace MyApp.UserMode;

class Person{
    private int id;
    private string name;

    public string Name{
        get{
            return name;
        }

        set{
            name=value;
        }
    }

    public static int count;

    static Person(){
        Console.WriteLine("Satic constructor is called");
        count=0;
    }
    public Person(int id, string name){
        this.id=id;
        this.name=name;
    }

    public Person(string name){
        this.name=name;
        this.id=0;
    }
    
    override
    public string ToString(){
        return $"id:{this.id} name:{this.name}";
    }
}

class Employee:Person{
    private int salary;

    public Employee(int id, string name, int salary):base(id,name){
        this.salary=salary;
    }

    override
    public string ToString(){
        return $"{base.ToString()}"+$" salary:{this.salary}";
    }
}

class Temp{
    private Temp(){}
    public Temp(string t){
        Console.WriteLine("Temp COnstructor is called");
    }
}

struct Student{
    int id;
    string name;

    public Student(int id, string name){
        this.id=id;
        this.name=name;
    }
}

class A{
    public void method1(){
        Console.WriteLine("Method1 is called");
    }

    public void method2(){
        Console.WriteLine("Method2 is called");
    }

}

class B :A{
    public void method3(){
        Console.WriteLine("Method3 is called");
    }
}

interface Ical{
    void add(int a,int b);
    void sub(int a, int b);
}

class ModerCal:Ical{
    public void add(int a,int b){
        Console.WriteLine($"{a}+{b}={a+b}");
    }

    public void sub(int a,int b){
        Console.WriteLine($"{a}+{b}={a-b}");
    }
}


//finalizer;

class C1{
    public C1(){
        Console.WriteLine("C1 constructor is called");
    }

    //Destructos or finalizer is called by gc. As a programmer we cannot controll calling of destructor. So for better resource management, we can go with IDisposable
    ~C1(){
        Console.WriteLine("C1 class is goin to garbage collection");
    }
}

class C2Cmp:IDisposable{
    public void Dispose(){

    }
}

//IDisposable
class C2:IDisposable{

    private IntPtr? unmangedRes;
    private C2Cmp managedRes;  //managed res by GC

    private bool isDisposed;
    public C2(IntPtr unmanagedRes, C2Cmp managedRes){
        this.unmangedRes=unmanagedRes;
        this.managedRes=managedRes;
        Console.WriteLine("The instance of C2 is initalised");
    }

    public void showMsg(){
        Console.WriteLine("Showing msg from C2 resource");
    }

    //This method is always called implicitly before object is garbage collected or removed from the memorey. 
    public void Dispose(){
        Console.WriteLine("Disposing the current C2 resource");
        Dispose(disposing:true);
    }
    private void CloseUnmanagedRes(){
        //close the unmanged res
        unmangedRes=null;
    }
    protected virtual void Dispose(bool disposing){
        // StringFreezingAttribute up managed res 
        if(disposing){
            //dispose the person
            managedRes.Dispose();
        }

        this.CloseUnmanagedRes();
        isDisposed=true;
    }

    ~C2(){
        Dispose(disposing:false);  //now the instance is going to garbage colection, just release the unmanged res, other managed res is handled by GC
    }
}