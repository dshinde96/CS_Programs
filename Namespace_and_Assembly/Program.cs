using System.Collections;
// namespace Namespace_and_Assembly;

namespace MyApp.Utilities
{
    public class StringHelper
    {
        public static string ToUpperCase(string s)
        {
            return s.ToUpper();
        }
    }
}

namespace MyApp.Model
{
    public class User
    {
        int id;
        string name;

        public User(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        // Corrected method name to use PascalCase
        public string GetName()  
        {
            return this.name;
        }
    }
}

class MyClass{
    
    public static void Main(string[] args){
        // ArrayList arr=new ArrayList();

        // for(int i=0; i<4; i++){
        //     arr.Add(i);
        // }

        // Console.WriteLine(arr.Count);
        // for(int i=0; i<arr.Count; i++){
        //     System.Console.WriteLine(arr[i]);
        // }


        //Arraylist stores the elements as object. Hence boxes value type at the time of storing and unbox when retrived

        //We can use List<T> as it store element as value type and do not involve boxing and unboxing

        // List<int> l=new List<int>();

        // for(int i=0; i<4; i++)
        // l.Add(i);

        // for(int i=0; i<l.Count; i++)
        // Console.WriteLine(l[i]);
        
        Hashtable t=new Hashtable();
        t.Add(1,"Ram");
        t.Add(2,"Shyam");

        // for(int i=0; i<t.Count; i++){
        //     Console.WriteLine(t[i]);
        // }
        // System.Console.WriteLine(t[2]);

        Queue q=new Queue();

        q.Enqueue(1);
        q.Enqueue(2);
        q.Enqueue(3);
        q.Enqueue(4);

        // while(q.Count!=0){
        //     int? a=(int)q.Dequeue();
        //     Console.WriteLine(a);
        // }

        // SortedList sl=new SortedList();

        // sl.Add(2);
        // sl.Add(2);
        // sl.Add(2);
        // sl.Add(2);

        // Stack st=new Stack();
        // st.Push(1);
        // st.Push(2);
        // st.Push(3);
        // st.Push(4);

        // while(st.Count!=0){
        //     Console.WriteLine(st.Pop());
        // }

        // Dictionary<String,int>d=new Dictionary<string, int>();
        // d.Add("Ram",90);
        // d.Add("Shyam",91);
        // d.Add("Sita",93);

        // Console.WriteLine(d["Ram"]);
        // Console.WriteLine(d["Shyam"]);
        // Console.WriteLine(d["Sita"]);

        // HashSet<int>h=new HashSet<int>(){1,2,3};
        // h.Add(5);

        // for(int i=0; i<h.Count; i++){
        //     System.Console.WriteLine(h.TryGetValue);
        // }

        MyApp.Model.User u = new MyApp.Model.User(2, "Shyam");
        string uppercased = MyApp.Utilities.StringHelper.ToUpperCase(u.GetName());  // Using 'GetName' instead of 'getName'
        Console.WriteLine(uppercased);

    }
}

