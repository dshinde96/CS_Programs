using System.Net.Sockets;
using System.Text;

namespace HelloWorld;

class person{
    public string name;
    public Address a;

    public person DeepCopy(){
        return new person{
            name=this.name,
            a = new Address{village="Los angella", pincode=38472}
        };
    }


}

class Address{
    public string village;
    public int pincode;

    override
    public string ToString(){
        return $"{village} {pincode}";
    }
}
class BoxedValue
{
    public int Value;
}
class Program
{
    static void func(ref int a){
        a*=2;
    }
    static void func1(out int a){
        a=3;
    }
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello, World!");
        // int age=23;
        // Console.WriteLine("Age is "+age);
        // System.Console.WriteLine();

        // Console.WriteLine(1/0);
        // int [][] a={
        //     new int[] {1},
        //     new int[] {2,3},
        //     new int [] {4,5}
        // };
        // for(int i=0; i<a.Length; i++){
        //     for(int j=0; j<a[i].Length; j++){
        //         Console.Write(a[i][j] + " ");
        //     }
        //     Console.WriteLine();
        // }

        //Passing value types as reference
        // int a=2;
        // Console.WriteLine(a);
        // func(ref a);
        // Console.WriteLine(a);

        // int b;
        // func1(out b);
        // Console.WriteLine(b);

        // person p1=new person{name="Alice",a=new Address{village="California",pincode=33412}};
        // person p2=p1;

        // Console.WriteLine($"{p1.name} {p1.a.village} {p1.a.pincode}");
        // Console.WriteLine($"{p2.name} {p2.a.village} {p2.a.pincode}");

        // p2.a.village="Los Angela";
        // Console.WriteLine();
        // Console.WriteLine($"{p1.name} {p1.a.village} {p1.a.pincode}");
        // Console.WriteLine($"{p2.name} {p2.a.village} {p2.a.pincode}");

        // float a1=9.999F;
        // int a2=(int)a1;
        // int a3=Convert.ToInt32(a1);
        // Console.WriteLine($"{a1}->{a2}->{a3}");

        // int a1=128;
        // sbyte b1=(sbyte)a1;  //conversion from smaller to largertypes involves loss of data.
        // Console.WriteLine($"{a1}->{b1}");


        // int a1=98;
        // Console.WriteLine(a1.ToString());

        //dynamic typing
        // dynamic d1=12;
        // Console.WriteLine(d1.GetType());

        // d1=new Address{village="Belpimpalgoan",pincode=413725};
        // Console.WriteLine(d1.GetType());


        //Boxing and unboxing:
        // Boxing is the process of converting a value type to the type object or to any interface type implemented by this value type. When the common language runtime (CLR) boxes a value type, it wraps the value inside a System.Object instance and stores it on the managed heap. Unboxing extracts the value type from the object. Boxing is implicit; unboxing is explicit. The concept of boxing and unboxing underlies the C# unified view of the type system in which a value of any type can be treated as an object.

        // int i=34;
        // object o=i;  //boxing
        // object o1=o;
        //     // o1=35;   //A new boxed object is created for 35, and o1 now points to this new object. o remains unchanged because it still points to the original boxed 10.
        // int a=(int)o;   //unboxing-> need explicit decalration of value type
        // a=35;
        // Console.WriteLine($"{i}->{o}->{o.GetType()}->{a}");


        //built in reference type:
        // dynamic d1=34;
        // Console.WriteLine(d1.ToString());

        // int[] arr={1,2,3,4};
        // Console.WriteLine(arr.ToString());

        // Console.WriteLine(System.IO.FileInfo)

        // Address a=new Address{village="Belpimpalgoan",pincode=413725};
        // Console.WriteLine(a.ToString());
        // Console.WriteLine(a);

        // unsafe{
        //     string s1="abc";
        //     fixed(char* p=s1)
        //     Console.WriteLine((IntPtr)p);

        //     s1+="de";
        //     fixed(char* p1=s1)
        //     Console.WriteLine((IntPtr)p1);
            


        //     StringBuilder sb=new StringBuilder();
        //     sb.Append("abc");
        //     string res=sb.ToString();
        //     fixed(char* p=res)
        //     Console.WriteLine($"{res}->{(IntPtr)p}");

        //     sb.Append("cd");
        //     res=sb.ToString();
        //     fixed(char* p=res)
        //     Console.WriteLine($"{res}->{(IntPtr)p}");
        // }

        // int a=-37767;
        // short b=Convert.ToInt16(a);//throws exception saying value either too large or too small
        // ushort b=Convert.ToUInt16(a);  //throws exceptoion
        // Console.WriteLine($"{a}");

        // string s=Convert.ToString(a);
        // string s1=a.ToString();
        // Console.WriteLine(s);
        // Console.WriteLine(s1);

        int? a;
        a=null;
        Console.WriteLine(a.ToString());

        Nullable<int> b=null;
        Console.WriteLine(b.ToString());

        if(a.HasValue){
            Console.WriteLine(a);
        }
        else{
            Console.WriteLine("No value");
        }







    }
}