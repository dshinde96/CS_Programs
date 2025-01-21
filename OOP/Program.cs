
using MyApp.UserMode;
namespace OOP;

class Program{
    public static void Main(string[] args){
        // Person u=new Person(10,"Shyam");
        // Console.WriteLine(u.ToString());

        // Person u1=new Person("Ram");
        // Console.WriteLine(u1.ToString());

        // Employee e=new Employee(11,"sager",50000);
        // Console.WriteLine($"\n{e.ToString()}");

        // // Temp t=new Temp();  //Will throw error as we have marked this constructor as rpivate private
        // // Temp t=new Temp("abc");



        // //Implementing c# propertes getters and setters.
        // Console.WriteLine(u.Name);
        // u.Name="GhanShyam";
        // Console.WriteLine(u.Name);


        // A a=new/B();  //we can create the object of child class using the reference of parent class but as the instance is trated as parent type, so we can assess only members inherited from parent.

        // a.method1();
        // a.method2();
        // a.method3();  //will give error

        // B b=new A();// we cannot create the instance of base class using the object of child class type.

        // C1? c =new C1();

        // c=null;

        // GC.Collect();               // Force garbage collection
        // GC.WaitForPendingFinalizers();  // ✅ Ensure finalizers run immediately

        // Console.WriteLine("Main method execution completed.");


        //Will pass the c to GC when program controll moved out of the using block, it will automatically call the Dsipose method before the object is going to garbage collection. we dont need to implicitly call the method.
        using(C2 c=new C2(new IntPtr(),new C2Cmp())){
            Console.WriteLine("Using C2");
        }


        // C2? c=new C2();
        // Console.WriteLine("Using c2");

        // c.Dispose(); //will just call the dispose method through which we can perform action such as resleasing unmanaged res such as db connection, file handles, but it does not free up the memorey. It is not destructor. After calling this method, we can set c to null.
        // c=null;

        
    }
}
