
using System.Data.SqlTypes;
using System.Threading.Tasks;

namespace AsyncAwait;

class Program{
    public static async Task Main(string[] args){
        Console.WriteLine("Main started");
        // func1();
        // func2().ContinueWith((res)=>Console.WriteLine($"Result is {res.Result}"));

        // int res=await func2();
        // Task<int>t=func2();
        // int res=await t; //await till the result is retured
        // System.Console.WriteLine($"Result is {res}");
        // System.Console.WriteLine("Main Ended");
        // Console.ReadKey();

        string filePath="/home/dnyaneshwar/C#/PhoneRegistry/Contacts.txt";
        // Task<long> ByteCountTask=Task.Run(()=>{
        //     return new FileInfo(filePath).Length;
        // });
        // long byteCount=await ByteCountTask;
        // Console.WriteLine(byteCount);

        long totalbytes=await GetFileLength(filePath);
        Console.WriteLine($"\nTotal bytes in file are: {totalbytes}");

        // Task.Run(()=>GetFileLength(filePath)).ContinueWith(t=>Console.WriteLine($"\nTotal bytes in file are: {t.Result}"));

        // Task<long>t1=Task.Run(()=>GetFileLength(filePath));
        // long totalbytes=await t1;
        // t1.ContinueWith(t=>Console.WriteLine($"\nTotal bytes in file are: {t.Result}"));

        
        System.Console.WriteLine("Main thread ended");
        // Console.ReadKey();
        
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

    static async Task<long> GetFileLength(string filePath){

        long totalbytesRead=0;
        long totalBytesInFile=new FileInfo(filePath).Length;

        using(FileStream fs=File.OpenRead(filePath)){
            byte[] buffer=new byte[1024];
            int readLen;
            while((readLen=await fs.ReadAsync(buffer,0,buffer.Length))>0){
                totalbytesRead+=readLen;
                Console.WriteLine($"{totalbytesRead} bytes read\tProgress:{Math.Round(((double)totalbytesRead/(double)totalBytesInFile)*100,2)}%");
                Thread.Sleep(500);
            }
        }
        return totalbytesRead;
    }
}