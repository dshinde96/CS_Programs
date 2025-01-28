
namespace ReadFileBits;

class Program{

    public static async Task Main(string[] args){
        string filePath="/home/dnyaneshwar/C#/PhoneRegistry/Contacts.txt";
        long? totalByetes=await GetByteCount(filePath);

        if(totalByetes==null){
            Console.WriteLine("Error while accessing the file");
            return;
        }
        Console.WriteLine($"\n\nTotal bytes in the file: {totalByetes}");

    }

    public static async Task<long?> GetByteCount(string filePath){
        if(!File.Exists(filePath)){
            return null;
        }
        long totalByetesRead=0;
        long totalBytesInFile=new FileInfo(filePath).Length;
        using FileStream fs=File.OpenRead(filePath);
        byte[] buffer=new byte[1024];
        int readLen=0;
        while((readLen=await fs.ReadAsync(buffer,0,buffer.Length))>0){
            // string textRead=System.Text.Encoding.UTF8.GetString(buffer,0,buffer.Length);
            totalByetesRead+=readLen;
            Console.WriteLine($"\nTotal bytes read:{totalByetesRead}\tProgress:{Math.Round(totalByetesRead / (double)totalBytesInFile*100,2)}%");
        }
        return totalByetesRead;
    }
}