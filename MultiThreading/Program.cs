namespace multithreading;

class Program{

    public static void method1(){
        for(int i=0; i<5; i++){
            Thread.Sleep(5000);
            Console.WriteLine($"Method1 {i}");
        }
    }
    public static void method2(){
        for(int i=0; i<5; i++){
            Thread.Sleep(3000);
            Console.WriteLine($"Method2 {i}");
        }
    }
    public static void method3(){
        for(int i=0; i<5; i++){
            Thread.Sleep(1000);
            Console.WriteLine($"Method3 {i}");
        }
    }
    public static void Main(string[] args){
        // Thread curt=Thread.CurrentThread;
        // Console.WriteLine(curt.Name);  //by default a thread does not have any name

        // curt.Name="Main thread";
        // Console.WriteLine(curt.Name);


        //will execute in synchronus manner, one after the other
        // method1();
        // method2();
        // method3();

        // Thread t1=new Thread(method1);
        // Thread t2=new Thread(method2);
        // Thread t3=new Thread(method3);

        // t1.Start();
        // t2.Start();
        // t3.Start();

        // Thread t1=new Thread(()=>{
        //     for(int i=0; i<5; i++){
        //         Thread.Sleep(500);
        //         Console.WriteLine(i);
        //     }
        // });

        // t1.Start();


        //using threadstart delegate

        // ThreadStart ts=new ThreadStart(()=>{
        //     for(int i=0; i<5; i++){
        //         Thread.Sleep(500);
        //         Console.WriteLine(i);
        //     }
        // });
        // Thread t1=new Thread(ts);
        // t1.Start();

        // t1.Join();

        // ParameterizedThreadStart pdts=new ParameterizedThreadStart((object? max)=>{
        //     int m=Convert.ToInt32(max);
        //     for(int i=0; i<m; i++){
        //         Thread.Sleep(500);
        //         Console.WriteLine(i);
        //     }
        // });

        // Thread t2=new Thread(pdts);
        // t2.Start(8);
    }
}