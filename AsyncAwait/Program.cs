
using System.Threading.Tasks;

namespace AsyncAwait;

class Program{
    public static async Task Main(string[] args){
        Console.WriteLine("Main started");
        // func1();
        // func2().ContinueWith((res)=>Console.WriteLine($"Result is {res.Result}"));

        // int res=await func2();
        Task<int>t=func2();
        int res=await t; //await till the result is retured
        System.Console.WriteLine($"Result is {res}");
        System.Console.WriteLine("Main Ended");
        Console.ReadKey();
    }

    static async Task func1(){
        Console.WriteLine("Func1 started");
        await Task.Delay(TimeSpan.FromSeconds(5));
        Console.WriteLine("Fun1 Ended");
    }

    static async Task<int> func2(){
        await Task.Delay(TimeSpan.FromSeconds(2));
        return 10;
    }
}